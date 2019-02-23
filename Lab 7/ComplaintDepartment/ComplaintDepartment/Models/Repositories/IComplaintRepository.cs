using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintDepartment.Models.Repositories
{
    public interface IComplaintRepository
    {
        List<Complaint> Complaints { get; }
        bool AddComplaint(Complaint complaint);
        bool MarkComplete(Complaint complaint);
        List<Complaint> GetClosedComplaints();
        List<Complaint> GetOpenComplaints();
        bool ToggleComplete(int id);
        List<Complaint> Search(string phrase);
        Complaint Search(int id);
        bool DeleteComplaintByID(int id);
        bool EditComplaint(Complaint complaint);


    }
}
