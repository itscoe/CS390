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
    public partial class ChangeTime : Form
    {
        public ChangeTime()
        {
            InitializeComponent();
        }

        private void ChangeTime_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> dayBlocks = new List<string>();
            List<string> timeBlocks = new List<string>();
            if ((checkedListBox1.CheckedItems).Count > 0 && comboBox1.SelectedValue != null)
            {
                string days = "";
                foreach (object day in checkedListBox1.CheckedItems)
                {
                    days = days + (string)day;
                }
                dayBlocks.Add(days);
                timeBlocks.Add((string)comboBox1.SelectedItem);
            }
            if ((checkedListBox2.CheckedItems).Count > 0 && comboBox2.SelectedValue != null)
            {
                string days = "";
                foreach (object day in checkedListBox2.CheckedItems)
                {
                    days = days + (string)day;
                }
                dayBlocks.Add(days);
                timeBlocks.Add((string)comboBox2.SelectedItem);
            }
            if ((checkedListBox3.CheckedItems).Count > 0 && comboBox3.SelectedValue != null)
            {
                string days = "";
                foreach (object day in checkedListBox3.CheckedItems)
                {
                    days = days + (string)day;
                }
                dayBlocks.Add(days);
                timeBlocks.Add((string)comboBox3.SelectedItem);
            }
            if ((checkedListBox4.CheckedItems).Count > 0 && comboBox4.SelectedValue != null)
            {
                string days = "";
                foreach (object day in checkedListBox4.CheckedItems)
                {
                    days = days + (string)day;
                }
                dayBlocks.Add(days);
                timeBlocks.Add((string)comboBox4.SelectedItem);
            }
            if ((checkedListBox5.CheckedItems).Count > 0 && comboBox5.SelectedValue != null)
            {
                string days = "";
                foreach (object day in checkedListBox5.CheckedItems)
                {
                    days = days + (string)day;
                }
                dayBlocks.Add(days);
                timeBlocks.Add((string)comboBox5.SelectedItem);
            }
            if (dayBlocks.Count > 0)
            {

            }
        }
    }
}
