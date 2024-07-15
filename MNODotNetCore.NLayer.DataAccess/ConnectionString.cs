using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNODotNetCore.NLayer.DataAccess;

internal static class ConnectionString
{
    public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = "RIKZIL\\SQLEXPRESS", //server name
        InitialCatalog = "MNODotNetTraining", //db name
        UserID = "sa",
        Password = "sasa@123",
        TrustServerCertificate = true
    };


}
