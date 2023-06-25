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
    public partial class LendBookForm : Form
    {
        public LendBookForm()
        {
            InitializeComponent();
        }
        private void ShowTable()
        {
            bool isChecked = checkBox1.Checked;
            string statusStr = isChecked ? "where number > 0" : "";
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = $"select * from tb_book {statusStr}";
            IDataReader dataReader = dao.Read(sql);
            while (dataReader.Read())
            {
                dataGridView1.Rows.Add(dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), dataReader[4].ToString());
            }
            dataReader.Close();
            dao.DaoClose();
        }
        private string GetUUID()
        {
            Guid guid = Guid.NewGuid();
            string uuid = guid.ToString().Substring(0,8);
            return uuid;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            int number = Convert.ToInt16 (dataGridView1.CurrentRow.Cells[4].Value);
            if (number < 1)
            {
                MessageBox.Show("库存不足");
                return;
            }
            string sql = $"insert into tb_lend (no,[uid],bid,[datetime]) values('{GetUUID()}','{Model.UID}','{id}', getdate())update tb_book set number = number - 1 where id = '{id}'";
            Dao dao = new Dao();
            if (dao.Execute(sql)>1)
            {
                MessageBox.Show($"{Model.UName}已借出《{name}》");
                ShowTable();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string description = textBox1.Text;
            if (string.IsNullOrEmpty(description))
            {
                ShowTable();
                return;
            }
            bool isChecked = checkBox1.Checked;
            string statusStr = isChecked ? "where number > 0 and " : "where";
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = $"select * from tb_book {statusStr} id like '%{description}%' or name like '%{description}%'";
            IDataReader dataReader = dao.Read(sql);
            while (dataReader.Read())
            {
                dataGridView1.Rows.Add(dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), dataReader[4].ToString());
            }
            dataReader.Close();
            dao.DaoClose();
        }

        private void LendBookForm_Load(object sender, EventArgs e)
        {
            ShowTable();
        }
    }
}
