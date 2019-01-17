using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ComplaintDepartment.Models;
using ComplaintDepartment.Models.Repositories;
using ComplaintDepartment.Models.View;
using Microsoft.AspNetCore.Authorization;

namespace ComplaintDepartment.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ICommentRepository CommentRepo { get; set; }
        public IComplaintRepository ComplaintRepo { get; set; }
        public HomeController(ICommentRepository commentRepository, IComplaintRepository complaintRepository)
        {
            this.CommentRepo = commentRepository;
            this.ComplaintRepo = complaintRepository;

        }
        [Authorize(Roles = "member")]
        public IActionResult Index()
        {
            return View(new CommentsAndComplaints() {
                Comments = this.CommentRepo, Complaints = this.ComplaintRepo
            });
        }
   
    }
}
