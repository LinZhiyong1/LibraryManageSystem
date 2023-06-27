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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("请输入密码！");
                return;
            }
            if (radioButtonUser.Checked == true)
            {
                Dao dao = new Dao();
                string sql = $"select * from tb_user where id = '{textBox1.Text}' and password = '{textBox2.Text}'";
                IDataReader dataReader = dao.Read(sql);
                if (!dataReader.Read())
                {
                    MessageBox.Show("登录失败！请检查用户名及密码！");
                    return;
                }
                User.UserID = dataReader["id"].ToString();
                User.UserName = dataReader["name"].ToString();
                UserForm userForm = new UserForm();
                this.Hide();
                userForm.ShowDialog();
                this.Show();
                dao.DaoClose();
            }
            if (radioButtonAdmin.Checked == true)
            {
                Dao dao = new Dao();
                string sql = $"select * from tb_admin where id = '{textBox1.Text}' and password = '{textBox2.Text}'";
                IDataReader dataReader = dao.Read(sql);
                if (!dataReader.Read())
                {
                    MessageBox.Show("登录失败!请检查用户名及密码！");
                    return;
                }
                AdminForm adminForm = new AdminForm();
                this.Hide();
                adminForm.ShowDialog();
                this.Show();
                dao.DaoClose();
            }
        }
        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1_Click(sender, e);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SignInAccountForm addUserForm = new SignInAccountForm();
            Hide();
            addUserForm.ShowDialog();
            Show();
        }
    }
}
