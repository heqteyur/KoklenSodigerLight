﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maticsoft.DBUtility;

namespace KoklenSodigerLight
{
    public partial class ShangpinXinxi : Form
    {
        public ShangpinXinxi()
        {
            InitializeComponent();
        }

        private void ShangpinXinxi_Load(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ShangpinXinxiBianji spxxbj = new ShangpinXinxiBianji();
            spxxbj.Text += "(قوشۇش)";
            spxxbj.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ShangpinXinxiBianji spxxbj = new ShangpinXinxiBianji();
            spxxbj.Text += "(تەھرىرلەش)";
            spxxbj.ShowDialog();
        }



    }


}
