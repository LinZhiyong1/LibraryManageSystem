using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace LibraryManageSystem
{
    public partial class ReturnBookForm : Form
    {
        public ReturnBookForm()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string description = textBox1.Text;
            string sql = $"select * from tb_lend where bid like '%{description}%' or datetime like '%{description}%'";
            Dao dao = new Dao();
            IDataReader dataReader = dao.Read(sql);
            if (dataReader == null)
            {
                ShowTable();
                return;
            }
            while (dataReader.Read())
            {
                dataGridView1.Rows.Add(dataReader[0].ToString(), dataReader[2].ToString(), dataReader[3].ToString());
            }
            dataReader.Close();
            dao.DaoClose();
        }
        private void ShowTable()
        {
            dataGridView1.Rows.Clear();
            string sql = $"select * from tb_lend where uid = {Model.UID}";
            Dao dao = new Dao();
            IDataReader dataReader = dao.Read(sql);
            while (dataReader.Read())
            {
                dataGridView1.Rows.Add(dataReader[0].ToString(), dataReader[2].ToString(), dataReader[3].ToString());
            }
            dataReader.Close();
            dao.DaoClose();
        }

        private void ReturnBookForm_Load(object sender, EventArgs e)
        {
            ShowTable();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string no = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string bid = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string sql = $"delete from tb_lend where no = '{no}';update tb_book set number = number + 1 where id = '{bid}'";
            Dao dao = new Dao();
            if (dao.Execute(sql) > 1)
            {
                MessageBox.Show($"{Model.UName}已归还借阅号为{no}的图书");
                ShowTable();
            } 
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1_Click(sender, e);
            }
        }
    }
    
}
