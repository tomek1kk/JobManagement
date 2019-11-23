using JobManagement.Data;
using JobManagement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobManagement.ViewModels
{
    public class AddApplicationViewModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{5,40}$", ErrorMessage = "Wrong first name!")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Positions { get; set; }
        public string Position { get; set; }
        public int Id { get; set; }
    }
}
