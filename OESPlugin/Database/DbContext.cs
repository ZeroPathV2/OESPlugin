using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;

namespace OESPlugin.Database
{
    public class DbContext
    {
        static DbContext()
        {
            //Batteries.Init();

            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            //SQLitePCL.raw.FreezeProvider();

            SQLitePCL.Batteries_V2.Init();
        }
        public string GetDbPath()
        {
            return Path.Combine(Path.GetDirectoryName(typeof(DbContext).Assembly.Location), "BlueBookDB_sqlite3.db");
        }

        public SqliteConnection CreateConnection()
        {
            string path = GetDbPath();
            return new SqliteConnection($"Data Source={path}");
        }
    }
}
