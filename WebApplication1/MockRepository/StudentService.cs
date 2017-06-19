using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCodeSampleWebApplication.MockRepository
{
    public class StudentService
    {
        //Setting a private MockStudentContext
        private MockStudentContext _context;

        //Constructor
        public StudentService(MockStudentContext context)
        {
            _context = context;
        }

        public EntityEntry<MockStudent> AddStudent(string name, string lastName, DateTime Enrollment_Date)
        {
            var mockStudent = _context.MockStudents.Add(new MockStudent { FirstMidName = name, LastName = lastName, EnrollmentDate = Enrollment_Date});
            _context.SaveChanges();

            return mockStudent;
            
        }

    }
}
