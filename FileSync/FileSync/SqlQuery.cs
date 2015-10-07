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
        /// <summary>
        /// Database Schema will have table FileStatus which contains the filename(string) and last sync time(string)
        /// Another table to hold folder that we are syncing (potentially more than one in the future?)
        /// </summary>
        public void initializeDatabase()
        {
            createTableSyncDirectory();
            createTableFileStatus();
        }

        public void createTableSyncDirectory()
        {
            string sql = "CREATE TABLE FileSyncDirectory (filePath VARCHAR(256))";
            openConnection();
            SQLiteCommand command = new SQLiteCommand(sql, fileSyncConnection);
            command.ExecuteNonQuery();
            closeConnection();
        }

        public void createTableFileStatus()
        {
            string sql = "CREATE TABLE FileStatus (filePath VARCHAR(256), lastSync INT32)";
            openConnection();
            SQLiteCommand command = new SQLiteCommand(sql, fileSyncConnection);
            command.ExecuteNonQuery();
            closeConnection();
        }

        public void addDirectoryToFileSyncDirectory(string filePath)
        {
            string sql = "INSERT INTO \'FileSyncDirectory\' (filePath) VALUES (@path) ";
            openConnection();
            SQLiteCommand command = new SQLiteCommand(sql, fileSyncConnection);
            command.Parameters.AddWithValue("@path", filePath);
            command.ExecuteNonQuery();
            closeConnection();
        }

        public void createAndInitializeDatabase()
        {
            createDB();
            initializeDatabase();
        }

        private void openConnection()
        {
            fileSyncConnection.Open();
        }

        private void closeConnection()
        {
            fileSyncConnection.Close();
        }

    }
}
