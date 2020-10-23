using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS390.Resources
{
    public partial class StudentList : Form
    {
        public StudentList()
        {
            InitializeComponent();
            Course current_course = (Course)ProfessorDashboard.current_course;
            var student_array = from row in current_course.GetEnrolledStudents()
                                    //where row.Value.GetCourseTerm() == "F14"
                                select new
                                {
                                    First = row.Value.GetFirstName(),
                                    Last = row.Value.GetLastName()
                                };
            dataGridView1.DataSource = student_array.ToArray();
        }

        private void StudentList_Load(object sender, EventArgs e)
        {
            
        }
    }
}
