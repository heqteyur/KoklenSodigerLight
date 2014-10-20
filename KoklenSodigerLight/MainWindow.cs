using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KoklenSodigerLight
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void تاۋارئاساسىيئۇچۇرىToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShangpinXinxi spxx = new ShangpinXinxi();
            spxx.Show();
        }
    }
}
