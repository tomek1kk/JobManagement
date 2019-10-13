using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobManagement.Models;
using JobManagement.Data;
using Microsoft.AspNetCore.Mvc;

namespace JobManagement.Controllers
{
    public class ApplicationController : Controller
    {
        private ApplicationUoW applicationUoW;

        public ApplicationController(ApplicationUoW applicationUoW)
        {
            this.applicationUoW = applicationUoW;
        }

        public IActionResult Index() 
        {
            List<JobApplication> jobs = applicationUoW.ApplicationsRepository.GetAll();
            ViewData["jobs"] = jobs;
            return View();
        }

        public IActionResult New()
        {
            return View(new JobApplication());
        }

        public IActionResult AddApplication(JobApplication job)
        {
            applicationUoW.ApplicationsRepository.AddItem(job);
            applicationUoW.Save();

            return RedirectToAction("Index");
        }
    }
}