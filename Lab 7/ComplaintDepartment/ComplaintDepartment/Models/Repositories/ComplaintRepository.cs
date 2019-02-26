using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintDepartment.Models.Repositories
{
    public class ComplaintRepository : IComplaintRepository
    {
        AppDBContext context;
        public List<Complaint> Complaints { get { return context.Complaints.ToList<Complaint>(); } }
        public ComplaintRepository(AppDBContext context){
            this.context = context;
        }
        public bool AddComplaint(Complaint complaint)
        {
            try
            {
                this.context.Complaints.Add(complaint);
                this.context.SaveChanges();
                return true;
            }
            catch(Exception ex) {
                ex = null;
            }
            return false;
        }
        public bool MarkComplete(Complaint complaint)
        {
            try { 
                var result = context.Complaints.SingleOrDefault(c => c.ID == complaint.ID);
                if (result != null)
                {
                    result.Completed = !result.Completed;
                }
                this.context.SaveChanges();
            }
            catch(Exception ex)
            {
                ex = null;
            }
            return false;
        }
        public List<Complaint> GetOpenComplaints()
        {
            List<Complaint> openComplaints = new List<Complaint>();
           openComplaints =  Complaints.FindAll((complaint) => {
                if(complaint.Completed == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });
            return openComplaints;
        }
        public List<Complaint> GetClosedComplaints()
        {
            List<Complaint> closedComplaints = new List<Complaint>();
            closedComplaints = Complaints.FindAll((complaint) => {
                if (complaint.Completed == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            });
            return closedComplaints;
        }
        public bool ToggleComplete(int id)
        {
            bool madeChange = false;
             Complaints.First<Complaint>(
                (c) =>
                {
                    if (c.ID == id)
                    {
                        c.Completed = !c.Completed;
                        madeChange = true;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });
            this.context.SaveChanges();
            return madeChange;

        }
        
        public List<Complaint> Search(string phrase)
        {
            List<Complaint> Results = new List<Complaint>(
            this.Complaints.FindAll( (c) =>
            {
                if (c.Contents.Contains(phrase))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
           ));
           return Results;
        }
        public Complaint Search(int id)
        {
            Complaint result = null;
            this.Complaints.Find((c) =>
           {
               if (c.ID == id)
               {
                   result = c;
                   return true;
               }
               else{
                   return false;
               }
        
           });
            return result; ;
        }
        public bool DeleteComplaintByID(int id)
        {
            Complaint toDelete = this.Search(id);
            if (toDelete != null){
                this.context.Complaints.Remove(toDelete);
                this.context.SaveChanges();
                /* Lets Also Delete the Comments */
                
                return true;
            }
            return false;
        }
        public bool EditComplaint(Complaint complaint)
        {
            bool madeChange = false;
            Complaints.FindAll((c) =>
            {
                if (c.ID == complaint.ID)
                {
                    c.Contents = complaint.Contents;
                    c.Completed = complaint.Completed;
                    c.Create = complaint.Create;
                    this.context.SaveChanges();
                    madeChange = true;
                    return true;
                }
                else
                {
                    return false;
                }
            });
            return madeChange;
        }
    }
}
