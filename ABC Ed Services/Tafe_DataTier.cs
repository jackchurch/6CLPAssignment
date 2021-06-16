using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using ABC_Ed_Services.TafeDBDataSet2TableAdapters;
using static ABC_Ed_Services.TafeDBDataSet2;
using ABC_Ed_Services.EnrollServiceReference; //for local WCF

namespace ABC_Ed_Services{

    class Tafe_DataTier{

        //private CourseTableAdapter courseTA;
        //private EnrollmentTableAdapter enrollmentTA;
        //private StudentTableAdapter studentTA;
        private EnrollServiceClient proxy;

        public Tafe_DataTier(){



            //courseTA = new CourseTableAdapter();
            //enrollmentTA = new EnrollmentTableAdapter();
            //studentTA = new StudentTableAdapter();
            proxy = new EnrollServiceClient("BasicHttpBinding_IEnrollService"); //This works and is the orignal

            

        }



        public int insertStudent(string id, string name, DateTime dateEnrolled)
        {
            return proxy.InsertStudent(id, name, dateEnrolled);
        }



        public int insertCourse(string id, string name, Decimal cost)
        {
            return proxy.InsertCourse(id, name, cost);

        }



        public List<StudentVO> viewStudents()
        {
            return proxy.ViewStudents();
        }


        public List<CourseVO> viewCourses()
        {
            return proxy.ViewCourses();
        }



        public int enroll(String courseID, String studentID)
        {
            return proxy.Enroll(courseID, studentID);
            //int rowsUpdated = enrollmentTA.Insert(studentID, courseID, "NR");
            //return rowsUpdated;
        }



        public List<CourseVO> getEnrollmentsForStudent(string studentID)
        {
            return proxy.GetEnrollmentsForStudent(studentID);
        }


        public List<StudentVO> getStudentsEnrolledInCourse(String courseID)
        {
            return proxy.GetStudentsEnrolledInCourse(courseID);
        }

    }
}
