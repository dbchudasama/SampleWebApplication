using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedCodeSampleWebApplication.MockRepository
{
    public class MockStudent
    {
        public int ID { get; set; }

        [Required]
        //Allows us to put a cap on the length of the LastName
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        //The column keyword will allow us to rename the FirstMidName column to FirstName in the database
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        //Using Data type here as we only want the date and not the time. This is to override the database intrinsic type. DataType allows us to specify a specific type of data.
        [DataType(DataType.Date)]
        //Removing Timestamp from the date. Allowing formating when value is displayed in a text box for editing
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }

        }

        //public ICollection<Enrollment> Enrollments { get; set; }
    }
}
