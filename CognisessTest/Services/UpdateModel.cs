using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CognisessTest.Models;

namespace CognisessTest.Services
{
    public class UpdateModel : IUpdateModel
    {
        private string secondaryParameter = "10000";
        private long r = 0;

        public TestModel Updater(TestModel newModel)
        {
            //List<int> timeTaken = new List<int>();
            if (newModel.TestNumber == 0)
            {
                newModel.RandomNumber = GetRandomNumber(newModel);
                newModel.TestNumber++;

                return newModel;
            }
            else
            {
                //foreach (int x in newModel.TimesTaken) timeTaken.Add(x);
                if (newModel.Result == newModel.RandomNumber) newModel.Score += 10;
                newModel.RandomNumber = GetRandomNumber(newModel);
                newModel.TestNumber++;
                //newModel.TimesTaken = timeTaken.ToArray();

                return newModel;
            }
        }

        public string GetRandomNumber(TestModel newModel)
        {
            if (newModel.TestNumber == 0)
            {
                r = (new Random()).Next(100, (int)Convert.ToInt64(secondaryParameter)); //) + (new Random()).Next(100, (int)Convert.ToInt64(secondaryParameter)
                return r.ToString();
            }
            else
            {
                int[] arrayForLoop = new int[newModel.TestNumber];
                foreach (int i in arrayForLoop)
                {
                    secondaryParameter += "0";
                }
                if (secondaryParameter.Length < 11) r = (new Random()).Next(100, (int)Convert.ToInt64(secondaryParameter)); //) + (new Random()).Next(100, (int)Convert.ToInt64(secondaryParameter)
                else r = Convert.ToInt64(newModel.RandomNumber) * 17;
                return r.ToString();
            }
        }
    }
}
