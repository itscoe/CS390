using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS390
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            login_title.Parent = pictureBox1;
            user_label.Parent = pictureBox1;
            pass_label.Parent = pictureBox1;
            bad_login_message.Parent = pictureBox1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (user_textbox.Text == "admin" && pass_textbox.Text == "admin") {
                Form2 form2 = new Form2();
                form2.Show();
                Hide();
            } else {
                bad_login_message.Visible = true;
            }
        }
    }
}
