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
using System.Threading;


namespace KoklenSodigerLight
{
    public partial class ShangpinXinxi : Form
    {
        public ShangpinXinxi()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private DataTable dtShangpinXinxi;
        private void ShangpinXinxi_Load(object sender, EventArgs e)
        {
            Utility.DGVColumnWidthAutomation(dataGridView1);
            new Thread(new ThreadStart(LoadShangpinXinxiThread)).Start();
        }

        private void LoadShangpinXinxiThread()
        {
            Thread.Sleep(50);
            this.Invoke(new MethodInvoker(LoadShangpinXinxi));
        }
        private void LoadShangpinXinxi()
        {
            dtShangpinXinxi = CommonData.GetShangpinXinxi();
            dataGridView1.DataSource = dtShangpinXinxi;
            Utility.SwitchVisibleOfDGV(dataGridView1, false, "分类", "单位", "类型","状态");

            dataGridView1.Columns["ID"].HeaderText = "رېتى";
            dataGridView1.Columns["名称"].HeaderText = "تاۋار نامى";
            dataGridView1.Columns["分类名称"].HeaderText = "تاۋار تۈرى";
            dataGridView1.Columns["规格型号"].HeaderText = "ئۆلچەم تىپ";
            dataGridView1.Columns["条码"].HeaderText = "تاياق كود";
            dataGridView1.Columns["单位名称"].HeaderText = "بىرلىك";
            dataGridView1.Columns["品牌"].HeaderText = "ماركا";
            dataGridView1.Columns["进价"].HeaderText = "كىرىش باھاسى";
            dataGridView1.Columns["售价"].HeaderText = "سېتىش باھاسى";
            dataGridView1.Columns["自设编号"].HeaderText = "ئۆز كودى";
            dataGridView1.Columns["库存数量"].HeaderText = "ئامباردىكى سانى";
            dataGridView1.Columns["是否称重"].HeaderText = "تارازىدىمۇ";
            dataGridView1.Columns["备注"].HeaderText = "ئىزاھات";
            dataGridView1.Columns["操作时间"].HeaderText = "مەشغۇلات ۋاقتى";
            dataGridView1.Columns["操作用户"].HeaderText = "مەشغۇلات قىلغۇچى";

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

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            string text=toolStripTextBox1.Text.Trim().Replace("'","").Replace("[","");
            DataView dv = dtShangpinXinxi.DefaultView;
            string filter = String.Format("条码 like '{0}%' or 名称 like '{0}%' or 自设编号 like '{0}%'", text);
            dv.RowFilter = filter;
            dataGridView1.DataSource = dv;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            KuCunDanju kcdj = new KuCunDanju();
            kcdj.Operation = "RUKU";
            kcdj.Text = "ئامبارغا تاۋار كىرگۈزۈش";
            kcdj.ShowDialog();
        }



    }


}
