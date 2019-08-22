using System.Collections;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bakery.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Bakery.Controllers
{
    [Authorize]
    public class FlavorsController : Controller
    {
        private readonly BakeryContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public FlavorsController(UserManager<ApplicationUser> userManager, BakeryContext database)
        {
            _userManager = userManager;
            _db = database;
        }

        public async Task<ActionResult> Index()
        {
            var currentUser = await GetApplicationUser();
            return View(_db.Flavors.Where(x => x.User.Id == currentUser.Id));
        }

        private async Task<ApplicationUser> GetApplicationUser()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return currentUser;
        }

        public ActionResult Create()
        {
            ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Flavor flavor)
        {
            var currentUser = await GetApplicationUser();
            flavor.User = currentUser;
            _db.Flavors.Add(flavor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var currentUser = await GetApplicationUser();
            return View(_db.Flavors.FirstOrDefault(treat => treat.FlavorId == id && treat.User.Id == currentUser.Id));
        }

        public IActionResult DeleteTreat(int joinId, int flavorId)
        {
            var treatFlavor = _db.TreatFlavor.FirstOrDefault(tf => tf.TreatFlavorId == joinId);
            _db.TreatFlavor.Remove(treatFlavor);
            _db.SaveChanges();
            return RedirectToAction("Details", new {id = flavorId});
//            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddTreat(int id)
        {
            var currentUser = await GetApplicationUser();
            var map = new Hashtable();
            map["flavor"] =
                _db.Flavors.FirstOrDefault(treat => treat.FlavorId == id && treat.User.Id == currentUser.Id);
            map["treats"] = _db.Treats.Where(treat => treat.User.Id == currentUser.Id).ToList();
            return View(map);
        }

        public IActionResult AddTreatToFlavor(int flavorId, int treatId)
        {
            var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == treatId);
            var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == flavorId);
            var treatFlavor = new TreatFlavor();
            treatFlavor.Flavor = thisFlavor;
            treatFlavor.Treat = thisTreat;
            _db.TreatFlavor.Add(treatFlavor);
            _db.SaveChanges();
            return RedirectToAction("Details", new {id = flavorId});
        }

        public IActionResult Details(int id)
        {
            var thisTreat = _db.Flavors
                .Include(treat => treat.Treats)
                .ThenInclude(join => join.Treat)
                .FirstOrDefault(treat => treat.FlavorId == id);
            return View(thisTreat);
        }
    }
}