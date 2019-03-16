using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintDepartment.Models.View
{
    public class ComplaintAndComments
    {
        public Complaint Complaint { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
