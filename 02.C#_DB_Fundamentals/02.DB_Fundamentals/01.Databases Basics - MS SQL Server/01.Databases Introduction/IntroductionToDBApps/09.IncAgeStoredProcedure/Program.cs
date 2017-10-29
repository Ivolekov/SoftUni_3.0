using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.IncAgeStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            int minionId = int.Parse(Console.ReadLine());
            string connectionString = "Server=.; Database=MinionsDB; Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                SqlCommand command = new SqlCommand("usp_GetOlder", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MinionID", minionId);
                connection.Open();
                command.ExecuteNonQuery();

                string selectCommandString = "SELECT Name, Age FROM Minions WHERE MinionID = @minionId";
                SqlCommand selectCommand = new SqlCommand(selectCommandString, connection);
                selectCommand.Parameters.AddWithValue("@minionId", minionId);
                SqlDataReader reader = selectCommand.ExecuteReader();
                using (reader)
                {
                    reader.Read();
                    Console.WriteLine(reader["Name"] + " " + reader["Age"]);
                }
            }
        }
    }
}
