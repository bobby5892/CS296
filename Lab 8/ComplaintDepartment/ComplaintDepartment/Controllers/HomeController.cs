using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ComplaintDepartment.Models;
using ComplaintDepartment.Models.Repositories;
using ComplaintDepartment.Models.View;
namespace ComplaintDepartment.Controllers
{
    public class HomeController : Controller
    {
        public ICommentRepository CommentRepo { get; set; }
        public IComplaintRepository ComplaintRepo { get; set; }
        public HomeController(ICommentRepository commentRepository, IComplaintRepository complaintRepository)
        {
            this.CommentRepo = commentRepository;
            this.ComplaintRepo = complaintRepository;

        }
        public IActionResult Index()
        {
            return View(new CommentsAndComplaints() {
                Comments = this.CommentRepo, Complaints = this.ComplaintRepo
            });
        }
   
    }
}
