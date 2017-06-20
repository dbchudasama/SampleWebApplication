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

        public EntityEntry<MockStudent> AddStudent(int ID, string name, string lastName, DateTime Enrollment_Date)
        {
            var mockStudent = _context.MockStudents.Add(new MockStudent { FirstMidName = name, LastName = lastName, EnrollmentDate = Enrollment_Date});
            _context.SaveChanges();

            return mockStudent;
            
        }


        public EntityEntry<MockStudent> EditStudent(int ID, string name, string lastName, DateTime Enrollment_Date)
        {
            var editMockStudent = _context.MockStudents.Update(new MockStudent { FirstMidName = name, LastName = lastName, EnrollmentDate = Enrollment_Date });
            _context.SaveChanges();

            return editMockStudent;
        }


        public EntityEntry<MockStudent> RemoveStudent(int ID, string name, string lastName, DateTime Enrollment_Date)
        {
            var removeMockStudent = _context.MockStudents.Remove(new MockStudent { FirstMidName = name, LastName = lastName, EnrollmentDate = Enrollment_Date });
            _context.SaveChanges();

            return removeMockStudent;
        }

    }
}
