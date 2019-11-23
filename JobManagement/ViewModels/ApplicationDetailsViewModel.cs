using JobManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobManagement.ViewModels
{
    public class ApplicationDetailsViewModel
    {
        public JobApplication JobApplication { get; set; }
        public Position Position { get; set; }
    }
}
