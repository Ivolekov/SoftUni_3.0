using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.GetVillainsNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.; Database=MinionsDB; Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string selectVillainsName = "SELECT v.[Name], COUNT(*) AS MinionCount " +
                                        "FROM[dbo].[Villains] AS v " +
                                        "INNER JOIN[dbo].[VillainsMinions] AS vm " +
                                            "ON vm.VillainID = v.VillainID " +
                                            "GROUP BY v.[Name] " +
                                            "HAVING COUNT(*) > 3 " +
                                            "ORDER BY COUNT(*) DESC ";

            SqlCommand command = new SqlCommand(selectVillainsName, connection);

            using (connection)
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader[i] + " ");
                    }
                    Console.WriteLine();
                }
            }
            connection.Close();
        }
    }
}
