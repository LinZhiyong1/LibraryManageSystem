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
    public partial class BookManagerForm : Form
    {
        public BookManagerForm()
        {
            InitializeComponent();
        }
        private void showTable()
        {
            //bool isChecked = checkBox1.Checked;
            //char symbol = isChecked ? '>' : '=';
            //string sql = $"select * from tb_book where number {symbol} 0";
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = $"select * from tb_book";
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
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "Modify";
            btn.HeaderText = "操作";
            btn.DefaultCellStyle.NullValue = "修改";
            dataGridView1.Columns.Add(btn);
            
            /*DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
            btn2.Name = "delete";
            btn2.HeaderText = "操作";
            btn2.DefaultCellStyle.NullValue = "删除";
            dataGridView1.Columns.Add(btn2);*/  
            showTable();
        }
    }
}
