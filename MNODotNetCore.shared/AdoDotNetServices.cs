using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MNODotNetCore.shared
{
    public class AdoDotNetServices
    {
        private readonly string _connectionString;
        public AdoDotNetServices (string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<N> Query <N>(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            
            if(parameters is not null && parameters.Length > 0)
            {
                /* foreach (var item in parameters)
                 {
                     cmd.Parameters.AddWithValue(item.Name, item.Value);
                 }*/
                // For senior level & above foreach
                var paraArray = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray();
                cmd.Parameters.AddRange(paraArray);
            }

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();

            string json = JsonConvert.SerializeObject(dt); // C# to json
            List<N> list = JsonConvert.DeserializeObject<List<N>>(json)!; // json to C#

            return list;
        }
        public N QueryFirstOrDefault<N>(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);

            if (parameters is not null && parameters.Length > 0)
            {
                /* foreach (var item in parameters)
                 {
                     cmd.Parameters.AddWithValue(item.Name, item.Value);
                 }*/
                // For senior level & above foreach
                var paraArray = parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray();
                cmd.Parameters.AddRange(paraArray);
            }

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();

            if (dt.Rows.Count == 0)
            {
                return default(N);
            }


            string json = JsonConvert.SerializeObject(dt); // C# to json
            List<N> list = JsonConvert.DeserializeObject<List<N>>(json)!; // json to C#

            return list[0];
        }



        public int Execute(string query, params AdoDotNetParameter[]? parameters)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);

            if (parameters is not null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Name, item.Value)).ToArray());
            }
            var item = cmd.ExecuteNonQuery();
            return item;
           
        }
        
    }

    public class AdoDotNetParameter
    {
        public AdoDotNetParameter()
        {

        }
        public AdoDotNetParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }
    
        public string? Name { get; set; }
        public object? Value { get; set; }
    }
}
