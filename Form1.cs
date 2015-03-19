using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeyTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            label2.Text = "Count : 0";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Interval = 10;
            if(checkBox1.Checked)
            {
                progressBar1.Value = 0;
                timer1.Enabled = true;
                button1.Visible = false;
                progressBar1.Visible = true;
            }
            else
            {
                timer1.Enabled = false;
                progressBar1.Visible = false;
                button1.Visible = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0) return;
            if(progressBar1.Value != progressBar1.Maximum) 
                progressBar1.Value++;
            else
            {
                if (timer1.Interval != 1000)
                {
                    timer1.Interval = 1000;
                    return;
                }
                else
                {
                    timer1.Interval = 10;
                    progressBar1.Value = 0;
                    button1_Click(this, null);
                    return;
                }
            }    
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            String keyinfo = e.KeyCode.ToString() + ";" + e.KeyValue.ToString() + ";" + e.Modifiers.ToString();
            ListViewItem newItem = new ListViewItem(keyinfo.Split(';'));
            listView1.Items.Add(newItem);
            newItem.EnsureVisible();
            label2.Text = "Count : " + listView1.Items.Count.ToString();
        }
    }
}
