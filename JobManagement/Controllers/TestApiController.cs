using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobManagement.Controllers
{

    [ApiController]
    public class TestApiController : ControllerBase
    {
        [HttpGet]
        [Route("api/Test/GetAll")]
        public string GetAll()
        {
            return "dzialam";
        }
    }
}