﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognisessTest.Models
{
    public class TestModel
    {
        public string RandomNumber { get; set; }
        public string PreValue { get; set; }
        public int TestNumber { get; set; }
        public int Score { get; set; }
        public string UserName { get; set; }
        public string Result { get; set; }
        public bool Complete { get; set; }
        public int TimeTaken { get; set; }
        public int[] TimesTaken { get; set; }
        public TestModel()
        {
            RandomNumber = "";
            TestNumber = 0;
            Score = 0;
            UserName = "";
            Result = "";
            Complete = false;
            TimeTaken = 0;
        }
    }
}
