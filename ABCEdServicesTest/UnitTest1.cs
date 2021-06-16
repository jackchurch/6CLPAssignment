using ABC_Ed_Services.EnrollServiceReference;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using Assert = NUnit.Framework.Assert;

namespace ABCEdServicesTest
{
    [TestClass]
    public class UnitTest1
    {
        private EnrollServiceClient proxy;
        private IEnrollService iProxy;

        [TestFixtureSetUp]
        public void SetUp()
        {
            iProxy = MockRepository.GenerateMock<IEnrollService>();
            proxy = new EnrollServiceClient("BasicHttpBinding_IEnrollService");
        }

        [Test(Description = "Test 1: A test to check there are 2 courses")]
        public void CheckCourseCountIs2()
        {
            //Act
            var p = proxy.ViewCourses();

            Assert.AreEqual(2, p.Count, "The count of courses is not 2.");
            //iProxy.VerifyAllExpectations();

        }


        [Test(Description = "Test 2: A test to insert a course and check number of coures is now 3")]
        public void InsertCourseCheckCountIs3()
        {
            //Act
            proxy.InsertCourse("C300", "New Course Name Here", (decimal)550.50);

            var p = proxy.ViewCourses();
            Assert.AreEqual(3, p.Count, "The count of courses is not 3.");
            //iProxy.VerifyAllExpectations();
        }

        [Test(Description = "Test 3: A test to check there are 2 students")]
        public void CheckStudentCountIs2()
        {
            //Act
            var p = proxy.ViewStudents();

            Assert.AreEqual(2, p.Count, "The count of students is not 2.");
            //iProxy.VerifyAllExpectations();

        }


        [Test(Description = "Test 4: A test to insert a course and check number of students is now 3")]
        public void InsertStudentCheckCountIs3()
        {
            //Act
            proxy.InsertStudent("S300", "Jack Church", DateTime.Parse("13-05-2000"));

            var p = proxy.ViewCourses();
            Assert.AreEqual(3, p.Count, "The count of courses is not 3.");
            //iProxy.VerifyAllExpectations();
        }


        [Test(Description = "Test 5: A test to check there are 0 enrollments for student S100")]
        public void CheckEnrollmentCountIs0()
        {
            //Act
            var p = proxy.GetEnrollmentsForStudent("S100");

            Assert.AreEqual(0, p.Count, "The count of enrollments for S1000 is not 0.");
            //iProxy.VerifyAllExpectations();

        }


        [Test(Description = "Test 6: A test to enroll S100 in C100 and check number of enrollments for S100 is now 1")]
        public void EnrollStudentS100InCourseC100()
        {
            //Act
            proxy.Enroll("C100", "S100");

            var c = proxy.GetEnrollmentsForStudent("S100");
            Assert.AreEqual(1, c.Count, "The count of enrllments for S100 is not 1.");
            iProxy.VerifyAllExpectations();
        }
    }
}
