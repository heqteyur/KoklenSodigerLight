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
    public partial class ShangpinFenlei : Form
    {
        public ShangpinFenlei()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShangpinFenlei_Load(object sender, EventArgs e)
        {
            LoadShangpinFenlei();
        }

        private void LoadShangpinFenlei()
        {
            listBox1.DataSource = DbHelperSQL.Query("select * from 商品分类 where 状态=1").Tables[0];
            listBox1.DisplayMember = "名称";
            listBox1.ValueMember = "ID";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim()=="")
            {
                UMessageBox.UShow("تاۋار تۈرى نامى بوش قالدى", "ئەسكەرتىش", MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            if(DbHelperSQL.Exists("select ID from 商品分类 where 名称=@名称",new SqlParameter("@名称",textBox1.Text.Trim())) && textBox1.Text.Trim()!=listBox1.Text)
            {
                UMessageBox.UShow("بۇ تاۋار تۈرى نامى مەۋجۈت", "ئەسكەرتىش", MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            if(button3.Text=="تەھرىرلەش")
            {
                if (DbHelperSQL.ExecuteSql("INSERT INTO 商品分类 VALUES(@名称,1)", new SqlParameter("@名称", textBox1.Text.Trim())) > 0)
                {
                    LoadShangpinFenlei();
                    textBox1.Clear();
                    textBox1.Focus();
                }
            }
            else
            {
                if (DbHelperSQL.ExecuteSql("UPDATE 商品分类 set 名称=@名称 where ID=@ID", new SqlParameter("@名称", textBox1.Text.Trim()),new SqlParameter("@ID",listBox1.SelectedValue.ToString())) > 0)
                {
                    LoadShangpinFenlei();
                    textBox1.Clear();
                    textBox1.Focus();
                    button3_Click(button3, new EventArgs());
                }
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(button3.Text=="تەھرىرلەش")
            {
                textBox1.BackColor = Color.PaleVioletRed;
                listBox1.Enabled = false;
                button3.Text = "بىكارلاش";
                textBox1.Text = listBox1.Text;
            }
            else
            {
                textBox1.BackColor = Color.White;
                listBox1.Enabled = true;
                button3.Text = "تەھرىرلەش";
                textBox1.Clear();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(button3.Text!="تەھرىرلەش")
            {
                UMessageBox.UShow("تەھرىرلەش ھالىتىدە ئۆچۈرۈشكە بولمايدۇ", "ئەسكەرتىش", MessageBoxIcon.Error);
                return;
            }
            if(DialogResult.Yes==UMessageBox.UShow("تاللانغان تۈرنى راستلا ئۆچۈرەمسىز؟","ئەسكەرتىش",MessageBoxIcon.Question))
            {
                if (DbHelperSQL.ExecuteSql("UPDATE 商品分类 set 状态=0 where ID=@ID", new SqlParameter("@ID", listBox1.SelectedValue.ToString())) > 0)
                {
                    LoadShangpinFenlei();
                }
            }
        }
    }
}
