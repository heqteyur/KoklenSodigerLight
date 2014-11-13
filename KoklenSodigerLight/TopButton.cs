using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace KoklenSodigerLight
{
    [DefaultEvent("ButtonClick")]
    public partial class TopButton : UserControl
    {
        public TopButton()
        {
            InitializeComponent();
        }

        private Color originalBackColor;
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            originalBackColor = label1.BackColor;
            label1.BackColor = Color.Cyan;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = originalBackColor;
        }

        private string buttonText;
        private Image buttonImage;
        public event EventHandler ButtonClick;

        [Browsable(true)]
        public Image ButtonImage
        {
            get { return buttonImage; }
            set
            {
                buttonImage = value;
                pictureBox1.Image = buttonImage;
            }
        }

        [Browsable(true)]
        public string ButtonText
        {
            get { return buttonText; }
            set
            {
                buttonText = value;
                label1.Text = buttonText;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if(ButtonClick!=null)
            {
                ButtonClick(this, e);
            }
        }


    }
}
