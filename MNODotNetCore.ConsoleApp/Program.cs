﻿
using MNODotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

Console.WriteLine("Hello, World!");
// install sqlClient in nuget & etc.
/*SqlConnectionStringBuilder  stringBulider = new SqlConnectionStringBuilder();
stringBulider.DataSource = "DESKTOP-35JA3AU\\SQLEXPRESS"; //server name
stringBulider.InitialCatalog = "MNODotNetTraining"; //db name
stringBulider.UserID = "sa";
stringBulider.Password = "sa@123";


SqlConnection conn =  new SqlConnection(stringBulider.ConnectionString);

conn.Open();
Console.WriteLine("Hello everyone, welcome to our connection.");
Console.WriteLine();
string query = "SELECT * from tbl_blog";
SqlCommand cmd = new SqlCommand(query, conn);   
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
adapter.Fill(dt);

conn.Close();
Console.WriteLine("Thank you.");

foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine("BlogID: "+dr[0].ToString());
    Console.WriteLine("BlogTitle: " + dr[1].ToString());
    Console.WriteLine("BlogAuthor: " + dr[2].ToString());
    Console.WriteLine("BlogContent: " + dr[3].ToString());
    Console.WriteLine("------------------------------------------------");
}*/

AdoDotNetExample example = new AdoDotNetExample();
example.Create("A Day in the Life of Abed Salama","Nathan Thrall","About Gaza");
example.Create("A Living Remedy", "Nicole Chung", "Even grief provides a living remedy");
example.Create("After Sappho", "Selby Wynn Schwartz", "Sappho’s own writing");
example.Create("All Souls", "Saskia Hamilton", "Saskia Hamilton’s latest poetry collection");

example.Read();

//example.Delete(15);
//example.Edit(15);
//example.Edit(1);


Console.ReadKey();