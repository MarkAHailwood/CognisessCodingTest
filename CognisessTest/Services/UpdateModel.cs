using System;
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
        private string secondaryParameter = "1000";
        public TestModel Updater(TestModel newModel)
        {
            long r = 0;
            string r2 = "";

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
                return newModel;
            }
            else
            {
                if (newModel.Result == newModel.RandomNumber || newModel.Result == newModel.PreValue) newModel.Score += 10;
                int[] arrayForLoop = new int[newModel.TestNumber];
                foreach(int i in arrayForLoop)
                {
                    secondaryParameter += "0";
                }
                r = (new Random()).Next(100, (int)Convert.ToInt64(secondaryParameter)) + (new Random()).Next(100, (int)Convert.ToInt64(secondaryParameter));
                rConverted = r.ToString();
                newModel.PreValue = newModel.RandomNumber;
                newModel.RandomNumber = rConverted;
                newModel.TestNumber++;

                return newModel;
            }
        }
    }
}
