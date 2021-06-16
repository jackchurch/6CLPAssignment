using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ABC_Ed_Services
{
    public partial class frmEnroll : Form
    {
        //private TafeDBDataSet2.StudentDataTable studTable;
        //private TafeDBDataSet2.CourseDataTable courseTable;
        private Tafe_DataTier dt;

        public frmEnroll()
        {
            InitializeComponent();
            dt = new Tafe_DataTier();
        }

        private void frmEnroll_Load(object sender, EventArgs e)
        {
            var studentList = dt.viewStudents();
            var courseList = dt.viewCourses();

            cbStudents.Text = "-Select Student-";
            //studTable = dt.viewStudents();
            foreach (var student in studentList)
            {
                cbStudents.Items.Add(student.StudentID.ToString());
            }

            cbCourses.Text = "-Select Course-";
            //courseTable = dt.viewCourses();
            foreach (var course in courseList)
            {
                cbCourses.Items.Add(course.CourseID.ToString()); ;
            }

        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            dt = new Tafe_DataTier();
            int rowsInserted = dt.enroll(cbCourses.SelectedItem.ToString(), cbStudents.SelectedItem.ToString());
                       
            if (rowsInserted > 0)
            {
                MessageBox.Show("New Enrollment Information Saved", "Enrollment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("New Enrollment Information NOT Saved", "Enrollment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            var studentList = dt.viewStudents();


            string id = cbStudents.SelectedItem.ToString();

            foreach (var student in studentList)
            {
                if (student.StudentID == id)
                {
                    this.txtStudName.Text = (student.StduentName);
                    this.txtDateEnrolled.Text = student.DateEnrolled.ToString();
                }

            }
        }

        private void cbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            var courseList = dt.viewCourses();



            string id = cbCourses.SelectedItem.ToString();

            foreach (var course in courseList)
            {
                if (course.CourseID == id)
                {
                    this.txtCourseName.Text = (course.CourseName);
                    this.txtCost.Text = string.Format("{0:C}", course.Cost);
                }

            }
        }


    }
        
}