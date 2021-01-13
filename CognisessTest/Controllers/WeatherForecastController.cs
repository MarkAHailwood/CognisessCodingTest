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
    public class WeatherForecastController : ControllerBase
    {
        private readonly IUpdateModel updateModel;

        public WeatherForecastController(IUpdateModel _updateModel)
        {
            updateModel = _updateModel;
        }

        [HttpPost]
        public TestModel Post(TestModel newModel)
        {
            return updateModel.Updater(newModel);
        }

        [HttpGet]
        public TestModel Get()
        {
            var virginModel = new TestModel();
            return virginModel;
        }
    }
}
