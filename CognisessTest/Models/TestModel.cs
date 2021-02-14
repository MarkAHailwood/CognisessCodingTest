using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CognisessTest.Models
{
    public class TestModel
    {
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public string RandomNumber { get; set; }
        [NotMapped]
        public int TestNumber { get; set; }
        public int Score { get; set; }
        [NotMapped]
        public string Result { get; set; }
        [NotMapped]
        public int TimeTaken { get; set; }
        [NotMapped]
        public int[] TimesTaken { get; set; }
        public string TimesTakenString
        {
            get
            {
                var timeS = string.Join(",", TimesTaken);
                return timeS;
            }
            set { TimesTakenString = string.Join(",", TimesTaken); }
        }
    
        public TestModel()
        {
            RandomNumber = "";
            TestNumber = 0;
            Score = 0;
            Result = "";
            TimeTaken = 0;
        }
    }
}
