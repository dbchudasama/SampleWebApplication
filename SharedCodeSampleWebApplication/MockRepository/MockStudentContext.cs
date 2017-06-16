using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace SharedCodeSampleWebApplication.MockRepository
{
    //MockStudentContext calss implementing DBContext
    public class MockStudentContext : DbContext
    {
        public MockStudentContext(DbContextOptions<MockStudentContext> options) : base(options)
        {
        }

        //By setting the property as virtual it will allow the mocking framework to derive from the context overriding these properties with a mocked implementation.
        public virtual DbSet<MockStudents> MockStudent { get; set; }

        //Here, overriding default behaviour by  specifying singular table names in the DbCotext. By default EF typically name the properties with a plural name.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MockStudents>().ToTable("Student");
        }
    }
}
