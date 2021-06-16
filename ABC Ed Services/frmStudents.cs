using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ABC_Ed_Services
{
    public partial class frmStudents : Form
    {

        public frmStudents()
        {
            InitializeComponent();
        }


        private void frmStudents_Load(object sender, EventArgs e)
        {
            Tafe_DataTier dt = new Tafe_DataTier();
            var studentsList = dt.viewStudents();


            foreach (var student in studentsList)
            {
                lbStudents.Items.Add(student.StudentID + " : " + student.StduentName);
            }
        }

        private void lbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
