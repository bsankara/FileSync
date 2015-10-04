using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace FileSync
{
    class SqlQuery
    {
        private SQLiteConnection fileSyncConnection;
        private static string DBName;

        public SqlQuery(string dBName)
        {
            DBName = dBName;
            fileSyncConnection = new SQLiteConnection("Data Source=" + DBName + ";Version=3;");
        }

        public void createDB()
        {
            SQLiteConnection.CreateFile(DBName);
        }
    }
}
