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
        public static string connection_String = "Server=localhost;" +
            "Port=5432;" +
            "Database=Customs;" +
            "User Id=postgres;" +
            "Password=1234";

        public static string subCustomerViewQuery;

        public static DataTable GetDataTableFromQuery(string query)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connection_String);
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = query;
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                //dataGridView1.DataSource = dt;
                return dt;
            }
            comm.Dispose();
            conn.Close();
            return null;
        }
    }
}
