using ABC_Ed_Services.EnrollServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ABC_Ed_Services
{
    public partial class frmBilling : Form
    {
        //private TafeDBDataSet2.StudentDataTable studTable;
        private Tafe_DataTier dt;
       private List<StudentVO> studTable = new List<StudentVO>();
        

        public frmBilling()
        {
            dt = new Tafe_DataTier();            
            InitializeComponent();
        }

        private void cbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {            
            lbCourses.Items.Clear();
            var studentList = dt.viewStudents();

            string id = cbStudents.SelectedItem.ToString();

            foreach(var student in studentList)
            {
                if (student.StudentID == id)
                {
                    this.txtName.Text = (student.StduentName);
                }
            }

            decimal total = 0.0M;
            var enrollList = dt.getEnrollmentsForStudent(id);

            if (enrollList.Count == 0)
            {
                lbCourses.Items.Add("--------- NO ENROLLMENTS ----------");
            }
            else 
            {
                foreach (var enroll in enrollList)
            {
                    lbCourses.Items.Add(enroll.CourseName + " : " + enroll.Cost);
                    total += (Decimal)enroll.Cost;
                }
            }
            txtCost.Text = total.ToString("C");
        }

        private void frmBilling_Load(object sender, EventArgs e)
        {
            cbStudents.Text = "-Select Student-";
            var studentList = dt.viewStudents();
            foreach (var student in studentList)
            {
                cbStudents.Items.Add(student.StudentID);
            }
        }
    }
}