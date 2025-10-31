
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCF.DAL
{
    public static class DataProvider
    {
        private static string connectionString;

        static DataProvider()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string server = appSettings["ServerName"] ?? throw new InvalidOperationException("ServerName not found in App.config.");
                string database = appSettings["DatabaseName"] ?? throw new InvalidOperationException("DatabaseName not found in App.config.");
                string username = appSettings["Username"];
                string password = appSettings["Password"];

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    connectionString = $"Server={server};Database={database};User Id={username};Password={password};";
                }
                else
                {
                    connectionString = $"Server={server};Database={database};Trusted_Connection=True;";
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error constructing connection string from App.config.", ex);
            }
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static bool TestConnection(string customConnectionString)
        {
            using (SqlConnection conn = new SqlConnection(customConnectionString))
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        public static bool TestConnection()
        {
            return TestConnection(connectionString);
        }


        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }


        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                }

                connection.Close();
            }

            return data;
        }

        public static void ReloadConnectionString()
        {
            try
            {
                ConfigurationManager.RefreshSection("appSettings");
                var appSettings = ConfigurationManager.AppSettings;
                string server = appSettings["ServerName"] ?? throw new InvalidOperationException("ServerName not found in App.config.");
                string database = appSettings["DatabaseName"] ?? throw new InvalidOperationException("DatabaseName not found in App.config.");
                string username = appSettings["Username"];
                string password = appSettings["Password"];

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    connectionString = $"Server={server};Database={database};User Id={username};Password={password};";
                }
                else
                {
                    connectionString = $"Server={server};Database={database};Trusted_Connection=True;";
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error constructing connection string from App.config.", ex);
            }
        }
    }
}
