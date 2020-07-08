using System;
using System.Data.Common;

namespace Helper.Utils
{
    public class DBProvider
    {
     

        // Given a connection string, 
        // create the DbProviderFactory and DbConnection.
        // Returns a DbConnection on success; null on failure.
        public static DbConnection CreateDbConnection(string connectionString)
        {
            // providerName = "System.Data.MySql"; //TODO
            // Assume failure.
            DbConnection connection = null;

            // Create the DbProviderFactory and DbConnection.
            if (connectionString != null)
            {
                try
                {
                    //DbProviderFactory factory =DbProviderFactories.GetFactory(providerName); System.Data.SqlClient

                    //connection = factory.CreateConnection();
                    connection = new System.Data.SqlClient.SqlConnection(connectionString);
                    connection.Open();
                    //connection.ConnectionString = connectionString;
                }
                catch (Exception ex)
                {
                    // Set the connection to null if it was created.
                    if (connection != null)
                    {
                        connection = null;
                    }
                    Console.WriteLine(ex.Message);
                }
            }
            // Return the connection.
            return connection;
        }


    }
}
