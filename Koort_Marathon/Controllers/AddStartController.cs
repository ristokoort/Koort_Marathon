using Koort_Marathon.Data;
using Koort_Marathon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koort_Marathon.Controllers
{
    public class AddStartController : Controller
    {
        private readonly Koort_MarathonContext _db;
        public AddStartController(Koort_MarathonContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Runner> data = _db.Runner.ToList();

            return View(data);
        }


        public IActionResult LoadRunners()
        {

            _db.Database.ExecuteSqlRaw("delete from runners");
            _db.Database.ExecuteSqlRaw("insert into runners(firstname,lastname,breaks) select firstname,lastname,0 from runnersMaster");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddStartTime()
        {
           

            string stime = Request.Form["starttime"];


            await _db.Runner.ForEachAsync(x => x.StartTime = DateTime.Parse(stime));
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]


        public IActionResult DeleteRunner(int id)
        {

            var data = _db.Runner.Where(x => x.id == id).FirstOrDefault();
            _db.Remove(data);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

