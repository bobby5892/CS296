using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComplaintDepartment.Models;
namespace ComplaintDepartment.Models.Repositories
{
    public class CommentRepository :ICommentRepository
    {
        AppDBContext context;

        public List<Comment> Comments { get { return this.context.Comments.ToList<Comment>();  }  }
        public CommentRepository(AppDBContext context)
        {
            this.context = context;
        }


        public bool AddComment (Comment comment)
        {
            if(comment.Contents.Length > 0) { 
                this.context.Comments.Add(comment);
                this.context.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Comment> GetCommentsByComplaint(int id)
        {
           return Comments.FindAll((c) =>
           {
               if(c.ComplaintID == id)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           });
        }
        public bool DeleteCommentById(int id)
        {
            
            bool found = false;
            Comment comment = null;
            // Search for it
            Comments.Find((c) =>
            {
                if (c.ID == id)
                {
                    found = true;
                    comment = c;
                    
                    return true;
                }
                else
                {
                    return false;
                }
            });
            if (found)
            {
                if (comment != null)
                {
                    this.context.Comments.Remove(comment);
                    this.context.SaveChanges();
                }
            }
            return false;

        }
        public bool DeleteCommentsByComplaintID(int id)
        {

            bool found = false;
            List<Comment> comments = new List<Comment>();
            // Search for it
            Comments.FindAll((c) =>
            {
                if (c.ComplaintID == id)
                {
                    found = true;
                    comments.Add(c);

                    return true;
                }
                else
                {
                    return false;
                }
            });
            if (found)
            {
                if (comments != null)
                {
                    comments.ForEach((comment => {
                        this.context.Comments.Remove(comment);
                    }));
                    this.context.SaveChanges();
                }
            }
            return false;

        }
    }
}
