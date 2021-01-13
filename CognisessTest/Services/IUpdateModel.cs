using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CognisessTest.Models;

namespace CognisessTest.Services
{
    public interface IUpdateModel
    {
        public TestModel Updater(TestModel newModel);
    }
}
