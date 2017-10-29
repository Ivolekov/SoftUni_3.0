using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.GetMinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.; Database=MinionsDB; Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            int desiredId = int.Parse(Console.ReadLine());

            using (connection)
            {
                GetVillainsName(desiredId, connection);
                GetVillainsMinions(desiredId, connection);
            }
        }

        static void GetVillainsName(int desiredId, SqlConnection connection)
        {
            connection.Open();

            string villainName = "SELECT v.[Name] " +
                                       "FROM[dbo].[Villains] AS v " +
                                       "WHERE v.VillainID = ";
            SqlCommand command = new SqlCommand(villainName + "@id", connection);
            command.Parameters.AddWithValue("@id", desiredId);
            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                if (!reader.Read())
                {
                    Console.WriteLine("No villain with ID {0} exists in the database.", desiredId);
                }
                else
                {
                    Console.WriteLine("Villain: {0}", reader[0]);
                }
            }

            connection.Close();
        }

        static void GetVillainsMinions(int desiredId, SqlConnection connection)
        {
            connection.Open();

            string minionsOfVillain = "SELECT m.[Name], m.Age " +
                                            " FROM[dbo].[VillainsMinions] AS vm " +
                                            "INNER JOIN[dbo].[Villains] AS v " +
                                            "   ON v.VillainID = vm.VillainID " +
                                            "INNER JOIN[dbo].[Minions] AS m " +
                                            "   ON m.MinionID = vm.MinionID " +
                                            "WHERE v.VillainID = ";

            SqlCommand command = new SqlCommand(minionsOfVillain + "@id", connection);
            command.Parameters.AddWithValue("@id", desiredId);
            SqlDataReader reader = command.ExecuteReader();
            int counter = 1;
            using (reader)
            {
                if (!reader.Read())
                {
                    Console.WriteLine("<no minions>");
                }
                else
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{counter}. {reader["Name"]} {reader["Age"]}");
                        counter++;
                    }
                }
            }

            connection.Close();
        }
    }
}
