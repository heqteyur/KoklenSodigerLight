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

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DbHelperSQLite.Query("select * from 商品信息").Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DbHelperSQLite.ExecuteSql("insert into 商品信息 values(NULL,'name','1')");
        }


    }


}
