using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobManagement.Models
{
    public class Position
    {
        public int PositionID { get; set; }
        [Required]
        public string PositionName { get; set; }
        [Range(0, 9999999, ErrorMessage = "Wrong salary!")]
        public int Salary { get; set; }
        [RegularExpression(@"[A-Z][a-z\s]{1,20}", ErrorMessage = "Wrong location!")]
        public string Location { get; set; }
        public DateTime AddTime { get; set; }
        public string Description { get; set; }
    }
}
