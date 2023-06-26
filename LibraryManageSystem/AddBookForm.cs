using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManageSystem
{
    public partial class AddBookForm : Form
    {
        public AddBookForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("存在未输入的图书信息！请输入完整！");
                return;
            }
            string sql = $"insert into tb_book values('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{textBox5.Text}')";
            string checkSql = $"select * from tb_book where id = '{textBox1.Text}'";
            IDataReader dataReader = dao.Read(checkSql);
            if (dataReader.Read())
            {
                MessageBox.Show("该书号已存在！请重新输入！");
                return;
            } 
            int lines = dao.Execute(sql);
            if(lines > 0)
            {
                MessageBox.Show("添加成功！");
                Close();
            }
            else
            {
                MessageBox.Show("添加失败！");
            }
            ClearTextBox();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }
        private void ClearTextBox()
        {
            foreach (Control c in Controls) { if (c is TextBox) { c.Text = ""; } }
        }

        private void AddBookForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1_Click(sender, e);
            }
        }
    }
}
