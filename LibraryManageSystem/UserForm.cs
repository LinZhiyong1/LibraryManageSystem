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
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }

        private void 图书的查看和借阅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LendBookForm lendBookForm = new LendBookForm();
            lendBookForm.ShowDialog();
        }

        private void 当前ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnBookForm returnBookForm = new ReturnBookForm();
            returnBookForm.ShowDialog();
        }
    }
}
