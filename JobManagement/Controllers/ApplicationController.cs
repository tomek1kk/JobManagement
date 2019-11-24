using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobManagement.Models;
using JobManagement.Data;
using Microsoft.AspNetCore.Mvc;
using JobManagement.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;

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

        public IActionResult New(AddApplicationViewModel viewModel = null)
        {
            if (viewModel == null)
            {
                return View(new AddApplicationViewModel
                {
                    Positions = positionUoW.Repository.GetAll().Select(c => c.PositionName)
                });
            }
            else
            {
                viewModel.Positions = positionUoW.Repository.GetAll().Select(c => c.PositionName);
                return View(viewModel);
            }
        }

        public IActionResult AddApplication(AddApplicationViewModel job)
        {
            if (job.Id > 0) // editing existing application
            {
                var application = applicationUoW.Repository.GetItem(job.Id);
                application.FirstName = job.FirstName;
                application.LastName = job.LastName;
                application.PhoneNumber = job.PhoneNumber;
                application.Email = job.Email;
                application.PositionId = positionUoW.Repository.GetAll().Find(p => p.PositionName == job.Position).PositionID;

                applicationUoW.Repository.UpdateItem(application);
            }
            else
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
            }
            applicationUoW.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            JobApplication job = applicationUoW.Repository.GetItem(id);
            ApplicationDetailsViewModel model = new ApplicationDetailsViewModel
            {
                JobApplication = job,
                Position = positionUoW.Repository.GetItem(job.PositionId)
            };

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            JobApplication job = applicationUoW.Repository.GetItem(id);
            var model = new AddApplicationViewModel
            {
                Id = id,
                FirstName = job.FirstName,
                LastName = job.LastName,
                Email = job.Email,
                PhoneNumber = job.PhoneNumber,
                Position = positionUoW.Repository.GetItem(job.PositionId) != null ? positionUoW.Repository.GetItem(job.PositionId).PositionName : null
            };
            return RedirectToAction("New", new RouteValueDictionary(model));
        }
    }
}