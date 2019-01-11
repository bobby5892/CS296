using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace ComplaintDepartment.Models.Repositories
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options){ }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
