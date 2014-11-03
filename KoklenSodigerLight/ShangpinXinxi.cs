using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maticsoft.DBUtility;
using System.Net;


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
            Utility.DGVColumnWidthAutomation(dataGridView1);
            LoadShangpinXinxi();

            DataSet1 ds1 = new DataSet1();
            ds1.Tables["SearchFilter"].Rows.Add("تاياق كود", "条码");
            ds1.Tables["SearchFilter"].Rows.Add("تاۋار نامى", "名称");
            ds1.Tables["SearchFilter"].Rows.Add("ئۆز كود", "自设编码");
            toolStripComboBox1.ComboBox.DataSource = ds1.Tables["SearchFilter"];
            toolStripComboBox1.ComboBox.DisplayMember = "Name";
            toolStripComboBox1.ComboBox.ValueMember = "Value";
            
        }

        private void LoadShangpinXinxi()
        {
            dataGridView1.DataSource = DbHelperSQL.Query("SELECT 商品信息.ID, 商品信息.名称, 商品信息.分类, 商品信息.规格型号, 商品单位.名称 AS 单位名称,商品信息.条码, 商品信息.单位, 商品信息.品牌, 商品信息.进价, 商品信息.售价, 商品信息.类型, 商品信息.自设编号, 商品信息.是否称重, 商品信息.备注, 商品信息.操作时间, 商品信息.操作用户, 商品信息.状态, 商品分类.名称 AS 分类名称 FROM  商品信息 LEFT OUTER JOIN 商品单位 ON 商品信息.单位 = 商品单位.ID LEFT OUTER JOIN 商品分类 ON 商品信息.分类 = 商品分类.ID WHERE  (商品信息.状态 = 1)").Tables[0];
            Utility.SwitchVisibleOfDGV(dataGridView1, false, "分类", "单位", "状态");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ShangpinXinxiBianji spxxbj = new ShangpinXinxiBianji();
            spxxbj.Text += "(قوشۇش)";
            spxxbj.ShowDialog();
            if(spxxbj.Operation=="Added")
            {
                LoadShangpinXinxi();
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
            }

            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count>0)
            {
                ShangpinXinxiBianji spxxbj = new ShangpinXinxiBianji();
                spxxbj.dr = dataGridView1.SelectedRows[0];
                spxxbj.Text += "(تەھرىرلەش)";
                spxxbj.ShowDialog();
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {


        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            toolStripStatusLabel2.Text = dataGridView1.Rows.Count.ToString();
        }



    }


}
