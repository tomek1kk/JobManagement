using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobManagement.Data;
using JobManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobManagement.Controllers
{
    [ApiController]
    public class JobController : ControllerBase
    {
        private ApplicationUoW applicationUoW;

        public JobController(ApplicationUoW applicationUoW)
        {
            this.applicationUoW = applicationUoW;
        }

        [HttpGet]
        [Route("api/[controller]/GetAll")]
        public IEnumerable<JobApplication> GetAll()
        {
            return applicationUoW.ApplicationsRepository.GetAll();
        }
    }
}