
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
                // Reads the connection string from the App.config of the startup project (QuanLyCF.GUI)
                connectionString = ConfigurationManager.ConnectionStrings["QuanLyCafeConnection"].ConnectionString;
            }
            catch (Exception ex)
            {
                // Handle cases where the connection string is missing or invalid
                throw new InvalidOperationException("Connection string 'QuanLyCafeConnection' not found or invalid in App.config.", ex);
            }
        }

        /// <summary>
        /// Gets a new SqlConnection.
        /// </summary>
        /// <returns>A new SqlConnection object.</returns>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static bool TestConnection()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Database connection failed: {ex.Message}", ex);
                }
            }
        }

        /// <summary>
        /// Executes a query that returns a single value.
        /// </summary>
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

        /// <summary>
        /// Executes a query that does not return any records (e.g., INSERT, UPDATE, DELETE).
        /// </summary>
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

        /// <summary>
        /// Executes a query and returns the results as a DataTable.
        /// </summary>
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
    }
}
