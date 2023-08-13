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
    }
}