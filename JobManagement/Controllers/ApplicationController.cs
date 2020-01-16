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
using SendGrid.Helpers.Mail;
using SendGrid;

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

        public async Task<IActionResult> AddApplication(AddApplicationViewModel job)
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
                //var client = new SendGridClient("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");
                var client = new SendGridClient("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");
                var msg = new SendGridMessage();

                msg.SetFrom(new EmailAddress("tomek1kkgwcostam@gmail.com", "tomek1kk"));

                var recipients = new List<EmailAddress>
                {
                    //new EmailAddress("holdenkold@gmail.com", "Holden Kold"),
                    new EmailAddress("tomek1kkgw@gmail.com", "Tom Kostowski"),
                };
                msg.AddTos(recipients);

                msg.SetSubject("New application!");

                msg.AddContent(MimeType.Text, "Hello World plain text!");
                msg.AddContent(MimeType.Html, "<p>New job application added! " +
                    job.FirstName + " " + job.LastName + " just applied." +
                    "Check it asap!</p>");
                var response = await client.SendEmailAsync(msg);

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