using System;

namespace Koort_Marathon.Models
{
    public class Runner
    {
        //1,Toomas,Tamm,13.00,15.00,2
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public int BreakTime { get; set; }
    }
}
