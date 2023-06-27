using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManageSystem
{
    class Dao
    {
        SqlConnection sqlConnection;
        public SqlConnection Connection()
        {
            string ServerString = "Data Source=YANFA05;Initial Catalog=LibraryDB;Integrated Security=True";
            sqlConnection = new SqlConnection(ServerString);
            sqlConnection.Open();
            return sqlConnection;
        }
        public SqlCommand Command(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection());
            return cmd;
        }
        public int Execute(string sql) 
        {
            return Command(sql).ExecuteNonQuery();
        }
        public SqlDataReader Read(string sql)
        {
            return Command(sql).ExecuteReader();
        }
        public void DaoClose()
        {
            sqlConnection.Close();
        }
    }
}
