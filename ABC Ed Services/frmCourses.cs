using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ABC_Ed_Services
{
   
    public partial class frmCourses : Form
    {

        public frmCourses()
        {
            InitializeComponent();
        }

        private void frmCourses_Load(object sender, EventArgs e)
        {
            Tafe_DataTier dt = new Tafe_DataTier();
            var coursesList = dt.viewCourses();


            foreach (var course in coursesList)
            {
                lbCourses.Items.Add(course.Cost + " : " + course.CourseName);
            }
        }

        private void lbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }
    }
}