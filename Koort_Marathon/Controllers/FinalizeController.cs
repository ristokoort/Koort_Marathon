using Koort_Marathon.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Koort_Marathon.Controllers
{
    public class FinalizeController : Controller
    {
        private readonly Koort_MarathonContext _db;

        public FinalizeController(Koort_MarathonContext db)
        {

            _db = db;

        }

        public IActionResult Index()
        {
            var data = _db.Runner.Where(x => x.Breaks == 2).ToList();

            return View(data);
        }

        public IActionResult UpdateFinalize(int id)
        {
            string ftime = Request.Form["endtime"];
            var data = _db.Runner.Where(x => x.id == id).FirstOrDefault();
            if (ftime != null)
            {
                data.EndTime = DateTime.Parse(ftime);
                _db.Update(data);
                _db.SaveChanges();

            }
            return RedirectToAction("Index");
        }


    }
}