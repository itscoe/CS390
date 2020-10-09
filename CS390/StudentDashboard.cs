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
        private Student current_user;

        public StudentDashboard()
        {
            InitializeComponent();
            current_user = (Student)LogInScreen.current_user;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            label1.Location = new Point(10, label1.Location.Y);
            label2.Location = new Point(10, label2.Location.Y);
            var course_array = from row in RegistrationDatabase.GetCourses() select new { Id = row.Value.GetCourseID(), 
                Name = row.Value.GetCourseName(), Faculty = row.Value.GetFaculty().GetUserName(), Credits = row.Value.GetCourseCredit(), 
                Seats = row.Value.GetNumSeats(), Dates = String.Join(", ", row.Value.GetDayBlocks()), Times = String.Join(", ", row.Value.GetTimeBlocks())
            };
            dataGridView1.DataSource = course_array.ToArray();
            var student_course_array = from row in current_user.GetCourses()
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
            dataGridView2.DataSource = student_course_array.ToArray();
            var student_course_history_array = from row in current_user.GetCourseHistory()
                                       select new
                                       {
                                           Id = row.GetCourseID(),
                                           Term = row.GetCourseTerm(),
                                           Credits = row.GetCourseCredit(),
                                           Grade = row.GetGrade(),
                                       };
            dataGridView3.DataSource = student_course_history_array.ToArray();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["Form1"].Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow d_row in dataGridView1.Rows)
            {
                object ischecked = d_row.Cells[0].Value;

                if (ischecked == null)
                {
                }
                else
                {
                    try
                    {
                        current_user.AddCourse((string)d_row.Cells[1].Value);
                    } catch
                    {
                        System.Windows.Forms.MessageBox.Show("Already enrolled in course");
                    }
                }
            }
            Form2_Load(sender, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow d_row in dataGridView2.Rows)
            {
                object ischecked = d_row.Cells[0].Value;

                if (ischecked == null)
                {
                }
                else
                {
                    try
                    {
                        current_user.DropCourse((string)d_row.Cells[1].Value);
                    }
                    catch
                    {
                        System.Windows.Forms.MessageBox.Show("Error in dropping course");
                    }
                }
            }
            Form2_Load(sender, e);
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
            tabControl1.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
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
            tabControl1.Visible = false;
            dataGridView1.Visible = true;
            dataGridView2.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
        }
    }
}
