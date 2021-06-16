using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ABC_Ed_Services
{
    public partial class frmStudentTT : Form
    {

        //private TafeDBDataSet2.StudentDataTable table;
        private Tafe_DataTier dt;


        public frmStudentTT()
        {
            //dt = new Tafe_DataTier();
            InitializeComponent();
        }

        private void frmStudentTT_Load(object sender, EventArgs e)
        {
            dt = new Tafe_DataTier();

            cbStudents.Text = "-Select Student-";
            var studentList = dt.viewStudents();
            foreach (var student in studentList)
            {
                cbStudents.Items.Add(student.StudentID);
            }

        }

        private void cbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tafe_DataTier dt = new Tafe_DataTier();

            lbCourses.Items.Clear();
            var studentList = dt.viewStudents();

            string id = cbStudents.SelectedItem.ToString();

            foreach (var student in studentList)
            {
                if (student.StudentID == id)
                {
                    txtName.Text = student.StduentName;
                    txtDateEnrolled.Text = student.DateEnrolled.ToString();
                }
            }
            //txtName.Text = (table.FindByStudentID(id)).StduentName;
            //txtDateEnrolled.Text = (table.FindByStudentID(id)).DateEnrolled.ToString("d");

            //Tafe_DataTier dt = new Tafe_DataTier();

            var enrollList = dt.getEnrollmentsForStudent(id);

            if (enrollList.Count == 0)
            {
                lbCourses.Items.Add("--------- NO ENROLLMENTS ----------");

            }
            else
            {
                foreach (var enroll in enrollList)
                {
                    lbCourses.Items.Add(enroll.CourseName);
                }
            }
        }

        private void lbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}