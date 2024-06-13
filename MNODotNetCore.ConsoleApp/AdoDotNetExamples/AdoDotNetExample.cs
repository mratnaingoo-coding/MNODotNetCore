using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace MNODotNetCore.ConsoleApp.AdoDotNetExamples
{
    public class AdoDotNetExample
    {
        /*private readonly SqlConnectionStringBuilder _stringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-35JA3AU\\SQLEXPRESS", //server name
            InitialCatalog = "MNODotNetTraining", //db name
            UserID = "sa",
            Password = "sasa@123"
        };*/

        private readonly SqlConnectionStringBuilder _sqlConnectingStringBuilder;
        public AdoDotNetExample(SqlConnectionStringBuilder sqlConnectionStringBuilder)
        {
            _sqlConnectingStringBuilder = sqlConnectionStringBuilder;
        }

        public void Read()
        {
            SqlConnection conn = new SqlConnection(_sqlConnectingStringBuilder.ConnectionString);

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
                Console.WriteLine("BlogID: " + dr[0].ToString());
                Console.WriteLine("BlogTitle: " + dr[1].ToString());
                Console.WriteLine("BlogAuthor: " + dr[2].ToString());
                Console.WriteLine("BlogContent: " + dr[3].ToString());
                Console.WriteLine("------------------------------------------------");
            }

        }
        public void Create(string title, string author, string content)
        {
            SqlConnection conn = new SqlConnection(_sqlConnectingStringBuilder.ConnectionString);
            conn.Open();

            string query = @"INSERT INTO [dbo].[tbl_blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();

            conn.Close();
            string message = result > 0 ? "Saving success." : "Saving fail.";
            Console.WriteLine(message);

        }
        public void Delete(int id)
        {
            SqlConnection conn = new SqlConnection(_sqlConnectingStringBuilder.ConnectionString);
            conn.Open();

            string query = @"DELETE FROM tbl_blog WHERE BlogID = @BlogID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@BlogID", id);
            int result = cmd.ExecuteNonQuery();

            conn.Close();
            string message = result > 0 ? "Deleting success." : "Deleting fail.";
            Console.WriteLine(message);
        }
        public void Update(int id, string title, string author, string content)
        {
            SqlConnection conn = new SqlConnection(_sqlConnectingStringBuilder.ConnectionString);
            conn.Open();

            string query = @"UPDATE [dbo].[tbl_blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogID = @BlogID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@BlogID", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();

            conn.Close();
            string message = result > 0 ? "Updating success." : "Updating fail.";
            Console.WriteLine(message);

        }
        public void Edit(int id)
        {
            SqlConnection conn = new SqlConnection(_sqlConnectingStringBuilder.ConnectionString);
            conn.Open();

            string query = @"SELECT * FROM tbl_Blog WHERE BlogID = @BlogID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@BlogID", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            conn.Close();
            Console.WriteLine("Thank you.");

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found.");
                return;
            }

            DataRow dr = dt.Rows[0];

            Console.WriteLine("BlogID: " + dr[0].ToString());
            Console.WriteLine("BlogTitle: " + dr[1].ToString());
            Console.WriteLine("BlogAuthor: " + dr[2].ToString());
            Console.WriteLine("BlogContent: " + dr[3].ToString());
            Console.WriteLine("------------------------------------------------");


        }

    }
}
