using Koort_Marathon.Data;
using Koort_Marathon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Koort_Marathon.Controllers
{
    public class RunnersController : Controller
    {
        private readonly Koort_MarathonContext _db;
        public RunnersController(Koort_MarathonContext db)
        {

            _db = db;

        }
       


        [HttpPost]
        public IActionResult Addrunners()
        {

            RunnersMaster runner = new RunnersMaster
            {
                FirstName = Request.Form["firstname"],
                LastName = Request.Form["lastname"],

            };

            _db.Add(runner);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
