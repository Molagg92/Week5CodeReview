using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bakery.Models;

namespace Bakery.Controllers
{
    public class FlavorController : Controller
    {
      private readonly BakeryContext _db;
      public FlavorController(BakeryContext db)
      {
        _db = db;
      }
  public ActionResult Index()
      {
      List<Flavor> model = _db.Flavors.ToList();
      return View(model);
      }
    }
}