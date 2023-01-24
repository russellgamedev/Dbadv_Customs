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

        
    }
}
