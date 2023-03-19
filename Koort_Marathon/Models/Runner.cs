using System;
using System.ComponentModel.DataAnnotations;

namespace Koort_Marathon.Models
{
    public class Runner
    {
        [Key]
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Breaks { get; set; }

        [DataType(DataType.Time)]
        public DateTime? StartTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime? EndTime { get; set; }
    }
}
