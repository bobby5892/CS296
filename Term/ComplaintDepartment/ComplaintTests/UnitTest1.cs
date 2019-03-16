using System;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using ComplaintDepartment.Models;
using ComplaintDepartment.Models.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Collections;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
/*Quick Reference on Mocking ef
* https://medium.com/@metse/entity-framework-core-unit-testing-3c412a0a997c
* https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory#writing-tests
*/
namespace ComplaintTests
{
    public class ComplaintTests
    {
        public AppDBContext Context { get; set; }
        public ComplaintRepository ComplaintRepo;
        
        public CommentRepository CommentRepo;

        public ComplaintTests()
        {
            
            /* Create a Memory Database instead of using the SQL */
            var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: "temp")
                .Options;
            Context = new AppDBContext(optionsBuilder);
            ComplaintRepo = new ComplaintRepository( this.Context);
            CommentRepo = new CommentRepository( this.Context);
        }
    
        
        
        [Fact]
        public void TestTesting()
        {
            //Test that testing is working
            Assert.True(true);
        }
        [Fact]
        public void AddComplaint()
        {
            Complaint complaint = new Complaint() { ID = 1, Contents = "Test Complaint", Completed = false, Create = DateTime.Now };
            bool success = ComplaintRepo.AddComplaint(complaint);
            Assert.True(success);
            // Cleanup
            Context.Database.EnsureDeleted();
        }
        [Fact]
        public void SearchComplaint()
        {
            Complaint complaint = new Complaint() { ID = 1, Contents = "Test Complaint", Completed = false, Create = DateTime.Now };
            int count = ComplaintRepo.Complaints.Count;

            ComplaintRepo.AddComplaint(complaint);
            Complaint found = ComplaintRepo.Search(1);
            Assert.True(found.Contents == complaint.Contents);
            // Cleanup
            Context.Database.EnsureDeleted();
        }
        [Fact]
        public void GetClosedComplaint()
        {
            Complaint complaint = new Complaint() { ID = 1, Contents = "Test Complaint", Completed = true, Create = DateTime.Now };
            int count = ComplaintRepo.Complaints.Count;

            ComplaintRepo.AddComplaint(complaint);
            List<Complaint> found = ComplaintRepo.GetClosedComplaints();
            Assert.True(found.Count == ComplaintRepo.Complaints.Count);
            // Cleanup
            Context.Database.EnsureDeleted();
        }
        [Fact]
        public void GetOpenComplaint()
        {
            Complaint complaint = new Complaint() { ID = 1, Contents = "Test Complaint", Completed = false, Create = DateTime.Now };
            int count = ComplaintRepo.Complaints.Count;

            ComplaintRepo.AddComplaint(complaint);
            List<Complaint> found = ComplaintRepo.GetOpenComplaints();
            Assert.True(found.Count == ComplaintRepo.Complaints.Count);
            // Cleanup
            Context.Database.EnsureDeleted();
        }
        [Fact]
        public void ToggleComplete()
        {
            Complaint complaint = new Complaint() { ID = 1, Contents = "Test Complaint", Completed = false, Create = DateTime.Now };
            ComplaintRepo.AddComplaint(complaint);

            ComplaintRepo.MarkComplete(complaint);

            Assert.True(ComplaintRepo.GetClosedComplaints().Count == 1);
            // Cleanup
            Context.Database.EnsureDeleted();
        }
        [Fact]
        public void SearchByPhrase()
        {
            Complaint complaint = new Complaint() { ID = 1, Contents = "Test Complaint", Completed = false, Create = DateTime.Now };
            ComplaintRepo.AddComplaint(complaint);

            List<Complaint> results = ComplaintRepo.Search("est");

            Assert.True(results[0].Contents == complaint.Contents);
            // Cleanup
            Context.Database.EnsureDeleted();
        }
        [Fact]
        public void DeleteComplaintByID()
        {
            Complaint complaint = new Complaint() { ID = 1, Contents = "Test Complaint", Completed = false, Create = DateTime.Now };
            ComplaintRepo.AddComplaint(complaint);

            ComplaintRepo.DeleteComplaintByID(1);

            Assert.True(ComplaintRepo.Complaints.Count == 0);
            // Cleanup
            Context.Database.EnsureDeleted();
        }
    }
}
