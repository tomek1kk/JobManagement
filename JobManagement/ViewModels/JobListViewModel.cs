using JobManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobManagement.ViewModels
{
    public class JobListViewModel
    {
        public JobListViewModel()
        {

        }

        public JobListViewModel(IEnumerable<JobApplication> jobApplications)
        {
            JobApplications = jobApplications;
        }

        public IEnumerable<JobApplication> JobApplications { get; set; }
    }
}
