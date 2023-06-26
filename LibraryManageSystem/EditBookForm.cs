using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LibraryManageSystem
{
    public partial class EditBookForm : Form
    {
        string ID = "";
        public EditBookForm()
        {
            InitializeComponent();
        }
        public EditBookForm(string id, string name, string author, string press, string number)
        {
            InitializeComponent();
            this.ID = id;
            textBox1.Text = id;
            textBox2.Text = name;
            textBox3.Text = author;
            textBox4.Text = press;
            textBox5.Text = number;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            string sql = $"update tb_book set id = '{textBox1.Text}', [name] = '{textBox2.Text}', author = '{textBox3.Text}', press = '{textBox4.Text}', number = '{textBox5.Text}' where id = '{ID}'";
            Dao dao = new Dao();
            if (dao.Execute(sql) > 0)
            {
                MessageBox.Show("修改成功！");
                this.Close();
            }
        }
    }
}
