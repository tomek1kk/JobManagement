using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobManagement.Models
{
    public class Position
    {
        public virtual int PositionID { get; set; }
        public virtual string PositionName { get; set; }
        public int Salary { get; set; }
        public string Location { get; set; }
        public DateTime AddTime { get; set; }
        public string Description { get; set; }
    }
}
