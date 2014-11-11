using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maticsoft.DBUtility;
using System.Data.SqlClient;

namespace KoklenSodigerLight
{
    public class Utility
    {
        public static void AddEnterTabOrder(Control containerControl)
        {
            foreach(Control c in containerControl.Controls)
            {
                c.GotFocus += c_GotFocus;
                c.LostFocus += c_LostFocus;
                c.KeyDown += c_KeyDown;
            }
        }

        static void c_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
            }
        }

        static void c_LostFocus(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.White;
        }

        static void c_GotFocus(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.Cyan;
        }

        public static void SwitchVisibleOfDGV(DataGridView dgv,bool switcher,params string[] columns)
        {
            if(dgv!=null)
            {
                foreach(string columnName in columns)
                {
                    dgv.Columns[columnName].Visible = switcher;
                }
            }
        }

        public static void SetConfig(string key,string value)
        {
            if (DbHelperSQL.Exists("select ID from 系统参数 where 键=@键", new SqlParameter("@键", key)))
            {
                DbHelperSQL.ExecuteSql("update 系统参数 set 值=@值 where 键=@键", new SqlParameter("@键", key), new SqlParameter("@值", value));
            }
            else
            {
                DbHelperSQL.ExecuteSql("insert into 系统参数 values(@键,@值)", new SqlParameter("@键", key), new SqlParameter("@值", value));
            }
        }

        public static string GetConfig(string key)
        {
            object obj = DbHelperSQL.GetSingle("select 值 from 系统参数 where 键=@键", new SqlParameter("@键", key));
            return obj == null ? null : obj.ToString();
        }

        public static void DGVColumnWidthAutomation(DataGridView dgv)
        {
            dgv.ColumnWidthChanged += dgv_ColumnWidthChanged;
            dgv.DataSourceChanged += dgv_DataSourceChanged;
            dgv.CellMouseClick += dgv_CellMouseClick;
        }

        static void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right)
            {
                DataGridView dgv = ((DataGridView)sender);
                dgv.Columns[e.ColumnIndex].Width = dgv.Columns[e.ColumnIndex].GetPreferredWidth(DataGridViewAutoSizeColumnMode.DisplayedCells, true);
            }
        }

        static void dgv_DataSourceChanged(object sender, EventArgs e)
        {
            DataGridView dgv = ((DataGridView)sender);
            string configValue = GetConfig(dgv.FindForm().Name + "_" + dgv.Name);
            if(configValue!=null)
            {
                string[] configValues = configValue.Split(';');
                for(int i=0;i<dgv.Columns.Count;i++)
                {
                    dgv.Columns[i].Width = int.Parse(configValues[i]);
                }
            }
        }

        static void dgv_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            DataGridView dgv=((DataGridView)sender);
            StringBuilder sb = new StringBuilder();
            foreach(DataGridViewColumn column in dgv.Columns)
            {
                sb.Append(column.Width + ";");
            }
            SetConfig(dgv.FindForm().Name + "_" + dgv.Name, sb.ToString());
        }

        public static void InitializeDataGridViewRowBySqlParameter(DataGridViewRow dgvr,params SqlParameter[] parameters)
        {
            foreach(SqlParameter prm in parameters)
            {
                dgvr.Cells[prm.ParameterName.Replace("@","")].Value = prm.Value.ToString();
            }
        }
    }
}
