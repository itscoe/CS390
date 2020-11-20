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
    public partial class AdminManagerDashboard : Form
    {
        private Admin current_user;

        public AdminManagerDashboard()
        {
            InitializeComponent();
            current_user = (Admin)LogInScreen.current_user;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            label1.Location = new Point(10, label1.Location.Y);
            var course_array = from row in RegistrationDatabase.GetCourses()
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
            var student_array = from row in RegistrationDatabase.GetUserDatabase()
                                where row.Value is Student
                                select new
                                {
                                    First = row.Value.GetFirstName(),
                                    Last = row.Value.GetLastName(),
                                    Username = row.Value.GetUserName(),
                                    CurrentAdvisor = row.Value.GetStatus()
                                };
            var faculty_array = from row in RegistrationDatabase.GetUserDatabase()
                                where row.Value is Faculty
                                select new
                                {
                                    First = row.Value.GetFirstName(),
                                    Last = row.Value.GetLastName(),
                                    Username = row.Value.GetUserName(),
                                    CurrentAdvisor = row.Value.GetStatus()
                                };
            dataGridView1.DataSource = course_array.ToArray();
            dataGridView2.DataSource = student_array.ToArray();
            dataGridView3.DataSource = faculty_array.ToArray();
            ComboBox comboBox3 = new ComboBox();
            foreach (User user in RegistrationDatabase.GetUserDatabase().Values)
            {
                if (user is Student)
                {
                    comboBox1.Items.Add(user.GetUserName());
                }
                if (user is Faculty)
                {
                    comboBox3.Items.Add(user.GetUserName());
                    comboBox2.Items.Add(user.GetUserName());
                }
            }
            ((DataGridViewComboBoxColumn)dataGridView2.Columns["Advisor"]).DataSource = comboBox3.Items;
            foreach (DataGridViewRow d_row in dataGridView2.Rows)
            {
                d_row.Cells[1].Value = RegistrationDatabase.GetUser((string)d_row.Cells[4].Value).GetStatus();
            }
            ((DataGridViewComboBoxColumn)dataGridView1.Columns["ChangeProfessor"]).DataSource = comboBox3.Items;
            foreach (DataGridViewRow d_row in dataGridView2.Rows)
            {
                d_row.Cells[1].Value =(string)d_row.Cells[4].Value;
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["Form1"].Close();
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
            label1.Visible = true;
            button8.Visible = true;
            button6.Visible = false;
            comboBox1.Visible = false;
            button7.Visible = false;
            comboBox2.Visible = false;
            dataGridView2.Visible = false;
            button9.Visible = false;
            dataGridView3.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            button12.Visible = false;
            button12.Visible = true;
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
            label1.Visible = false;
            button8.Visible = false;
            button6.Visible = true;
            comboBox1.Visible = true;
            button7.Visible = true;
            comboBox2.Visible = true;
            dataGridView2.Visible = false;
            button9.Visible = false;
            dataGridView3.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            button12.Visible = true;
            button13.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderSize = 1;
            button2.FlatAppearance.BorderSize = 1;
            button3.FlatAppearance.BorderSize = 3;
            button4.FlatAppearance.BorderSize = 1;
            button5.FlatAppearance.BorderSize = 1;
            button1.FlatAppearance.BorderColor = Color.Empty;
            button2.FlatAppearance.BorderColor = Color.Empty;
            button3.FlatAppearance.BorderColor = Color.Maroon;
            button4.FlatAppearance.BorderColor = Color.Empty;
            button5.FlatAppearance.BorderColor = Color.Empty;
            dataGridView1.Visible = false;
            label1.Visible = false;
            button8.Visible = false;
            button6.Visible = false;
            comboBox1.Visible = false;
            button7.Visible = false;
            comboBox2.Visible = false;
            dataGridView2.Visible = true;
            button9.Visible = true;
            dataGridView3.Visible = false;
            button10.Visible = false;
            button11.Visible = true;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderSize = 1;
            button2.FlatAppearance.BorderSize = 1;
            button3.FlatAppearance.BorderSize = 1;
            button4.FlatAppearance.BorderSize = 2;
            button5.FlatAppearance.BorderSize = 1;
            button1.FlatAppearance.BorderColor = Color.Empty;
            button2.FlatAppearance.BorderColor = Color.Empty;
            button3.FlatAppearance.BorderColor = Color.Empty;
            button4.FlatAppearance.BorderColor = Color.Maroon;
            button5.FlatAppearance.BorderColor = Color.Empty;
            dataGridView1.Visible = false;
            label1.Visible = false;
            button8.Visible = false;
            button6.Visible = false;
            comboBox1.Visible = false;
            button7.Visible = false;
            comboBox2.Visible = false;
            dataGridView2.Visible = false;
            button9.Visible = false;
            dataGridView3.Visible = true;
            button10.Visible = true;
            button11.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
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
            button8.Visible = false;
            button6.Visible = false;
            comboBox1.Visible = false;
            button7.Visible = false;
            comboBox2.Visible = false;
            dataGridView2.Visible = false;
            button9.Visible = false;
            dataGridView3.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                LogInScreen.current_user = RegistrationDatabase.GetUser(comboBox1.Text);
                StudentDashboard form2 = new StudentDashboard();
                form2.Show();
            }
            catch
            {
                Console.WriteLine("Oops");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                LogInScreen.current_user = RegistrationDatabase.GetUser(comboBox2.Text);
                ProfessorDashboard form2 = new ProfessorDashboard();
                form2.Show();
            }
            catch
            {
                Console.WriteLine("Oops");
            }
        }

        private void button8_Click(object sender, EventArgs e)
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
                        RegistrationDatabase.RemoveCourse((string)d_row.Cells[2].Value);
                    }
                    catch
                    {
                        System.Windows.Forms.MessageBox.Show("Error in removing course");
                    }
                }
            }
            Form2_Load(sender, e);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow d_row in dataGridView2.Rows)
            {
                DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)d_row.Cells[1];
                if (cb.Value != null)
                {
                    RegistrationDatabase.GetUser((string)d_row.Cells[4].Value).SetStatus((string)cb.Value);
                }
            }
            Form2_Load(sender, e);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow d_row in dataGridView3.Rows)
            {
                object ischecked = d_row.Cells[0].Value;

                if (ischecked == null)
                {
                }
                else
                {
                    try
                    {
                        RegistrationDatabase.RemoveUser((string)d_row.Cells[3].Value);
                    }
                    catch
                    {
                        System.Windows.Forms.MessageBox.Show("Error in removing faculty");
                    }
                }
            }
            Form2_Load(sender, e);
        }

        private void button11_Click(object sender, EventArgs e)
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
                        RegistrationDatabase.RemoveUser((string)d_row.Cells[4].Value);
                    }
                    catch
                    {
                        System.Windows.Forms.MessageBox.Show("Error in removing student");
                    }
                }
            }
            Form2_Load(sender, e);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                RegistrationDatabase.CreateUser(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            } catch
            {
                System.Windows.Forms.MessageBox.Show("Error creating user");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow d_row in dataGridView1.Rows)
            {
                DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)d_row.Cells[1];
                if (cb.Value != null)
                {
                    RegistrationDatabase.GetCourse((string)d_row.Cells[2].Value).SetFaculty((Faculty)RegistrationDatabase.GetUser((string)cb.Value));
                }
            }
            Form2_Load(sender, e);
        }
    }
}
