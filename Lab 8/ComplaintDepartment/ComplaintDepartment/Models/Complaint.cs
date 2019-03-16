using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintDepartment.Models
{
    public class Complaint
    {
        public int ID { get; set; }
        public DateTime Create { get; set; }
        public string Contents { get; set; }
        public bool Completed { get; set; }
    }
}
