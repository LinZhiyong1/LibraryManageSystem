using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LibraryManageSystem
{
    public partial class LendBookForm : Form
    {
        public DataSet ds = null;
        Model model = new Model();
        public LendBookForm()
        {
            InitializeComponent();
            ds = new DataSet("LibraryBook");
        }
        private void ShowTable()
        {
            try
            {
                dataGridView1.Rows.Clear();

                bool isChecked = checkBox1.Checked;

                string sql =
                    $"select * from LibraryBook " +
                    $"{(isChecked ? "where availableCount > 0" : "")} ";

                SqlDataAdapter adapter = model.Adapter(sql);

                adapter.Fill(ds, "LibraryBook");

                dataGridView1.DataSource = ds.Tables["LibraryBook"];
            }

            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            finally
            {
                model.ModelClose();
            }

        }

        private string GetUUID()
        {
            Guid guid = Guid.NewGuid();
            string uuid = guid.ToString().Substring(0, 8);
            return uuid;
        }
        private void LendBook(int index)
        {
            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string name = dataGridView1.Rows[index].Cells[1].Value.ToString();
            int number = Convert.ToInt16(dataGridView1.Rows[index].Cells[4].Value);
            if (number < 1)
            {
                MessageBox.Show("库存不足");
                return;
            }
            string sql = $"insert into tb_lend (no,[uid],bid,[datetime]) values('{GetUUID()}','{User.UserID}','{id}', getdate())update tb_book set number = number - 1 where id = '{id}'";
            Dao dao = new Dao();
            if (dao.Execute(sql) > 1)
            {
                MessageBox.Show($"{User.UserName}已借出《{name}》");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            Model model = new Model();

            try
            {
                dataGridView1.Rows.Clear();

                string desc = textBox1.Text;

                if (string.IsNullOrEmpty(desc))
                {
                    ShowTable();
                    return;
                }

                bool isChecked = checkBox1.Checked;

                string sql =
                    $"select * from LibraryBook " +
                    $"{(isChecked ? "where availableCount > 0" : "")} ";

                SqlDataAdapter adapter = model.Adapter(sql);

                adapter.Fill(ds, "LibraryBook");

                dataGridView1.DataSource = ds.Tables["LibraryBook"];
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            finally
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    model.ModelClose();
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.SelectedRows.Count;
            if (n > 1)
            {
                for (int i = 0; i < n; i++)
                {
                    LendBook(dataGridView1.Rows[i].Index);
                }
                ShowTable();
                return;
            }
            LendBook(dataGridView1.CurrentRow.Index);
            ShowTable();
        }

        

        private void LendBookForm_Load(object sender, EventArgs e)
        {
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
