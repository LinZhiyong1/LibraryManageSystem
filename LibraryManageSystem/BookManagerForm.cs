using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManageSystem
{
    public partial class BookManagerForm : Form
    {
        public BookManagerForm()
        {
            InitializeComponent();
        }
        private void ShowTable()
        {
            dataGridView1.Rows.Clear();
            bool isChecked = checkBox1.Checked;
            string statusStr = isChecked ? "where number > 0" : "";
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
        private void BookManagerForm_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                Name = "Modify",
                HeaderText = "更新"
            };
            btn.DefaultCellStyle.NullValue = "Modify";
            dataGridView1.Columns.Add(btn);

            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "删除"
            };
            btn2.DefaultCellStyle.NullValue = "Delete";
            dataGridView1.Columns.Add(btn2);
            ShowTable();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            AddBookForm addBookForm = new AddBookForm();
            addBookForm.ShowDialog();
            ShowTable();
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

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete" && e.RowIndex >= 0)
            {
                string id = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                DialogResult dialog = MessageBox.Show("确认删除吗？", "消息提示", MessageBoxButtons.OKCancel); // OK|Cancel
                if(DialogResult.Cancel == dialog)
                {
                    return;
                }
                string sql = $"delete from tb_book where id = '{id}'";
                string checksql = $"select * from tb_lend where bid = '{id}'";
                Dao dao = new Dao();
                IDataReader dataReader = dao.Read(checksql);
                if (dataReader.Read())
                {
                    MessageBox.Show($"bid:{id}还有借出记录！删除失败！");
                    return;
                } 
                if (dao.Execute(sql) > 0)
                {
                    MessageBox.Show("删除成功！");
                    ShowTable();
                }
                else
                { 
                    MessageBox.Show("删除失败！");
                }
                dao.DaoClose(); 
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Modify" && e.RowIndex >= 0)
            {
                string id = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                string name = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                string author = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                string press = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                string number = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                EditBookForm editBookForm = new EditBookForm(id, name, author, press, number);
                editBookForm.ShowDialog();
                ShowTable();
            }
        }

        private void Button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1_Click(this.button1, EventArgs.Empty);
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
