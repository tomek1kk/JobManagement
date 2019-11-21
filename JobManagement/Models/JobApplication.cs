using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobManagement.Models
{
    public class JobApplication
    {
        public int Id { get; set; }
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
        public DateTime ApplyDate { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        [ForeignKey("Position")]
        public int PositionId { get; set; }
    }
}
