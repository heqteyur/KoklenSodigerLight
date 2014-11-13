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
    public partial class SideButton : UserControl
    {
        public SideButton()
        {
            InitializeComponent();
        }

        private Color originalBackColor;

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            originalBackColor = this.BackColor;
            this.BackColor = Color.Cyan;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = originalBackColor;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(ButtonClick!=null)
            {
                ButtonClick(this, e);
            }
        }



    }
}
