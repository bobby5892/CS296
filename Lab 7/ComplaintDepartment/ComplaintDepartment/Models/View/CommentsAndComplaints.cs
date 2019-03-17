using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComplaintDepartment.Models.Repositories;
namespace ComplaintDepartment.Models.View
{
    public class CommentsAndComplaints
    {
        public IComplaintRepository Complaints { get; set; }
        public ICommentRepository Comments { get; set; }
    }
}
