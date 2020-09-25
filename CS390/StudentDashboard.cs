using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS390
{
    public partial class StudentDashboard : Form
    {
        public StudentDashboard()
        {
            InitializeComponent();
            Console.Write(LogInScreen.current_user);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var course_array = from row in RegistrationDatabase.GetCourses() select new { Id = row.Value.courseID, 
                Name = row.Value.courseName, Faculty = row.Value.faculty.GetUserName(), Credits = row.Value.courseCredit, 
                Seats = row.Value.numSeats, Dates = String.Join(", ", row.Value.dayBlocks), Times = String.Join(", ", row.Value.timeBlocks)
            };
            dataGridView1.DataSource = course_array.ToArray();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["Form1"].Close();
        }
    }
}
