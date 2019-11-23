using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobManagement.ViewModels
{
    public class PositionViewModel
    {
        public int PositionId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PositionName { get; set; }
        public int Salary { get; set; }
        public string Location { get; set; }
    }
}
