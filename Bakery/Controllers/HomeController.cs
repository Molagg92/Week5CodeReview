using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Bakery.Models;

namespace Bakery.Controllers
{
    public class HomeController : Controller
    {
           private readonly BakeryContext _db;

      public HomeController(BakeryContext db)
      {
        _db = db;
      }

      [HttpGet("/")]
      public ActionResult Index()
      { 
        // Flavor[] flavs =_db.Flavors.ToArray();
        // Treat[] tres = _db.Treats.ToArray();
        // Dictionary<string,object[]> model = new Dictionary<string, object[]>();
        // model.Add("flavors", flavs);
        // model.Add("treats", tres);
        // return View(model);
        return View();
      }

    }
}
