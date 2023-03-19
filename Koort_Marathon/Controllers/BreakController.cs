using Koort_Marathon.Data;
using Koort_Marathon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Koort_Marathon.Controllers
{
    public class BreakController : Controller
    {
        private readonly Koort_MarathonContext _db;
        public BreakController(Koort_MarathonContext db)
        {

            _db = db;

        }

        [HttpPost]
        public IActionResult UpdateRunnerBreaks(int id)
        {
            string brk = Request.Form["breaks"];

            var data = _db.Runner.Where(x => x.id == id).FirstOrDefault();
            data.Breaks = int.Parse(brk);

            _db.Update(data);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {

            IEnumerable<Runner> data = _db.Runner.ToList();

            return View(data);
        }
    }
}