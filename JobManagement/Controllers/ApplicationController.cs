using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobManagement.Models;
using JobManagement.Data;
using Microsoft.AspNetCore.Mvc;
using JobManagement.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobManagement.Controllers
{
    public class ApplicationController : Controller
    {
        private GenericUoW<JobApplication> applicationUoW;
        private GenericUoW<Position> positionUoW;

        public ApplicationController(GenericUoW<JobApplication> applicationUoW, GenericUoW<Position> positionUoW)
        {
            this.applicationUoW = applicationUoW;
            this.positionUoW = positionUoW;
        }

        public IActionResult Index() 
        {
            List<JobApplication> jobs = applicationUoW.Repository.GetAll();
            ViewData["jobs"] = jobs;
            return View();
        }

        public IActionResult New()
        {
            return View(new AddApplicationViewModel
            {
                Positions = positionUoW.Repository.GetAll().Select(c => c.PositionName)
            });
        }

        public IActionResult AddApplication(AddApplicationViewModel job)
        {
            JobApplication application = new JobApplication
            {
                FirstName = job.FirstName,
                LastName = job.LastName,
                ApplicationStatus = ApplicationStatus.PENDING,
                ApplyDate = DateTime.Now,
                PositionId = positionUoW.Repository.GetAll().Find(p => p.PositionName == job.Position).PositionID,
                PhoneNumber = job.PhoneNumber,
                Email = job.Email
            };


            applicationUoW.Repository.AddItem(application);
            applicationUoW.Save();

            return RedirectToAction("Index");
        }
    }
}