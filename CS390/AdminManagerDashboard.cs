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
            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            label3.Parent = pictureBox1;
            label4.Parent = pictureBox1;
            label5.Parent = pictureBox1;
            label6.Parent = pictureBox1;
            label7.Parent = pictureBox1;
            label8.Parent = pictureBox1;
            label9.Parent = pictureBox1;
            label10.Parent = pictureBox1;
            label11.Parent = pictureBox1;
            label12.Parent = pictureBox1;
            label13.Parent = pictureBox1;
            label1.Location = new Point(10, label1.Location.Y);
            label2.Location = new Point(label2.Location.X - 100, label2.Location.Y);
            label3.Location = new Point(label3.Location.X - 100, label3.Location.Y);
            label4.Location = new Point(label4.Location.X - 100, label4.Location.Y);
            label5.Location = new Point(label5.Location.X - 100, label5.Location.Y);
            label6.Location = new Point(label6.Location.X - 100, label6.Location.Y);
            label7.Location = new Point(label7.Location.X - 100, label7.Location.Y);
            label8.Location = new Point(label8.Location.X - 100, label8.Location.Y);
            label9.Location = new Point(label9.Location.X - 100, label9.Location.Y);
            label10.Location = new Point(label10.Location.X - 100, label10.Location.Y);
            label11.Location = new Point(label11.Location.X - 100, label11.Location.Y);
            label12.Location = new Point(label12.Location.X - 100, label12.Location.Y);
            label13.Location = new Point(label13.Location.X - 100, label13.Location.Y);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
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
            ComboBox comboBox9 = new ComboBox();
            foreach (User user in RegistrationDatabase.GetUserDatabase().Values)
            {
                if (user is Student)
                {
                    comboBox1.Items.Add(user.GetUserName());
                }
                if (user is Faculty)
                {
                    comboBox9.Items.Add(user.GetUserName());
                    comboBox8.Items.Add(user.GetUserName());
                    comboBox2.Items.Add(user.GetUserName());
                }
            }
            ((DataGridViewComboBoxColumn)dataGridView2.Columns["Advisor"]).DataSource = comboBox9.Items;
            foreach (DataGridViewRow d_row in dataGridView2.Rows)
            {
                d_row.Cells[1].Value = RegistrationDatabase.GetUser((string)d_row.Cells[4].Value).GetStatus();
            }
            ((DataGridViewComboBoxColumn)dataGridView1.Columns["ChangeProfessor"]).DataSource = comboBox9.Items;
            foreach (DataGridViewRow d_row in dataGridView1.Rows)
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
            button13.Visible = true;
            checkedListBox1.Visible = true;
            checkedListBox2.Visible = true;
            checkedListBox3.Visible = true;
            checkedListBox4.Visible = true;
            checkedListBox5.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = true;
            comboBox5.Visible = true;
            comboBox6.Visible = true;
            comboBox7.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;
            comboBox8.Visible = true;
            button15.Visible = true;
            button14.Visible = true;
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
            checkedListBox1.Visible = false;
            checkedListBox2.Visible = false;
            checkedListBox3.Visible = false;
            checkedListBox4.Visible = false;
            checkedListBox5.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
            comboBox6.Visible = false;
            comboBox7.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            comboBox8.Visible = false;
            button15.Visible = false;
            button14.Visible = false;
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
            checkedListBox1.Visible = false;
            checkedListBox2.Visible = false;
            checkedListBox3.Visible = false;
            checkedListBox4.Visible = false;
            checkedListBox5.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
            comboBox6.Visible = false;
            comboBox7.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            comboBox8.Visible = false;
            button15.Visible = false;
            button14.Visible = false;
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
            checkedListBox1.Visible = false;
            checkedListBox2.Visible = false;
            checkedListBox3.Visible = false;
            checkedListBox4.Visible = false;
            checkedListBox5.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
            comboBox6.Visible = false;
            comboBox7.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            comboBox8.Visible = false;
            button15.Visible = false;
            button14.Visible = false;
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
            checkedListBox1.Visible = false;
            checkedListBox2.Visible = false;
            checkedListBox3.Visible = false;
            checkedListBox4.Visible = false;
            checkedListBox5.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
            comboBox6.Visible = false;
            comboBox7.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            comboBox8.Visible = false;
            button15.Visible = false;
            button14.Visible = false;
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

        private void button14_Click(object sender, EventArgs e)
        {
            List<string> dayBlocks = new List<string>();
            List<string> timeBlocks = new List<string>();
            Console.WriteLine(checkedListBox1.CheckedItems.Count);
            Console.WriteLine(comboBox7.SelectedValue);
            if (checkedListBox1.CheckedItems.Count > 0 && comboBox7.SelectedIndex != -1)
            {
                Console.WriteLine("Here Here");
                string days = "";
                foreach (object day in checkedListBox1.CheckedItems)
                {
                    days = days + (string)day;
                }
                dayBlocks.Add(days);
                timeBlocks.Add((string)comboBox7.SelectedItem);
                foreach (int i in checkedListBox1.CheckedIndices)
                {
                    checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                }
                comboBox7.SelectedIndex = -1;
            }
            if ((checkedListBox2.CheckedItems).Count > 0 && comboBox6.SelectedIndex != -1)
            {
                string days = "";
                foreach (object day in checkedListBox2.CheckedItems)
                {
                    days = days + (string)day;
                }
                dayBlocks.Add(days);
                timeBlocks.Add((string)comboBox6.SelectedItem);
                foreach (int i in checkedListBox2.CheckedIndices)
                {
                    checkedListBox2.SetItemCheckState(i, CheckState.Unchecked);
                }
                comboBox6.SelectedIndex = -1;
            }
            if ((checkedListBox3.CheckedItems).Count > 0 && comboBox3.SelectedIndex != -1)
            {
                string days = "";
                foreach (object day in checkedListBox3.CheckedItems)
                {
                    days = days + (string)day;
                }
                dayBlocks.Add(days);
                timeBlocks.Add((string)comboBox3.SelectedItem);
                foreach (int i in checkedListBox3.CheckedIndices)
                {
                    checkedListBox3.SetItemCheckState(i, CheckState.Unchecked);
                }
                comboBox3.SelectedIndex = -1;
            }
            if ((checkedListBox4.CheckedItems).Count > 0 && comboBox4.SelectedIndex != -1)
            {
                string days = "";
                foreach (object day in checkedListBox4.CheckedItems)
                {
                    days = days + (string)day;
                }
                dayBlocks.Add(days);
                timeBlocks.Add((string)comboBox4.SelectedItem);
                foreach (int i in checkedListBox4.CheckedIndices)
                {
                    checkedListBox4.SetItemCheckState(i, CheckState.Unchecked);
                }
                comboBox4.SelectedIndex = -1;
            }
            if ((checkedListBox5.CheckedItems).Count > 0 && comboBox5.SelectedIndex != -1)
            {
                string days = "";
                foreach (object day in checkedListBox5.CheckedItems)
                {
                    days = days + (string)day;
                }
                dayBlocks.Add(days);
                timeBlocks.Add((string)comboBox5.SelectedItem);
                foreach (int i in checkedListBox5.CheckedIndices)
                {
                    checkedListBox5.SetItemCheckState(i, CheckState.Unchecked);
                }
                comboBox5.SelectedIndex = -1;
            }
            Console.WriteLine("Here");
            if (dayBlocks.Count > 0)
            {
                Console.WriteLine("And Here");
                foreach (DataGridViewRow d_row in dataGridView1.Rows)
                {
                    object ischecked = d_row.Cells[0].Value;

                    if (ischecked == null)
                    {
                    }
                    else
                    {
                        Console.WriteLine("And And Here");
                        try
                        {
                            RegistrationDatabase.GetCourse((string)d_row.Cells[2].Value).SetDayBlocks(dayBlocks);
                            RegistrationDatabase.GetCourse((string)d_row.Cells[2].Value).SetTimeBlocks(timeBlocks);
                        }
                        catch
                        {
                            System.Windows.Forms.MessageBox.Show("Error in changing course time");
                        }
                    }
                }
                Form2_Load(sender, e);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            List<string> dayBlocks = new List<string>();
            List<string> timeBlocks = new List<string>();
            Console.WriteLine(checkedListBox1.CheckedItems.Count);
            Console.WriteLine(comboBox7.SelectedValue);
            if (checkedListBox1.CheckedItems.Count > 0 && comboBox7.SelectedIndex != -1)
            {
                Console.WriteLine("Here Here");
                string days = "";
                foreach (object day in checkedListBox1.CheckedItems)
                {
                    days = days + (string)day;
                }
                dayBlocks.Add(days);
                timeBlocks.Add((string)comboBox7.SelectedItem);
                foreach (int i in checkedListBox1.CheckedIndices)
                {
                    checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                }
                comboBox7.SelectedIndex = -1;
            }
            if ((checkedListBox2.CheckedItems).Count > 0 && comboBox6.SelectedIndex != -1)
            {
                string days = "";
                foreach (object day in checkedListBox2.CheckedItems)
                {
                    days = days + (string)day;
                }
                dayBlocks.Add(days);
                timeBlocks.Add((string)comboBox6.SelectedItem);
                foreach (int i in checkedListBox2.CheckedIndices)
                {
                    checkedListBox2.SetItemCheckState(i, CheckState.Unchecked);
                }
                comboBox6.SelectedIndex = -1;
            }
            if ((checkedListBox3.CheckedItems).Count > 0 && comboBox3.SelectedIndex != -1)
            {
                string days = "";
                foreach (object day in checkedListBox3.CheckedItems)
                {
                    days = days + (string)day;
                }
                dayBlocks.Add(days);
                timeBlocks.Add((string)comboBox3.SelectedItem);
                foreach (int i in checkedListBox3.CheckedIndices)
                {
                    checkedListBox3.SetItemCheckState(i, CheckState.Unchecked);
                }
                comboBox3.SelectedIndex = -1;
            }
            if ((checkedListBox4.CheckedItems).Count > 0 && comboBox4.SelectedIndex != -1)
            {
                string days = "";
                foreach (object day in checkedListBox4.CheckedItems)
                {
                    days = days + (string)day;
                }
                dayBlocks.Add(days);
                timeBlocks.Add((string)comboBox4.SelectedItem);
                foreach (int i in checkedListBox4.CheckedIndices)
                {
                    checkedListBox4.SetItemCheckState(i, CheckState.Unchecked);
                }
                comboBox4.SelectedIndex = -1;
            }
            if ((checkedListBox5.CheckedItems).Count > 0 && comboBox5.SelectedIndex != -1)
            {
                string days = "";
                foreach (object day in checkedListBox5.CheckedItems)
                {
                    days = days + (string)day;
                }
                dayBlocks.Add(days);
                timeBlocks.Add((string)comboBox5.SelectedItem);
                foreach (int i in checkedListBox5.CheckedIndices)
                {
                    checkedListBox5.SetItemCheckState(i, CheckState.Unchecked);
                }
                comboBox5.SelectedIndex = -1;
            }
            RegistrationDatabase.CreateCourse(new Course(textBox10.Text, textBox9.Text, 
                (Faculty)RegistrationDatabase.GetUser((string)comboBox8.SelectedItem), textBox8.Text, Int32.Parse(textBox7.Text), dayBlocks, timeBlocks), textBox10.Text);
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            comboBox8.SelectedIndex = -1;

            Form2_Load(sender, e);
        }
    }
}
