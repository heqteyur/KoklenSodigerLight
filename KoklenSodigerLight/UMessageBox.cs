using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KoklenSodigerLight
{
    public partial class UMessageBox : Form
    {
        public UMessageBox()
        {
            InitializeComponent();
        }

        private void UMessageBox_Load(object sender, EventArgs e)
        {
            textBox1.GotFocus += textBox1_GotFocus;
        }

        void textBox1_GotFocus(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }

        public static DialogResult UShow(string Message,string Caption)
        {
            UMessageBox ub = new UMessageBox();
            ub.Text = Caption;
            ub.textBox1.Text = Message;
            ub.button1.Visible = false;
            ub.button2.Visible = false;
            ub.pictureBox1.Image = Properties.Resources.ok24;
            return ub.ShowDialog();
        }

        public static DialogResult UShow(string Message, string Caption, MessageBoxIcon icon)
        {
            UMessageBox ub = new UMessageBox();
            ub.Text = Caption;
            ub.textBox1.Text = Message;
            ub.button1.Visible = false;
            ub.button2.Visible = false;
            if(icon==MessageBoxIcon.Error)
            {
                ub.pictureBox1.Image = Properties.Resources.error24;
            }
            if (icon == MessageBoxIcon.Information)
            {
                ub.pictureBox1.Image = Properties.Resources.info24;
            }
            if (icon == MessageBoxIcon.Warning)
            {
                ub.pictureBox1.Image = Properties.Resources.warning24;
            }
            if (icon == MessageBoxIcon.None)
            {
                ub.pictureBox1.Image = Properties.Resources.ok24;
                
            }
            if (icon == MessageBoxIcon.Question)
            {
                ub.pictureBox1.Image = Properties.Resources.question24;
                ub.button3.Visible = false;
                ub.button1.Visible = true;
                ub.button2.Visible = true;
                System.Media.SystemSounds.Question.Play();
            }
            return ub.ShowDialog();
        }

        private void UMessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
