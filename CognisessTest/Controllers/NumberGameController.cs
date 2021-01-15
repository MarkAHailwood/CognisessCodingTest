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
        public async Task<TestModel> PostAsync(TestModel newModel)
        {
            return await updateModel.Updater(newModel);
        }

        [HttpGet]
        public TestModel Get()
        {
            var virginModel = new TestModel();
            return virginModel;
        }
    }
}
