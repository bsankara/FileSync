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
            createTableSettings();
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

        // For now this only stores preferred bucket name, but can store more in the future
        public void createTableSettings()
        {
            string sql = "CREATE TABLE Settings (bucketName VARCHAR(256))";
            openConnection();
            SQLiteCommand command = new SQLiteCommand(sql, fileSyncConnection);
            command.ExecuteNonQuery();
            closeConnection();
        }

        public string getPrefferedBucketName()
        {
            string sql = "SELECT * FROM Settings";
            openConnection();
            SQLiteCommand command = new SQLiteCommand(sql, fileSyncConnection);
            string oldBucketName = "";
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    oldBucketName = reader.GetString(0);
                }
            }
            closeConnection();
            return oldBucketName;
        }

        public void savePreferredBucketName(string bucketName)
        {
            string oldBucketName = getPrefferedBucketName();
            if (oldBucketName == "")
            {
                openConnection();
                string sql = "INSERT INTO \'Settings\' (bucketName) VALUES (@bucketName)";
                SQLiteCommand command = new SQLiteCommand(sql, fileSyncConnection);
                command.Parameters.AddWithValue("@bucketName", bucketName);
                command.ExecuteNonQuery();
                closeConnection();
            }
            else
            {
                openConnection();
                string sql = "UPDATE \'Settings\' SET bucketName = \'" + bucketName + "\' WHERE bucketName=\'" + oldBucketName + "\'";
                SQLiteCommand command = new SQLiteCommand(sql, fileSyncConnection);
                command.Parameters.AddWithValue("@bucketName", bucketName);
                command.ExecuteNonQuery();
                closeConnection();
            }

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
