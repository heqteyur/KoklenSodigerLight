using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

        public static string LoginUsser = "Mahmutjan";
        public static NumberFormatInfo nfi;

        private void تاۋارئاساسىيئۇچۇرىToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ShangpinXinxi spxx = new ShangpinXinxi();
            spxx.ShowDialog();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            nfi = new NumberFormatInfo();
            nfi.NumberDecimalDigits = 3;
        }

        
    }
}
