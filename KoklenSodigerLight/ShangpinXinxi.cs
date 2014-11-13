using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maticsoft.DBUtility;
using System.Net;
using System.Data.SqlClient;


namespace KoklenSodigerLight
{
    public partial class ShangpinXinxi : Form
    {
        public ShangpinXinxi()
        {
            InitializeComponent();
        }

        private DataTable dtShangpinXinxi;
        private void ShangpinXinxi_Load(object sender, EventArgs e)
        {
            Utility.DGVColumnWidthAutomation(dataGridView1);
            LoadShangpinXinxi();

            toolStripComboBox1.ComboBox.DataSource = ComonData.GetFilterDataTable();
            toolStripComboBox1.ComboBox.DisplayMember = "Name";
            toolStripComboBox1.ComboBox.ValueMember = "Value";
            
        }

        private void LoadShangpinXinxi()
        {
            dtShangpinXinxi = ComonData.GetShangpinXinxi();
            dataGridView1.DataSource = dtShangpinXinxi;
            Utility.SwitchVisibleOfDGV(dataGridView1, false, "分类", "单位", "类型","状态");

            dataGridView1.Columns["ID"].HeaderText = "رېتى";
            dataGridView1.Columns["名称"].HeaderText = "";
            dataGridView1.Columns["分类名称"].HeaderText = "";
            dataGridView1.Columns["规格型号"].HeaderText = "";
            dataGridView1.Columns["条码"].HeaderText = "";
            dataGridView1.Columns["单位名称"].HeaderText = "";
            dataGridView1.Columns["品牌"].HeaderText = "";
            dataGridView1.Columns["进价"].HeaderText = "";
            dataGridView1.Columns["售价"].HeaderText = "";
            dataGridView1.Columns["自设编号"].HeaderText = "";
            dataGridView1.Columns["是否称重"].HeaderText = "";
            dataGridView1.Columns["备注"].HeaderText = "";
            dataGridView1.Columns["操作时间"].HeaderText = "";
            dataGridView1.Columns["操作用户"].HeaderText = "";

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
            if(dataGridView1.SelectedRows.Count>0)
            {
                if (DialogResult.Yes == UMessageBox.UShow("بۇ تاۋارنى راستلا ئۆچۈرەمسىز؟\r\n" + dataGridView1.SelectedRows[0].Cells["名称"].Value.ToString(), "", MessageBoxIcon.Question))
                {
                    if (DbHelperSQL.ExecuteSql("DELETE FROM 商品信息 WHERE ID=@ID", new SqlParameter("@ID", dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString())) > 0)
                    {
                        dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                    }
                    
                }
            }

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            toolStripStatusLabel2.Text = dataGridView1.Rows.Count.ToString();
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(toolStripComboBox1.ComboBox.SelectedValue.ToString()=="名称")
            {
                toolStripTextBox1.RightToLeft = RightToLeft.Yes;
            }
            else
            {
                toolStripTextBox1.RightToLeft = RightToLeft.No;
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            string text=toolStripTextBox1.Text.Trim().Replace("'","").Replace("[","");
            DataView dv = dtShangpinXinxi.DefaultView;
            string filter = String.Format("{0} like '{1}%'" ,toolStripComboBox1.ComboBox.SelectedValue.ToString() ,text );
            dv.RowFilter = filter;
            dataGridView1.DataSource = dv;
        }



    }


}
