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
        public SqlConnection connection()
        {
            string ServerString = "Data Source=YANFA05;Initial Catalog=lib_db;Integrated Security=True";
            sqlConnection = new SqlConnection(ServerString);
            sqlConnection.Open();
            return sqlConnection;
        }
        public SqlCommand command(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, connection());
            return cmd;
        }
        public int execute(string sql) 
        {
            return command(sql).ExecuteNonQuery();
        }
        public SqlDataReader read(string sql)
        {
            return command(sql).ExecuteReader();
        }
        public void DaoClose()
        {
            sqlConnection.Close();
        }
    }
}
