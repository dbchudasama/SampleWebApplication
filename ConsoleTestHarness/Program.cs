using System;
using SharedCodeSampleWebApplication.MockRepository;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace ConsoleTestHarness
{
    class Program
    {
        static void Main(string[] args)
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
            service.AddStudent("Divyesh B", "Chudasama", DateTime.Now);

            //ASSERT
            //Verifying that object type is what we require
            mockSet.Verify(m => m.Add(It.IsAny<MockStudent>()), Times.Once());
            //Save chanes and add only once
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

            Console.WriteLine("MockStudent:" + mockContext.Object + "successfully added!");
            Console.ReadLine();

        }
    }
}