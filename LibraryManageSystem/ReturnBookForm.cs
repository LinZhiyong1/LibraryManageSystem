﻿using System;
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

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void ShowTable()
        {
            string sql = $"select bid datetime from tb_lend where uid = {Model.UID} and name = {Model.UName}";
            Dao dao = new Dao();
            dao.Execute(sql);
        }
    }
    
}
