using CognisessTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognisessTest.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TestContext context)
        {
            context.Database.EnsureCreated();

            if (context.TestModels.Any())
            {
                return;
            }

            var test = new TestModel[]
            {
                new TestModel { RandomNumber = "1234", TestNumber = 3, Score = 5, TimeTaken = 3, TimesTaken = new int[] {1,2,3} }
            };

            foreach(var mod in test)
            {
                context.Add(mod);
            }
            context.SaveChanges();
        }
    }
}
