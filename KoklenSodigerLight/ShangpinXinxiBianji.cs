using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KoklenSodigerLight
{
    public partial class ShangpinXinxiBianji : Form
    {
        public ShangpinXinxiBianji()
        {
            InitializeComponent();
        }

        public string EditID;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(EditID==null)
            {
                if(textBox1.Text.Trim()=="")
                {
                    UMessageBox.UShow("تاۋار نامى بوش قالدى.", "ئەسكەرتىش", MessageBoxIcon.Error);
                    textBox1.Focus();
                    return;
                }
            }
            else
            {

            }
        }

        private void ShangpinXinxiBianji_Load(object sender, EventArgs e)
        {
            DataSet1 ds1 = new DataSet1();

            ds1.Tables["ProductType"].Rows.Add("سانى بار مەھسۇلات", "Product");
            ds1.Tables["ProductType"].Rows.Add("سانى يوق مۇلازىمەت", "Service");
            comboBox3.DataSource = ds1.Tables["ProductType"];
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Value";

            ds1.Tables["Weight"].Rows.Add("ياق", "0");
            ds1.Tables["Weight"].Rows.Add("ھەئە", "1");
            comboBox4.DataSource = ds1.Tables["Weight"];
            comboBox4.DisplayMember = "Name";
            comboBox4.ValueMember = "Value";

            Utility.AddEnterTabOrder(groupBox1);
        }
    }
}
