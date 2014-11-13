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
    public partial class MiddleButton : UserControl
    {
        public MiddleButton()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Orange;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        private Image buttonImage;
        public event EventHandler ButtonClick;
        private string buttonText;

        [Browsable(true)]
        public string ButtonText
        {
            get { return buttonText; }
            set
            {
                buttonText = value;
                label2.Text = buttonText;
            }
        }
        private string buttonDescription;

        [Browsable(true)]
        public string ButtonDescription
        {
            get { return buttonDescription; }
            set
            {
                buttonDescription = value;
                label3.Text = buttonDescription;
            }
        }

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(ButtonClick!=null)
            {
                ButtonClick(this, e);
            }
        }
    }
}
