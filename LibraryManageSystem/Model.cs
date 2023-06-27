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
    public class Model
    {
        public DataSet LibData;
        public Model(int userID)
        {
            string sqlServer = "Data Source=YANFA05;Initial Catalog=LibraryDB;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sqlServer);
            conn.Open();
            string sql = $"select * from LibraryUser where userID = {userID}" +
                $"select * from LibraryBook" +
                $"select * from LibraryRecord";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.TableMappings.Add("Table", "User");
            da.TableMappings.Add("Table1", "Book");
            da.TableMappings.Add("Table2", "Record");
            LibData = new DataSet();
            da.Fill(LibData);
            DataTable user = LibData.Tables["User"];
             Convert.ToInt16(user.Rows[userID].ToString());
            DataTable bookList = LibData.Tables["Book"];
            DataTable bookRecord = LibData.Tables["Record"];
        }
    }
}
