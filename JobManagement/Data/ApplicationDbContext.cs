using System;
using System.Collections.Generic;
using System.Text;
using JobManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
