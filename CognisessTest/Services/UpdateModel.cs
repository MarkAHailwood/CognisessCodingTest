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
        private string secondaryParameter = "10000";
        private long r = 0;

        public TestModel Updater(TestModel newModel)
        {
            List<int> timeTaken = new List<int>();
            if (newModel.TestNumber == 0)
            {
                r = (new Random()).Next(100, (int)Convert.ToInt64(secondaryParameter)) + (new Random()).Next(100, (int)Convert.ToInt64(secondaryParameter));
                rConverted = r.ToString();
                newModel.RandomNumber = rConverted;
                newModel.TestNumber++;

                return newModel;
            }
            else
            {
                if(newModel.TimesTaken[0] > 0) foreach(int x in newModel.TimesTaken) timeTaken.Add(x);
                if (newModel.Result == newModel.RandomNumber && newModel.Result != "") newModel.Score += 10;
                int[] arrayForLoop = new int[newModel.TestNumber];
                foreach(int i in arrayForLoop)
                {
                    secondaryParameter += "0";
                }
                if (secondaryParameter.Length < 10) r = (new Random()).Next(100, (int)Convert.ToInt64(secondaryParameter)) + (new Random()).Next(100, (int)Convert.ToInt64(secondaryParameter));
                else r = Convert.ToInt64(newModel.RandomNumber) * 15;
                rConverted = r.ToString();
                newModel.RandomNumber = rConverted;
                newModel.TestNumber++;
                newModel.TimesTaken = timeTaken.ToArray();

                return newModel;
            }
        }
    }
}
