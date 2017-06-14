using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApplication.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }

        //Nullable value is different from zero. This means that the student grade value is not yet known or has not yet been assigned.
        public Grade? Grade { get; set; }

        public Course Course { get; set; }
        public Students Student { get; set; }
    }
}
