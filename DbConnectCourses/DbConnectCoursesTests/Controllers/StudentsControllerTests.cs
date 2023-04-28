using Microsoft.VisualStudio.TestTools.UnitTesting;
using DbConnectCourses.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbConnectCourses.Models;
using DbConnectCourses.Data;
using System.Drawing.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.AspNetCore.Mvc;


namespace DbConnectCourses.Controllers.Tests
{
    [TestClass()]
    public class StudentsControllerTests
    {

        [TestMethod()]
        public void GetStudentByIdTest()
        {
            StudentsController students = new StudentsController("testString");

            var ret = students.GetStudent("S001");

            Assert.IsNotNull(ret);
        }


        [TestMethod()]

        public void GetAllInstructorsTest()
        {
            InstructorsController instructors = new InstructorsController("testString");
            var ret = instructors.GetInstructors();

            Assert.IsNotNull(ret);
        }

        [TestMethod()]
        public void DeleteStudentByIdTest()
        {
            StudentsController students = new StudentsController("testString");

            var ret = students.DeleteStudent("S002");

            Assert.IsNotNull(ret);
        }

        [TestMethod()]
        public void AddInstructorTest()
        {
            Instructor instructors = new Instructor();
            instructors.InstructorId = "I999";
            instructors.InstructorFirstName = "TestFName";
            instructors.InstructorLastName = "TestLName";
            instructors.InstructorPhone = "111-1111";
            instructors.InstructorEmail = "test@test.com";

            InstructorsController instructor = new InstructorsController("testString");

            var ret = instructor.PostInstructor(instructors);

            Assert.IsNotNull(ret);
        }



    }
}