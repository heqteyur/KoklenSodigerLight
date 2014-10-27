using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

                if(comboBox1.SelectedValue==null)
                {
                    UMessageBox.UShow("تاۋار تۈرى بوش قالدى.ياندىكى ئاستى سىزىق(تاۋار تۈرى) دېگەن خەتنى بېسىپ قوشسىڭىز بولىدۇ.", "ئەسكەرتىش", MessageBoxIcon.Error);
                    comboBox1.Focus();
                    return;
                }

                if (comboBox2.SelectedValue == null)
                {
                    UMessageBox.UShow("تاۋار بىرلىكى بوش قالدى.ياندىكى ئاستى سىزىق(بىرلىكى) دېگەن خەتنى بېسىپ قوشسىڭىز بولىدۇ.", "ئەسكەرتىش", MessageBoxIcon.Error);
                    comboBox2.Focus();
                    return;
                }

                if (textBox2.Text.Trim() == "")
                {
                    int barcode = DbHelperSQL.FutrueID("商品信息");
                    barcode += ConfigParams.BarCodeBase;
                    if(DialogResult.Yes == UMessageBox.UShow("تاياق كود بوش قالدى، تۆۋەندىكى ھاسىل كودنى ئىشلىتەمسىز؟\r\n"+barcode,"سۇئالىم بار",MessageBoxIcon.Question))
                    {
                        textBox2.Text = barcode.ToString();
                        return;
                    }
                    else
                    {
                        return;
                    }
                }

                List<SqlParameter> prmList = new List<SqlParameter>();

                if (DbHelperSQL.ExecuteSql("INSERT INTO 商品信息  VALUES (@名称, @分类, @规格型号, @条码, @单位, @品牌, @进价, @售价, @类型, @自设编号, @是否称重, @备注, @操作时间, @操作用户, @状态)", prmList.ToArray()) > 0)
                {

                }
            }
            else
            {

            }
        }

        private void ShangpinXinxiBianji_Load(object sender, EventArgs e)
        {
            LoadShangpinFenlei();

            LoadShangpinDanwei();

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

        private void LoadShangpinDanwei()
        {
            DataTable dtDanwei = DbHelperSQL.Query("select * from 商品单位").Tables[0];
            comboBox2.DataSource = dtDanwei;
            comboBox2.DisplayMember = "名称";
            comboBox2.ValueMember = "ID";
        }

        private void LoadShangpinFenlei()
        {
            DataTable dtFenlei = DbHelperSQL.Query("select * from 商品分类").Tables[0];
            comboBox1.DataSource = dtFenlei;
            comboBox1.DisplayMember = "名称";
            comboBox1.ValueMember = "ID";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ShangpinFenlei spfl = new ShangpinFenlei();
            spfl.ShowDialog();
            LoadShangpinFenlei();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ShangpinDanwei spdw = new ShangpinDanwei();
            spdw.ShowDialog();
            LoadShangpinDanwei();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
