namespace CS390
{
    partial class LogInScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInScreen));
            this.login_title = new System.Windows.Forms.Label();
            this.user_label = new System.Windows.Forms.Label();
            this.pass_label = new System.Windows.Forms.Label();
            this.user_textbox = new System.Windows.Forms.TextBox();
            this.pass_textbox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bad_login_message = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // login_title
            // 
            resources.ApplyResources(this.login_title, "login_title");
            this.login_title.BackColor = System.Drawing.Color.Transparent;
            this.login_title.Name = "login_title";
            // 
            // user_label
            // 
            resources.ApplyResources(this.user_label, "user_label");
            this.user_label.BackColor = System.Drawing.Color.Transparent;
            this.user_label.Name = "user_label";
            // 
            // pass_label
            // 
            resources.ApplyResources(this.pass_label, "pass_label");
            this.pass_label.BackColor = System.Drawing.Color.Transparent;
            this.pass_label.Name = "pass_label";
            // 
            // user_textbox
            // 
            resources.ApplyResources(this.user_textbox, "user_textbox");
            this.user_textbox.Name = "user_textbox";
            // 
            // pass_textbox
            // 
            resources.ApplyResources(this.pass_textbox, "pass_textbox");
            this.pass_textbox.Name = "pass_textbox";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CS390.Properties.Resources.LoginScreenBackground;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // bad_login_message
            // 
            resources.ApplyResources(this.bad_login_message, "bad_login_message");
            this.bad_login_message.BackColor = System.Drawing.Color.Transparent;
            this.bad_login_message.ForeColor = System.Drawing.Color.DarkRed;
            this.bad_login_message.Name = "bad_login_message";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bad_login_message);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pass_textbox);
            this.Controls.Add(this.user_textbox);
            this.Controls.Add(this.pass_label);
            this.Controls.Add(this.user_label);
            this.Controls.Add(this.login_title);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label login_title;
        private System.Windows.Forms.Label user_label;
        private System.Windows.Forms.Label pass_label;
        private System.Windows.Forms.TextBox user_textbox;
        private System.Windows.Forms.TextBox pass_textbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label bad_login_message;
    }
}

