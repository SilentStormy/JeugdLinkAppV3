using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeugdLinkDAL.Data
{
    public class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {


        }
       
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Mentor> Mentor { get; set; }   
    }
}
