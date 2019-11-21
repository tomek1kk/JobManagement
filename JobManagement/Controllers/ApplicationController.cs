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

        public ApplicationController(GenericUoW<JobApplication> applicationUoW)
        {
            this.applicationUoW = applicationUoW;
        }

        public IActionResult Index() 
        {
            List<JobApplication> jobs = applicationUoW.Repository.GetAll();
            ViewData["jobs"] = jobs;
            return View();
        }

        public IActionResult New()
        {
            return View();
        }

        public IActionResult AddApplication(AddApplicationViewModel job)
        {
            JobApplication application = new JobApplication
            {
                FirstName = job.FirstName,
                LastName = job.LastName,
                ApplicationStatus = ApplicationStatus.PENDING,
                ApplyDate = DateTime.Now,
                PositionId = 1
            };


            applicationUoW.Repository.AddItem(application);
            applicationUoW.Save();

            return RedirectToAction("Index");
        }
    }
}