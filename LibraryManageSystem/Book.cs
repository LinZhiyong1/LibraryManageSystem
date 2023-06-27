using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManageSystem
{
    public class Book
    {
        public string BookID { get;}
        public string Title { get; }
        public string Author { get; }
        public string Publisher { get; }
        public string Isbn { get; }
        public string Category { get; }
        public decimal Price { get; }
        public string Description { get; }
        public string TotalCount { get; }
        public string AvailableCount { get; }
        public string CreateTime { get; }
    }
}
