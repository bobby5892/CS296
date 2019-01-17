﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ComplaintDepartment.Models;
using ComplaintDepartment.Models.Repositories;
using ComplaintDepartment.Models.View;
namespace ComplaintDepartment.Controllers
{
    
    public class ComplaintController : Controller
    {
        public ICommentRepository CommentRepo { get; set; }
        public IComplaintRepository ComplaintRepo{ get; set; }
        public ComplaintController(ICommentRepository commentRepository, IComplaintRepository complaintRepository)
        {
            this.CommentRepo = commentRepository;
            this.ComplaintRepo = complaintRepository;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
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
        public IActionResult List()
        {
            CommentsAndComplaints viewModel = new CommentsAndComplaints() { Comments = this.CommentRepo, Complaints = this.ComplaintRepo };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Search(string search)
        {
            if(search.Length == 0)
            {
                search = "42";
            }
            return View("SearchResults",this.ComplaintRepo.Search(search));
        }
       
      
        public IActionResult Comment()
        {
            return View();
        }
        public IActionResult GetComplaint(int id)
        {
            ComplaintAndComments complaintAndComments = new ComplaintAndComments()
            {
                Complaint = this.ComplaintRepo.Search(id),
                Comments = this.CommentRepo.GetCommentsByComplaint(id)
            };
            return View(complaintAndComments);
        }
        public JsonResult ToggleComplete(int id)
        {
            return Json(this.ComplaintRepo.ToggleComplete(id));
        }
        public JsonResult AddComment(int id, string content)
        {
            return Json(
                this.CommentRepo.AddComment(
                    new Comment() { ComplaintID = id, Contents = content }
                    )
                );
        }
        public JsonResult DeleteCommentById(int id)
        {
            return Json(
               this.CommentRepo.DeleteCommentById(id)
            );
        }
        public JsonResult DeleteComplaintByID(int id)
        {
            return Json(
                (this.CommentRepo.DeleteCommentsByComplaintID(id),
                this.ComplaintRepo.DeleteComplaintByID(id))
            );
        }
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
        public JsonResult GetComplaints()
        {
            return Json(this.ComplaintRepo.Complaints.ToArray());
        }
        public JsonResult GetComments()
        {
            return Json(this.CommentRepo.Comments.ToArray());
        }
    }
}