using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bakery.Models
{
    [Table("Flavors")]
    public class Flavor
    {
        [Key]
        public int FlavorId { get; set; }
        public string Description { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
