using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Resources.ResXFileRef;

namespace LibraryManageSystem
{
    class Model
    {
        SqlDataAdapter adapter;
        SqlCommand cmd; 
        SqlConnection conn; 
        public SqlConnection Connection()
        {
            string sqlServer = "Data Source=YANFA05;Initial Catalog=LibraryDB;Integrated Security=True";
            conn = new SqlConnection(sqlServer);
            conn.Open();
            return conn;
        }

        public SqlDataAdapter Adapter(string sql)
        {
            cmd = new SqlCommand(sql, Connection());
            adapter = new SqlDataAdapter(cmd);
            return adapter;
        }

        public void ModelClose()
        {
            conn.Close();
        }
    }
}
