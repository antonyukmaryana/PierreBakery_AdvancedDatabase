using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bakery.Models
{
    [Table("Flavors")]
    public class Flavor
    {
        public Flavor()
        {
            this.Treats = new HashSet<TreatFlavor>();
        }

        [Key] public int FlavorId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TreatFlavor> Treats { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}