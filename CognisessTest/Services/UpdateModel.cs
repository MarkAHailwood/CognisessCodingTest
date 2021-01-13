﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CognisessTest.Models;

namespace CognisessTest.Services
{
    public class UpdateModel : IUpdateModel
    {
        private string rConverted = "";
        private string preValue = "";
        private string secondaryParameter = "10000";
        private long r = 0;
        public List<int> timeTaken = new List<int>();

        public TestModel Updater(TestModel newModel)
        {
            if(newModel.TestNumber == 0)
            {
                r = (new Random()).Next(100, (int)Convert.ToInt64(secondaryParameter)) + (new Random()).Next(100, (int)Convert.ToInt64(secondaryParameter));
                rConverted = r.ToString();
                newModel.PreValue = newModel.RandomNumber;
                newModel.RandomNumber = rConverted;
                newModel.TestNumber++;

                return newModel;
            }
            else if(newModel.Complete == true)
            {
                if (newModel.Result == rConverted) newModel.Score += 10;
                newModel.TestNumber++;
                newModel.TimesTaken = timeTaken.ToArray();
                return newModel;
            }
            else
            {
                timeTaken.Add(newModel.TimeTaken);
                if (newModel.Result == newModel.RandomNumber && newModel.Result != "") newModel.Score += 10;
                int[] arrayForLoop = new int[newModel.TestNumber];
                foreach(int i in arrayForLoop)
                {
                    secondaryParameter += "0";
                }
                if (secondaryParameter.Length < 10) r = (new Random()).Next(100, (int)Convert.ToInt64(secondaryParameter)) + (new Random()).Next(100, (int)Convert.ToInt64(secondaryParameter));
                else r = Convert.ToInt64(newModel.RandomNumber) * 15;
                rConverted = r.ToString();
                newModel.PreValue = newModel.RandomNumber;
                newModel.RandomNumber = rConverted;
                newModel.TestNumber++;
                newModel.TimesTaken = timeTaken.ToArray();

                return newModel;
            }
        }
    }
}
