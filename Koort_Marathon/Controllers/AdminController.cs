using Koort_Marathon.Data;
using Koort_Marathon.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Koort_Marathon.Controllers
{
    public class AdminController : Controller
    {
        private readonly Koort_MarathonContext _db;
        public AdminController(Koort_MarathonContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {


            var data = _db.Runner.OrderBy(x => x.Breaks).ToList();

            return View(data);

        }

        [HttpPost]
        public IActionResult Update(int id)
        {

            string fname = Request.Form["fname"];
            string lname = Request.Form["lname"];
            string stime = Request.Form["stime"];
            string ltime = Request.Form["ltime"];
            string breaks = Request.Form["breaks"];

            Runner rns = new Runner
            {
                id = id,
                FirstName = fname,
                LastName = lname,
                StartTime = DateTime.Parse(stime),
                EndTime = DateTime.Parse(ltime),
                Breaks = int.Parse(breaks)
            };

            _db.Update(rns);
            _db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
