using JobManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobManagement.ViewModels
{
    public class JobListViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ApplyDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ApplicationStatus { get; set; }
        public string Position { get; set; }

    }

}
