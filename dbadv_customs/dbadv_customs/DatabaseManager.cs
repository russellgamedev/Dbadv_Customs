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

        public static void Test(string fname, string lname, string ssn, 
            string phNumber, string email, string country, string city, int postCode, 
            string street, int plaque)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connection_String);
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand("add_new_customer", conn);            
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@fname", SqlDbType.NVarChar).Value = fname;
            comm.Parameters.AddWithValue("@lname", SqlDbType.NVarChar).Value = lname;
            comm.Parameters.AddWithValue("@ssn", SqlDbType.NVarChar).Value = ssn;
            comm.Parameters.AddWithValue("@c_number", SqlDbType.NVarChar).Value = phNumber;
            comm.Parameters.AddWithValue("@email", SqlDbType.Text).Value = email;
            comm.Parameters.AddWithValue("@country", SqlDbType.NVarChar).Value = country;
            comm.Parameters.AddWithValue("@city", SqlDbType.NVarChar).Value = city;
            comm.Parameters.AddWithValue("@postal_code", SqlDbType.Int).Value = postCode;
            comm.Parameters.AddWithValue("@street", SqlDbType.NVarChar).Value = street;
            comm.Parameters.AddWithValue("@plaque", SqlDbType.Int).Value = plaque;
            comm.ExecuteNonQuery();
            comm.Dispose();
            conn.Close();            
        }
    }
}
