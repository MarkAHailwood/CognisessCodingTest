using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognisessTest.Models
{
    public class TestModel
    {
        public string RandomNumber { get; set; }
        public int TestNumber { get; set; }
        public int Score { get; set; }
        public string Result { get; set; }
        public int TimeTaken { get; set; }
        public int[] TimesTaken { get; set; }
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
