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
        private void BookManagerForm_Load(object sender, EventArgs e)
        {
            ShowTable();
            dataGridView1.ClearSelection();
        }
        private void ShowTable()
        {
            dataGridView1.Rows.Clear();
            bool isChecked = checkBox1.Checked;
            string whereStr = isChecked ? "where availableCount > 0" : "";
            Dao dao = new Dao();
            string sql = $"select * from LibraryBook {whereStr}";
            IDataReader dataReader = dao.Read(sql);
            while (dataReader.Read())
            {
                dataGridView1.Rows.Add(
                    dataReader[0].ToString(), 
                    dataReader[1].ToString(), 
                    dataReader[2].ToString(),
                    dataReader[3].ToString(), 
                    dataReader[4].ToString(),
                    dataReader[5].ToString(),
                    dataReader[6].ToString(),
                    dataReader[7].ToString(),
                    dataReader[8].ToString(),
                    dataReader[9].ToString(),
                    dataReader[10].ToString()
                    );
            }
            dataReader.Close();
            dao.DaoClose();
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
        private void Button2_Click(object sender, EventArgs e)
        {
            AddBookForm addBookForm = new AddBookForm();
            addBookForm.ShowDialog();
            ShowTable();
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
