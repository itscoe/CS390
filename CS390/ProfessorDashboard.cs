using CS390.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS390
{

    public partial class ProfessorDashboard : Form
    {
        internal static Course current_course;

        private Faculty current_user;

        public ProfessorDashboard()
        {
            InitializeComponent();
            current_user = (Faculty)LogInScreen.current_user;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            label1.Location = new Point(10, label1.Location.Y);
            label2.Location = new Point(10, label2.Location.Y);
            dataGridView3.Visible = false;
            var course_array = from row in RegistrationDatabase.GetCourses()
                               //where row.Value.GetCourseTerm() == "F14"
                               select new
                               {
                                   Id = row.Value.GetCourseID(),
                                   Name = row.Value.GetCourseName(),
                                   Faculty = row.Value.GetFaculty().GetUserName(),
                                   Credits = row.Value.GetCourseCredit(),
                                   Seats = row.Value.GetNumSeats(),
                                   Dates = String.Join(", ", row.Value.GetDayBlocks()),
                                   Times = String.Join(", ", row.Value.GetTimeBlocks())
                               };
            dataGridView1.DataSource = course_array.ToArray();
            var faculty_course_array = from row in RegistrationDatabase.GetCourses()
                               //where row.Value.GetCourseTerm() == "F14" && 
                               where row.Value.GetFaculty().GetUserName() == current_user.GetUserName()
                               select new
                               {
                                   Id = row.Value.GetCourseID(),
                                   Name = row.Value.GetCourseName(),
                                   Faculty = row.Value.GetFaculty().GetUserName(),
                                   Credits = row.Value.GetCourseCredit(),
                                   Seats = row.Value.GetNumSeats(),
                                   Dates = String.Join(", ", row.Value.GetDayBlocks()),
                                   Times = String.Join(", ", row.Value.GetTimeBlocks())
                               };
            dataGridView2.DataSource = faculty_course_array.ToArray();
            var advisees_array = from row in current_user.GetStudentAdvisees()
                                 select new
                                 {
                                     First = row.GetFirstName(),
                                     Last = row.GetLastName()

                                };
            dataGridView3.DataSource = advisees_array.ToArray();
            try
            {
                var student_course_array = from row in current_user.GetStudentAdvisees()[0].GetCourses()
                                           select new
                                           {
                                               Id = row.Value.GetCourseID(),
                                               Name = row.Value.GetCourseName(),
                                               Faculty = row.Value.GetFaculty().GetUserName(),
                                               Credits = row.Value.GetCourseCredit(),
                                               Seats = row.Value.GetNumSeats(),
                                               Dates = String.Join(", ", row.Value.GetDayBlocks()),
                                               Times = String.Join(", ", row.Value.GetTimeBlocks())
                                           };
                dataGridView4.DataSource = student_course_array.ToArray();
            }
            catch
            {

            }
            
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!LogInScreen.admin_perms)
            {
                Application.OpenForms["Form1"].Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.FlatAppearance.BorderSize = 3;
            button2.FlatAppearance.BorderSize = 1;
            button3.FlatAppearance.BorderSize = 1;
            button4.FlatAppearance.BorderSize = 1;
            button1.FlatAppearance.BorderSize = 1;
            button5.FlatAppearance.BorderColor = Color.Maroon;
            button2.FlatAppearance.BorderColor = Color.Empty;
            button3.FlatAppearance.BorderColor = Color.Empty;
            button4.FlatAppearance.BorderColor = Color.Empty;
            button1.FlatAppearance.BorderColor = Color.Empty;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.FlatAppearance.BorderSize = 3;
            button1.FlatAppearance.BorderSize = 1;
            button3.FlatAppearance.BorderSize = 1;
            button4.FlatAppearance.BorderSize = 1;
            button5.FlatAppearance.BorderSize = 1;
            button2.FlatAppearance.BorderColor = Color.Maroon;
            button1.FlatAppearance.BorderColor = Color.Empty;
            button3.FlatAppearance.BorderColor = Color.Empty;
            button4.FlatAppearance.BorderColor = Color.Empty;
            button5.FlatAppearance.BorderColor = Color.Empty;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = true;
            dataGridView4.Visible = true;
            label1.Visible = false;
            label2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderSize = 3;
            button2.FlatAppearance.BorderSize = 1;
            button3.FlatAppearance.BorderSize = 1;
            button4.FlatAppearance.BorderSize = 1;
            button5.FlatAppearance.BorderSize = 1;
            button1.FlatAppearance.BorderColor = Color.Maroon;
            button2.FlatAppearance.BorderColor = Color.Empty;
            button3.FlatAppearance.BorderColor = Color.Empty;
            button4.FlatAppearance.BorderColor = Color.Empty;
            button5.FlatAppearance.BorderColor = Color.Empty;
            dataGridView1.Visible = true;
            dataGridView2.Visible = true;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var i = 0;
                foreach (KeyValuePair<string, Course> row in RegistrationDatabase.GetCourses())
                {
                    if(i == e.RowIndex)
                    {
                        current_course = row.Value;
                    }
                    i += 1;
                }

                StudentList form3 = new StudentList();
                form3.Show();
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                current_user.GetStudentAdvisees().ElementAt(e.RowIndex).VerifyCurrentSchedule();
            }
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                current_user.GetStudentAdvisees().ElementAt(e.RowIndex).VerifyNextSchedule();
            }
        }
    }
}
