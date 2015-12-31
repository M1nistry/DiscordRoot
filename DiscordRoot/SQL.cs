using System;
using System.Data.SQLite;
using System.IO;

namespace DiscordRoot
{
    public static class SQL
    {
        private static readonly SQLiteConnection Connection;

        private static readonly string DbPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\DiscordRoot\drBot.db3";

        static SQL()
        {
            var connection = new SQLiteConnectionStringBuilder
            {
                DataSource = DbPath,
                ForeignKeys = true
            };

            Connection = new SQLiteConnection
            {
                ConnectionString = connection.ToString(),
                ParseViaFramework = true
            };
            InitializeDatabase();
        }

        private static void InitializeDatabase()
        {
            if (!File.Exists(DbPath))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\DiscordRoot");
                SQLiteConnection.CreateFile(DbPath);
            }

            try
            {
                const string userTable = @"CREATE TABLE IF NOT EXISTS `users` (`id` INTEGER PRIMARY KEY AUTOINCREMENT, `user_id` TEXT, `name` TEXT, `nickname` TEXT, `last_seen` DATETIME, `score` INTEGER);";

                const string statusTable = @"CREATE TABLE IF NOT EXISTS `status` (`id` INTEGER PRIMARY KEY AUTOINCREMENT, `user_id` INTEGER, `message` TEXT, `date_end` DATETIME, `active` TINYINT);";

                using (var connection = new SQLiteConnection(Connection).OpenAndReturn())
                {
                    using (var cmd = new SQLiteCommand(connection))
                    {
                        cmd.CommandText = userTable;
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = statusTable;
                        cmd.ExecuteNonQuery();


                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
