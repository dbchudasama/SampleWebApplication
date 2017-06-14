using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace SampleWebApplication.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        //Creating a DbSet property for each entity set. As this is an entity set, in the EFC Framework, entity set refers to a database whilst an entity refers to a row in the database.
        //When the table will be created the names will correspond to the Dbset values
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Students> Students { get; set; }

        //Here, overriding deafult behaviour by  specifying singular table names in the DbCotext. By default EF typically name the properties with a plural name.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Students>().ToTable("Student");
        }
    }
}
