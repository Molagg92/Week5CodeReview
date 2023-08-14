using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bakery.Models;

namespace Bakery.Controllers
{
  public class TreatController : Controller
  {
    private readonly BakeryContext _db;
    public TreatController(BakeryContext db)
    {
      _db = db;
    }
public ActionResult Index()
    {
    List<Treat> model = _db.Treats.ToList();
    return View(model);
    }
    public ActionResult Create()
    {
    return View();
    }

    [HttpPost]
    public ActionResult Create(Treat treat)
    {
      if (!ModelState.IsValid)
      { 
        return View(treat);
      }
      else
      {
      _db.Treats.Add(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
      }
    }
    public ActionResult Details(int id)
    {
      Treat thisTreat = _db.Treats
                          .Include(treat => treat.FlavorTreatEntities)
                          .ThenInclude(join => join.Flavor)
                          .FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }
    public ActionResult Edit(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }
    [HttpPost]
    public ActionResult Edit(Treat treat)
    {
      _db.Treats.Update(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      _db.Treats.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddFlavor(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Frosting");
      return View(thisTreat);
    }
    [HttpPost]
    public ActionResult AddFlavor(Treat treat, int flavorId)
    {
      #nullable enable
      FlavorTreatEntity? joinEntity = _db.FlavorTreatEntities.FirstOrDefault(join => (join.FlavorId == flavorId && join.TreatId == treat.TreatId));
      #nullable disable
      if (joinEntity == null && flavorId != 0)
      {
        _db.FlavorTreatEntities.Add(new FlavorTreatEntity() {FlavorId = flavorId, TreatId = treat.TreatId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = treat.TreatId });
    }
    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      FlavorTreatEntity joinEntry = _db.FlavorTreatEntities.FirstOrDefault(entry => entry.FlavorTreatEntityId == joinId);
      _db.FlavorTreatEntities.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    } 
  }
}