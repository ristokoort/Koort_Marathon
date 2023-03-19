using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Koort_Marathon.Models;

namespace Koort_Marathon.Data
{
    public class Koort_MarathonContext : DbContext
    {
        public Koort_MarathonContext (DbContextOptions<Koort_MarathonContext> options)
            : base(options)
        {
        }

        public DbSet<Koort_Marathon.Models.Runner> Runner { get; set; }

        public DbSet<RunnersMaster> runnersMaster { get; set; }
    }
}
