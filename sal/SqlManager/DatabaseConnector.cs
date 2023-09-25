using System.IO.Pipes;
using Microsoft.Data.SqlClient;
using SAL.Constants.Messages;
using SAL.Log;

namespace SAL.SqlManager
{
    public class DatabaseConnector
    {
        private string _connectionString;
        private string _sqlQuery;

        public DatabaseConnector(string databaseName, bool trustServerCertificate, string sqlQuery)
        {
            _connectionString = $"Server=localhost;Database={databaseName};Integrated Security=SSPI;TrustServerCertificate={trustServerCertificate}";
            _sqlQuery = sqlQuery;
        }

        public bool ConnectAndQuery()
        {
            try
            {
                using (SqlConnection connection = new(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new(_sqlQuery, connection))
                    {
                        command.CommandTimeout = 600;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Print headers
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write($"{reader.GetName(i),-20}");
                            }
                            Console.WriteLine();

                            // Print data
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write($"{reader[i].ToString(),-20}");
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                }
                return true;
            }
            catch (SqlException ex)
            {
                Msg.WriteLineRed("An error occurred while connecting to the database or executing the query.");
                Msg.WriteLineRed("Error details: " + ex.Message);
                LogManager.AddLogEntry("Query execution failed. Error number: " + ex.Number + ".");
                return false;
            }
        }
    }
}