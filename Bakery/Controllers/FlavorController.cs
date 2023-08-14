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
    public ActionResult Edit(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }
    [HttpPost]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Flavors.Update(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      _db.Flavors.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddTreat(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Type");
      return View(thisFlavor);
    }
    [HttpPost]
    public ActionResult AddTreat(Flavor flavor, int treatId)
    {
      #nullable enable
      FlavorTreatEntity? joinEntity = _db.FlavorTreatEntities.FirstOrDefault(join => (join.TreatId == treatId && join.FlavorId == flavor.FlavorId));
      #nullable disable
      if (joinEntity == null && treatId != 0)
      {
        _db.FlavorTreatEntities.Add(new FlavorTreatEntity() {TreatId = treatId, FlavorId = flavor.FlavorId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = flavor.FlavorId });
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