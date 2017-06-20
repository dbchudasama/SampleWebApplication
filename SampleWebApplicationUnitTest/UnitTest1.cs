using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedCodeSampleWebApplication.MockRepository;
using Microsoft.EntityFrameworkCore;
using Moq;


namespace SampleWebApplicationUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void CreateMockStudent_Add_A_Student_Via_Context()
        {
            //ARRANGE
            //Here using the Moq package for Mocking. 
            var mockSet = new Mock<DbSet<MockStudent>>();
         
            //New instance of MockStudentContext
            var mockContext = new Mock<MockStudentContext>();
            //Mapping the mock context to return back object of tryp MockStudent
            mockContext.Setup(m => m.MockStudents).Returns(mockSet.Object);

            //ACT
            //Invoking StudentService to to return MockStudent context
            var service = new StudentService(mockContext.Object);
            //Setting the student credentials in method "AddStudent"
            service.AddStudent(1, "Divyesh B", "Chudasama", DateTime.Now);

            //ASSERT
            //Verifying that object type is what we require
            mockSet.Verify(m => m.Add(It.IsAny<MockStudent>()), Times.Once());
            //Save chanes and add only once
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

            Console.WriteLine("MockStudent:" + mockContext + "successfully added!");
            Console.ReadLine();
  
        }
        

        [TestMethod]

        public void EditMockStudent()
        {
            DateTime dt = new DateTime(2017, 27, 2, 7, 0, 0);

            //ARRANGE
            //Here using the Moq package for Mocking. 
            var mockSet = new Mock<DbSet<MockStudent>>();

            //New instance of MockStudentContext
            var mockContext = new Mock<MockStudentContext>();
            //Mapping the mock context to return back object of tryp MockStudent
            mockContext.Setup(n => n.MockStudents).Returns(mockSet.Object);

            //ACT
            //Invoking StudentService to to return MockStudent context
            var service = new StudentService(mockContext.Object);
            //Setting the student credentials in method "EditStudent". Date Time reads as 27/2/2017 7:00:00AAM'
            service.EditStudent(1, "Divyesh", "Chudasama", dt);
            
            //ASSERT
            //Verifying that object type is what we require
            mockSet.Verify(n => n.Update(It.IsAny<MockStudent>()), Times.Once());
            //Save chanes and add only once
            mockContext.Verify(n => n.SaveChanges(), Times.Once());

            Console.WriteLine("MockStudent:" + mockContext + "successfully edited!");
            Console.ReadLine();
        }

        
        [TestMethod]

        public void RemoveMockStudent()
        {
            DateTime dt = new DateTime(2017, 27, 2, 7, 0, 0);

            //ARRANGE
            //Here using the Moq package for Mocking. 
            var mockSet = new Mock<DbSet<MockStudent>>();

            //New instance of MockStudentContext
            var mockContext = new Mock<MockStudentContext>();
            //Mapping the mock context to return back object of tryp MockStudent
            mockContext.Setup(o => o.MockStudents).Returns(mockSet.Object);

            //ACT
            //Invoking StudentService to to return MockStudent context
            var service = new StudentService(mockContext.Object);
            //Setting the student credentials in method "EditStudent". Date Time reads as 27/2/2015 7:00:00AAM'
            service.RemoveStudent(1, "Divyesh B", "Chudasama", dt);

            //ASSERT
            //Verifying that object type is what we require
            mockSet.Verify(o => o.Remove(It.IsAny<MockStudent>()), Times.Once());
            //Save chanes and add only once
            mockContext.Verify(o => o.SaveChanges(), Times.Once());

            Console.WriteLine("MockStudent:" + mockContext + "successfully removed!");
            Console.ReadLine();
        }
        
    }
}
