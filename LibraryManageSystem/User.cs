using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManageSystem
{
    public class User
    {
        public static string UserID { get; set; }
        public static string UserName { get; set; }
        public string Pssword { get; }
        public string FullName { get; }
        public string Email { get; }
        public string Phone { get; }
        public string RegisterTime { get; }
    }
}
