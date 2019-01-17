using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintDepartment.Models.Repositories
{
    public interface ICommentRepository
    {
        List<Comment> Comments { get; }
        List<Comment> GetCommentsByComplaint(int id);
        bool AddComment(Comment comment);
        bool DeleteCommentById(int id);
        bool DeleteCommentsByComplaintID(int id);
    }
}
