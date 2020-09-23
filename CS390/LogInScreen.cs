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
    public partial class LogInScreen : Form
    {
        internal static User current_user;

        public LogInScreen()
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
            current_user = User.LogIn(user_textbox.Text, pass_textbox.Text);

            if (current_user is null)
            {
                bad_login_message.Visible = true;
            } else
            {
                StudentDashboard form2 = new StudentDashboard();
                form2.Show();
                Hide();
            }
        }
    }
}
