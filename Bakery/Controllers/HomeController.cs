using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Bakery.Controllers
{
    public class HomeController : Controller
    {
      private readonly BakeryContext _db;
      private readonly UserManager<ApplicationUser> _userManager;

      public HomeController(UserManager<ApplicationUser> userManager,BakeryContext db)
      {
        _userManager = userManager;
        _db = db;
      }

    [HttpGet("/")]
    public async Task<ActionResult> Index()
    {
      Flavor[] flavors = _db.Flavors.ToArray();
      Dictionary<string, object[]> model = new Dictionary<string, object[]>();
      model.Add("flavors", flavors);

      string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
      if (currentUser != null)
      {
        Treat[] treats = _db.Treats
            .Where(entry => entry.User.Id == currentUser.Id)
            .ToArray();
        model["treats"] = treats; // Update the value of an existing key
      }
      else
      {
        Treat[] treats = _db.Treats.ToArray();
        model.Add("treats", treats); // Add the Treats array with a new key
      }
      return View(model);
    }
  }
}
