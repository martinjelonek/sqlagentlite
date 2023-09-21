using Microsoft.Data.SqlClient;

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

        public void ConnectAndQuery()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connected to the database.");

                    using (SqlCommand command = new SqlCommand(_sqlQuery, connection))
                    {
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
            }
            catch (SqlException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error occurred while connecting to the database or executing the query.");
                Console.WriteLine("Error details: " + ex.Message);
                Console.ResetColor(); 
            }
        }
    }
}