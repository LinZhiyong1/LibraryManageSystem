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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void 管理图书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookManagerForm bookForm = new BookManagerForm();
            bookForm.ShowDialog();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }
    }
}
