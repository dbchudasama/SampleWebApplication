using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApplication.Models
{
    public class Course
    {
        //This will allow us to create the primaru key for the table rather than it choosing one for us
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        //Navigation property
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
