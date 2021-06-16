using ABCEnrollmentServiceWCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

//Install database to C:\DATABASE\TAFEDB.MDF


namespace ABCEnrollmentServiceWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EnrollService" in both code and config file together.
    public class EnrollService : IEnrollService
    {
        //Shorthand for the database here
        public TafeDBEntities db = new TafeDBEntities();

        //Add enrollment
        public int Enroll(string courseID, string studentID)
        {
            Enrollment e = new Enrollment { CourseID = courseID, StudentID = studentID };
            db.Enrollments.Add(e);
            return db.SaveChanges();
        }



        //Find student, get list of coruses (return c.Name & c.Cost)
        public List<CourseVO> GetEnrollmentsForStudent(string studentID)
        {
            var enrollList = db.Enrollments.ToList();
            var courseList = db.Courses.ToList();
            var courseVOList = new List<CourseVO>();

            //FOR EACH enrolment 
            foreach (var e in enrollList)
            {
                //IF enrollment item studentID is *the* studentID
                if (e.StudentID == studentID)
                {
                    //take the enrollment record and get the enroll courseID associated with it and assign it to tempId
                    var tempId = e.CourseID;

                    //for each course
                    foreach(var c in courseList)
                    {

                        if (c.CourseID == tempId)
                        {
                            courseVOList.Add(new CourseVO
                            {
                                CourseName = c.CourseName,
                                Cost = c.Cost
                            });
                        }
                    }
                }

            }
            return courseVOList;
        }
        

        //Get find course, get list of studetns in course
        public List<StudentVO> GetStudentsEnrolledInCourse(string courseID)
        {
            var enrollList = db.Enrollments.ToList();
            var studentList = db.Students.ToList();
            var studentVOList = new List<StudentVO>();

            //FOR EACH enrolment 
            foreach (var e in enrollList)
            {
                //IF enrollment item courseID is *the* courseID
                if (e.CourseID == courseID)
                {
                    //take the enrollment record and get the enroll studentID associated with it and assign it to tempId
                    var tempId = e.StudentID;

                    //for each student
                    foreach(var s in studentList)
                    {
                        if (s.StudentID == tempId)
                        {
                            studentVOList.Add(new StudentVO
                            {
                                StudentID = s.StudentID,
                                StduentName = s.StduentName
                            });
                        }
                    }
                }

            }
            return studentVOList;
        }


        public int InsertCourse(string id, string name, decimal cost)
        {
            Course c = new Course { CourseID = id, CourseName = name, Cost = cost };
            db.Courses.Add(c);
            return db.SaveChanges();
        }

        public int InsertStudent(string id, string name, DateTime dateEnrolled)
        {
            Student s = new Student { StudentID = id, StduentName = name, DateEnrolled = dateEnrolled };
            db.Students.Add(s);
            return db.SaveChanges();
        }

        public List<CourseVO> ViewCourses()
        {
            //Get every course from the database into a list. 
            var coursesList = db.Courses.ToList();

            //Make a new blank instance of CourseVO
            var coursesVOList = new List<CourseVO>();

            //Now copy the courses list into coursesVoList
            //foreach (Course c in coursesList) 
            foreach (var c in coursesList)
            {
                coursesVOList.Add(new CourseVO
                {
                    CourseID = c.CourseID,
                    CourseName = c.CourseName,
                    Cost = c.Cost
                });
            }
            return coursesVOList;
        }

        public List<StudentVO> ViewStudents()
        {
            var studentsList = db.Students.ToList();
            var studentsVOList = new List<StudentVO>();

            foreach (var s in studentsList)
            {
                studentsVOList.Add(new StudentVO
                {
                    StudentID = s.StudentID,
                    StduentName = s.StduentName,
                    DateEnrolled = s.DateEnrolled
                });
            }
            return studentsVOList;
        }
    }
}
