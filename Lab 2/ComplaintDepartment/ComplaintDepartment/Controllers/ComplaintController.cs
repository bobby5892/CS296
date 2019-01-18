﻿using System;
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
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "member,admin")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [Authorize(Roles = "member,admin")]
        [HttpPost]
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
        [AllowAnonymous]
        public IActionResult List()
        {
            CommentsAndComplaints viewModel = new CommentsAndComplaints() { Comments = this.CommentRepo, Complaints = this.ComplaintRepo };
            return View(viewModel);
        }
        [Authorize(Roles = "member,admin")]
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }
        [Authorize(Roles = "member,admin")]
        [HttpPost]
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
        [Authorize(Roles = "member,admin")]
        public IActionResult GetComplaint(int id)
        {
            ComplaintAndComments complaintAndComments = new ComplaintAndComments()
            {
                Complaint = this.ComplaintRepo.Search(id),
                Comments = this.CommentRepo.GetCommentsByComplaint(id)
            };
            return View(complaintAndComments);
        }
        [Authorize(Roles = "member,admin")]
        public JsonResult ToggleComplete(int id)
        {
            return Json(this.ComplaintRepo.ToggleComplete(id));
        }
        [Authorize(Roles = "member,admin")]
        public JsonResult AddComment(int id, string content)
        {
            return Json(
                this.CommentRepo.AddComment(
                    new Comment() { ComplaintID = id, Contents = content }
                    )
                );
        }
        [Authorize(Roles = "member,admin")]
        public JsonResult DeleteCommentById(int id)
        {
            return Json(
               this.CommentRepo.DeleteCommentById(id)
            );
        }
        [Authorize(Roles = "member,admin")]
        public JsonResult DeleteComplaintByID(int id)
        {
            return Json(
                (this.CommentRepo.DeleteCommentsByComplaintID(id),
                this.ComplaintRepo.DeleteComplaintByID(id))
            );
        }
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
        [AllowAnonymous]
        public JsonResult GetComplaints()
        {
            return Json(this.ComplaintRepo.Complaints.ToArray());
        }
        [AllowAnonymous]
        public JsonResult GetComments()
        {
            return Json(this.CommentRepo.Comments.ToArray());
        }
    }
}