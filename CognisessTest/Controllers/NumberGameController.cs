using CognisessTest.Models;
using CognisessTest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognisessTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberGameController : ControllerBase
    {
        private readonly IUpdateModel updateModel;

        public NumberGameController(IUpdateModel _updateModel)
        {
            updateModel = _updateModel;
        }

        [HttpPost]
        public TestModel Post(TestModel newModel)
        {
            return updateModel.Updater(newModel);
        }
    }
}
