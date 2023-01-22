using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace dbadv_customs
{
    internal static class DatabaseManager
    {
        public static string Connection_String = "Server=localhost;" +
            "Port=5432;" +
            "Database=Customs;" +
            "User Id=postgres;" +
            "Password=1234";

        public static void Test()
        {
            NpgsqlConnection conn = new NpgsqlConnection(
                "Server=localhost;Port=5432;Database=Customs;User Id=postgres;Password=1234");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "Select * from customer";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                //dataGridView1.DataSource = dt;
            }
            comm.Dispose();
            conn.Close();
        }
    }
}
