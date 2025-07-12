using SQLite;
using System;
using System.IO;
using WGU.Models;

namespace WGU
{
    public static class DBIO
    {
        public static SQLiteConnection ConnectToSQL()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "wgu.db3");
            return new SQLiteConnection(dbPath);
        }
    }
}
