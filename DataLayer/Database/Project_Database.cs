using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DataLayer.Database
{
    public class Project_Database
    {
        // Connection string is Static
        private string ConnectionString = "";
        private SQLite.SQLiteConnection Connection;
        public Project_Database()
        {
            Connection = new SQLiteConnection(ConnectionString);
        }
    }
}
