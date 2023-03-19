using Koort_Marathon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Koort_Marathon.Data;
using System.Linq;

namespace Koort_Marathon.Controllers
{
    public class AwardsController : Controller
    {
        private readonly Koort_MarathonContext _db;
        public AwardsController(Koort_MarathonContext db)
        {

            _db = db;

        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Award> awds = new List<Award>();

            var data = _db.Runner.Where(x => x.Breaks == 2 && x.EndTime != null).ToList();

            for (int x = 0; x < data.Count; x++)
            {
                TimeSpan tm = ((TimeSpan)(data[x].EndTime - data[x].StartTime));

                Award awd = new Award
                {
                    FirstName = data[x].FirstName,
                    LastName = data[x].LastName,
                    StartTime = data[x].StartTime,
                    EndTime = data[x].EndTime,
                    time = tm.TotalSeconds

                };

                awds.Add(awd);
            }

            var passData = awds.OrderBy(x => x.time).ToList();

            return View(passData);
        }



    }
}
