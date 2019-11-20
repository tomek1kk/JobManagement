using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobManagement.Data;
using JobManagement.Models;
using JobManagement.ViewModels;
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
        public JobListViewModel GetAll()
        {
            return new JobListViewModel(applicationUoW.ApplicationsRepository.GetAll());
        }

        [HttpGet]
        [Route("api/[controller]/Get/{id}")]
        public JobApplication Get(int id)
        {
            return applicationUoW.ApplicationsRepository.GetAll().Find(job => job.Id == id);
        }

        [HttpDelete]
        [Route("api/[Controller]/Delete/{id}")]
        public void Delete(int id)
        {
            applicationUoW.ApplicationsRepository.DeleteItem(applicationUoW.ApplicationsRepository.GetAll().Find(j => j.Id == id));
            applicationUoW.Save();
        }

        [HttpPut]
        [Route("api/[Controller]/Update")]
        public void Update([FromBody] JobApplication jobApplication)
        {
            applicationUoW.ApplicationsRepository.UpdateItem(jobApplication);
            applicationUoW.Save();
        }
    }
}