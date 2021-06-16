using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ABC_Ed_Services
{
    public partial class frmViewEnrollments : Form
    {
        //TafeDBDataSet2.CourseDataTable table;
        private Tafe_DataTier dt;

        public frmViewEnrollments()
        {
            dt = new Tafe_DataTier();
            InitializeComponent();
        }

        private void frmViewEnrollments_Load(object sender, EventArgs e)
        {
            cbCourses.Text = "-Select Courset-";
            //Tafe_DataTier dt = new Tafe_DataTier();
            var courseList = dt.viewCourses();


            foreach (var course in courseList)
            {
                //cbCourses.Items.Add(row["CourseID"].ToString()); ;
                cbCourses.Items.Add(course.CourseID);

            }
        }

        private void cbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbStudents.Items.Clear();
            //Tafe_DataTier dt = new Tafe_DataTier();
            var courseList = dt.viewCourses();

            string id = cbCourses.SelectedItem.ToString();

            foreach (var course in courseList)
            {
                if (course.CourseID == id)
                {
                    this.txtName.Text = course.CourseName;
                    this.txtCost.Text = string.Format("{0:C}", course.Cost);
                }
            }

            var studentsList = dt.getStudentsEnrolledInCourse(id);

            if (studentsList.Count == 0)
            {
                lbStudents.Items.Add("--------- NO ENROLLMENTS ----------");
            }
            else

            {
                foreach (var student in studentsList)

                {
                    this.lbStudents.Items.Add(student.StudentID + " : " + student.StduentName);
                }
            }
        }

        private void lbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}