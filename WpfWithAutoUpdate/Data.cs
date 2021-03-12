using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;

namespace WpfWithAutoUpdate
{
    public class Data
    {
        public static void SaveData(string name)
        {
            using (var con=new SqliteConnection(GetConnection()))
            {
                con.Execute("insert into Names values (@Name)",new { Name=name});
            }
        }
        public static List<string> GetAllData()
        {
            using (var con = new SqliteConnection(GetConnection()))
                return con.Query<string>("Select Name from Names").ToList();
        }
        public static void CreateTable()
        {
            using (var con = new SqliteConnection(GetConnection()))
            {
                con.Execute("create table if not exists Names(Name TEXT)");
            }
        }
        public static string GetConnection()
        {
            return "DataSource=DataBase.db";
        }
    }
}
