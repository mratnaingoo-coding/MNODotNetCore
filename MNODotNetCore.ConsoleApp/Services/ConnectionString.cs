using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNODotNetCore.ConsoleApp.Services
{
    internal static class ConnectionStrings
    {
        public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-35JA3AU\\SQLEXPRESS", //server name
            InitialCatalog = "MNODotNetTraining", //db name
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

    }
}
