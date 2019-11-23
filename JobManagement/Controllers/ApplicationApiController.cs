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
    public class ApplicationApiController : ControllerBase
    {
        private GenericUoW<JobApplication> applicationUoW;
        private GenericUoW<Position> positionUoW;

        public ApplicationApiController(GenericUoW<JobApplication> applicationUoW, GenericUoW<Position> positionUoW)
        {
            this.applicationUoW = applicationUoW;
            this.positionUoW = positionUoW;
        }

        [HttpGet]
        [Route("api/Application/GetAll")]
        public IEnumerable<JobApplication> GetAll()
        {
            return applicationUoW.Repository.GetAll();
        }

        [HttpGet]
        [Route("api/Application/GetListViewModel")]
        public IEnumerable<JobListViewModel> GetListViewModel()
        {
            var applications = applicationUoW.Repository.GetAll();
            List<JobListViewModel> jobViews = new List<JobListViewModel>();



            for (int i = 0; i < applications.Count; i++)
            {
                var position = positionUoW.Repository.GetItem(applications[i].PositionId);
                
                jobViews.Add(new JobListViewModel
                {
                    Id = applications[i].Id,
                    FirstName = applications[i].FirstName,
                    LastName = applications[i].LastName,
                    ApplyDate = applications[i].ApplyDate,
                    Email = applications[i].Email,
                    PhoneNumber = applications[i].PhoneNumber,
                    ApplicationStatus = applications[i].ApplicationStatus == ApplicationStatus.ACCEPTED ? "Accepted" :
                                        applications[i].ApplicationStatus == ApplicationStatus.PENDING ? "Pending" : "Rejected",
                    Position = position != null ? position.PositionName : "not found"
                });
            }

            return jobViews;
        }

        [HttpGet]
        [Route("api/Application/Get/{id}")]
        public JobApplication Get(int id)
        {
            return applicationUoW.Repository.GetAll().Find(job => job.Id == id);
        }

        [HttpDelete]
        [Route("api/Application/Delete/{id}")]
        public void Delete(int id)
        {
            applicationUoW.Repository.DeleteItem(applicationUoW.Repository.GetAll().Find(j => j.Id == id));
            applicationUoW.Save();
        }

        [HttpPut]
        [Route("api/Application/Update")]
        public void Update([FromBody] JobListViewModel jobApplication)
        {

            JobApplication job = applicationUoW.Repository.GetItem(jobApplication.Id);

            job.Id = jobApplication.Id;
            job.FirstName = jobApplication.FirstName;
            job.LastName = jobApplication.LastName;
            job.Email = jobApplication.Email;
            job.PhoneNumber = jobApplication.PhoneNumber;
            
            applicationUoW.Repository.UpdateItem(job);
            applicationUoW.Save();
        }
    }
}