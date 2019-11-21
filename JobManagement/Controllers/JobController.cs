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
        private GenericUoW<JobApplication> applicationUoW;
        private GenericUoW<Position> positionUoW;

        public JobController(GenericUoW<JobApplication> applicationUoW, GenericUoW<Position> positionUoW)
        {
            this.applicationUoW = applicationUoW;
            this.positionUoW = positionUoW;
        }

        [HttpGet]
        [Route("api/[controller]/GetAll")]
        public IEnumerable<JobApplication> GetAll()
        {
            return applicationUoW.Repository.GetAll();
        }

        [HttpGet]
        [Route("api/[controller]/GetListViewModel")]
        public IEnumerable<JobListViewModel> GetListViewModel()
        {
            var applications = applicationUoW.Repository.GetAll();
            List<JobListViewModel> jobViews = new List<JobListViewModel>();
            for (int i = 0; i < applications.Count; i++)
            {
                jobViews.Add(new JobListViewModel
                {
                    FirstName = applications[i].FirstName,
                    LastName = applications[i].LastName,
                    ApplyDate = applications[i].ApplyDate,
                    ApplicationStatus = applications[i].ApplicationStatus == ApplicationStatus.ACCEPTED ? "Accepted" : 
                                        applications[i].ApplicationStatus == ApplicationStatus.PENDING ? "Pending" : "Rejected",
                    Position = positionUoW.Repository.GetItem(applications[i].PositionId).PositionName
                });
            }

            return jobViews;
        }

        [HttpGet]
        [Route("api/[controller]/Get/{id}")]
        public JobApplication Get(int id)
        {
            return applicationUoW.Repository.GetAll().Find(job => job.Id == id);
        }

        [HttpDelete]
        [Route("api/[Controller]/Delete/{id}")]
        public void Delete(int id)
        {
            applicationUoW.Repository.DeleteItem(applicationUoW.Repository.GetAll().Find(j => j.Id == id));
            applicationUoW.Save();
        }

        [HttpPut]
        [Route("api/[Controller]/Update")]
        public void Update([FromBody] JobApplication jobApplication)
        {
            applicationUoW.Repository.UpdateItem(jobApplication);
            applicationUoW.Save();
        }
    }
}