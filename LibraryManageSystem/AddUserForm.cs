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
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            char? sex;
            if (radioButtonSex1.Checked == true)
            {
                sex = '男';
            }
            else
            {
                sex = '女';
            }
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("密码不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("请确认密码！");
                return;
            }
            if (!textBox2.Text.Equals(textBox3.Text))
            {
                MessageBox.Show("两次输入的密码不一致！");
                return;
            }
            if (radioButtonRose1.Checked == true)
            {
                if (string.IsNullOrEmpty(textBox4.Text))
                {
                    MessageBox.Show("用户名称不能为空！");
                    return;
                }
                string id = textBox1.Text;
                string sql = $"select * from tb_user where id = '{id}'";
                Dao dao = new Dao();
                IDataReader dataReader = dao.Read(sql);
                if (dataReader.Read())
                {
                    MessageBox.Show("用户已存在！");
                    return;
                }
                string addSql = $"insert into tb_user values('{textBox1.Text}','{textBox4.Text}','{sex}','{textBox2.Text}')";
                if (dao.Execute(addSql) > 0)
                {
                    MessageBox.Show("注册成功！请登录重新！");
                    Close();
                }
            }
            else
            {
                string id = textBox1.Text;
                string sql = $"select * from tb_admin where id = '{id}'";
                Dao dao = new Dao();
                IDataReader dataReader = dao.Read(sql);
                if (dataReader.Read())
                {
                    MessageBox.Show("用户已存在！");
                    return;
                }
                string addSql = $"insert into tb_admin values('{textBox1.Text}','{textBox2.Text}')";
                if (dao.Execute(addSql) > 0)
                {
                    MessageBox.Show("注册成功！请登录重新！");
                    Close();
                }
            }
        }
        private void AddUserForm_Load(object sender, EventArgs e)
        {

        }
        private void RadioButtonRose2_Click(object sender, EventArgs e)
        {
            label4.Hide();
            labelSex.Hide();
            textBox4.Hide();
            radioButtonSex1.Hide();
            radioButtonSex2.Hide();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void RadioButtonRose1_Click(object sender, EventArgs e)
        {
            label4.Show();
            labelSex.Show();
            textBox4.Show();
            radioButtonSex1.Show();
            radioButtonSex2.Show();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        private void AddUserForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1_Click(sender, e);
            }
        }
    }
}
