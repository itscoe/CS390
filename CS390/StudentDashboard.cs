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
            label3.Text = $"Total Credits: {current_user.GetHistoryCourseCredits():F2} GPA: {current_user.GetGradePointAverage():F2}";
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
                    var addCourse = true;
                    foreach (DataGridViewRow d_row_2 in dataGridView2.Rows)
                    {
                        if(addCourse && d_row.Cells[1].Value == d_row_2.Cells[1].Value)
                        {
                            addCourse = false;
                            System.Windows.Forms.MessageBox.Show("Already enrolled in course");
                        }
                        if (addCourse)
                        {
                            string new_course_id = (string)d_row.Cells[1].Value;
                            string old_course_id = (string)d_row_2.Cells[1].Value;
                            string[] new_course_split = new_course_id.Split('-');
                            List<string> new_course_split_list = new List<string>(new_course_split);
                            string[] old_course_split = old_course_id.Split('-');
                            List<string> old_course_split_list = new List<string>(old_course_split);
                            if (new_course_split_list[0] == old_course_split_list[0] && new_course_split_list[1] == old_course_split_list[1])
                            {
                                addCourse = false;
                                System.Windows.Forms.MessageBox.Show("Already enrolled in different section of course");
                            }
                        }
                        if (addCourse)
                        {
                            if((int)d_row.Cells[5].Value < 0.0)
                            {
                                addCourse = false;
                                System.Windows.Forms.MessageBox.Show("No Seats Available");
                            }
                        }
                    }
                    if (addCourse)
                    {
                        if (Convert.ToSingle(d_row.Cells[4].Value) + current_user.GetCurrentCourseCredits() > 5.0)
                        {
                            addCourse = false;
                            System.Windows.Forms.MessageBox.Show("Too many credits");
                        }
                    }
                    if (addCourse)
                    {
                        if (Convert.ToSingle(d_row.Cells[4].Value) + current_user.GetCurrentCourseCredits() > 5.0)
                        {
                            addCourse = false;
                            System.Windows.Forms.MessageBox.Show("Too many credits");
                        }
                    }
                    if (addCourse)
                    {
                        foreach (DataGridViewRow d_row_3 in dataGridView3.Rows)
                        {
                            string new_course_id = (string)d_row.Cells[1].Value;
                            string old_course_id = (string)d_row_3.Cells[0].Value;
                            string[] new_course_split = new_course_id.Split('-');
                            List<string> new_course_split_list = new List<string>(new_course_split);
                            string[] old_course_split = old_course_id.Split('-');
                            List<string> old_course_split_list = new List<string>(old_course_split);
                            if (new_course_split_list[0] == old_course_split_list[0] && new_course_split_list[1] == old_course_split_list[1])
                            {
                                System.Windows.Forms.MessageBox.Show("Warning! Previously enrolled in " + new_course_id);
                            }
                        }
                    }
                    if (addCourse)
                    {
                        try
                        {
                            current_user.AddCourse((string)d_row.Cells[1].Value);
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
                            current_user.VerifyNextSchedule();
                        }
                        catch
                        {
                            System.Windows.Forms.MessageBox.Show("Error adding course");
                        }
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

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            current_user.VerifyCurrentSchedule();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            current_user.VerifyNextSchedule();
        }
    }
}
