using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintDepartment.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int ComplaintID { get; set; }
        public string Contents { get; set;  }

    }
}
