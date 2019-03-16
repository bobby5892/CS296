using System;
using System.Collections.Generic;
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
    public class ComplaintController : Controller
    {
        public ICommentRepository CommentRepo { get; set; }
        public IComplaintRepository ComplaintRepo{ get; set; }
        public ComplaintController(ICommentRepository commentRepository, IComplaintRepository complaintRepository)
        {
            this.CommentRepo = commentRepository;
            this.ComplaintRepo = complaintRepository;

        }
        [Authorize(Roles = "member,admin")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "member,admin")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "member,admin")]
        public IActionResult Add(string contents)
        {
            Complaint newComplaint = new Complaint()
            {
                Completed = false,
                Contents = contents,
                Create = DateTime.Now
            };
            this.ComplaintRepo.AddComplaint(newComplaint);
            return View("ComplaintAdded",newComplaint);
        }
        [Authorize(Roles = "member,admin")]
        public IActionResult List()
        {
            CommentsAndComplaints viewModel = new CommentsAndComplaints() { Comments = this.CommentRepo, Complaints = this.ComplaintRepo };
            return View(viewModel);
        }
        [HttpGet]
        [Authorize(Roles = "member,admin")]
        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "member,admin")]
        public IActionResult Search(string search)
        {
            if(search.Length == 0)
            {
                search = "42";
            }
            return View("SearchResults",this.ComplaintRepo.Search(search));
        }
        [Authorize(Roles = "member,admin")]
        public IActionResult Comment()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "member,admin")]
        public JsonResult GetComplaint(int id)
        {
            return Json(this.ComplaintRepo.Search(id));
        }
        [HttpPatch]
        [Authorize(Roles = "member,admin")]
        public JsonResult ToggleComplete(int id)
        {
            return Json(this.ComplaintRepo.ToggleComplete(id));
        }
        [HttpPost]
        [Authorize(Roles = "member,admin")]
        public JsonResult AddComment(int id, string content)
        {
            return Json(
                this.CommentRepo.AddComment(
                    new Comment() { ComplaintID = id, Contents = content }
                    )
                );
        }
        [HttpPut]
        [Authorize(Roles = "member,admin")]
        public JsonResult EditComplaint (int id, DateTime create, string contents, bool completed)
        {
            return Json(
                this.ComplaintRepo.EditComplaint(new Complaint() { ID = id, Create = create, Contents = contents, Completed = completed })
            );
        }
        [HttpDelete]
        [Authorize(Roles = "member,admin")]
        public JsonResult DeleteCommentById(int id)
        {
            return Json(
               this.CommentRepo.DeleteCommentById(id)
            );
        }
        [HttpDelete]
        [Authorize(Roles = "member,admin")]
        public JsonResult DeleteComplaintByID(int id)
        {
            return Json(
                (this.CommentRepo.DeleteCommentsByComplaintID(id),
                this.ComplaintRepo.DeleteComplaintByID(id))
            );
        }
        [HttpPost]
        [Authorize(Roles = "member,admin")]
        public JsonResult AddComplaint(string contents)
        {
            Complaint newComplaint = new Complaint()
            {
                Completed = false,
                Contents = contents,
                Create = DateTime.Now
            };
            return Json(this.ComplaintRepo.AddComplaint(newComplaint));
           
        }
        [HttpGet]
        [Authorize(Roles = "member,admin")]
        public JsonResult GetComplaints()
        {
            return Json(this.ComplaintRepo.Complaints.ToArray());
        }
        [HttpGet]
        [Authorize(Roles = "member,admin")]
        public JsonResult GetComments()
        {
            return Json(this.CommentRepo.Comments.ToArray());
        }
        [HttpPost]
        [Authorize(Roles = "member,admin")]
        public JsonResult GetCommentsByComplaint(int id)
        {
            var thing = this.CommentRepo.GetCommentsByComplaint(id).ToArray();
            return Json(thing);
        }
    }
}