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
        [RegularExpression(@"[A-Z][a-z\s]{1,20}", ErrorMessage = "Wrong first name!")]
        public string FirstName { get; set; }
        [RegularExpression(@"[A-Z][a-z\s]{1,20}", ErrorMessage = "Wrong last name!")]
        public string LastName { get; set; }
        [RegularExpression(@"[0-9+]{9,13}", ErrorMessage = "Wrong phone number!")]
        public string PhoneNumber { get; set; }
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Wrong email!")]
        public string Email { get; set; }
        public IEnumerable<string> Positions { get; set; }
        public string Position { get; set; }
        public int Id { get; set; }
    }
}
