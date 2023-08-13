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
      public ActionResult Create()
      {
      return View();
      }

      [HttpPost]
      public ActionResult Create(Flavor flavor)
      {
        if (!ModelState.IsValid)
        { 
          return View(flavor);
        }
        else
        {
        _db.Flavors.Add(flavor);
        _db.SaveChanges();
        return RedirectToAction("Index");
        }
      }
      public ActionResult Details(int id)
      {
        Flavor thisFlavor = _db.Flavors
                                    .Include(flavor => flavor.FlavorTreatEntities)
                                    .ThenInclude(join => join.Treat)
                                    .FirstOrDefault(flavor => flavor.FlavorId == id);
       return View(thisFlavor);
      }
    }
}