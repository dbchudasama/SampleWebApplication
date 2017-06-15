using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SampleWebApplication.Models
{
    public class Students
    {
        public int ID { get; set; }
        //Allows us to put a cap on the length of the LastName
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstMidName { get; set; }
        //Using Data type here as we only want the date and not the time. This is to override the database intrinsic type. DataType allows us to specify a specific type of data.
        [DataType(DataType.Date)]
        //Removing Timestamp from the date. Allowing formating when value is displayed in a text box for editing
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
