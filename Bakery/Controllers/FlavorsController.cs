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

        public IActionResult Edit(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}