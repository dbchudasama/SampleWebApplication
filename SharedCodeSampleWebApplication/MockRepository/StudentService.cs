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
       

    }
}
