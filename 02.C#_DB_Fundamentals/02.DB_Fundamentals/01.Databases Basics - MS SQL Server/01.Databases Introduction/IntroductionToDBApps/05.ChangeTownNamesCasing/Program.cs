using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ChangeTownNamesCasing
{
    class Program
    {
        public static string connectionString = "Server=.; Database=MinionsDB;Trusted_connection=True;";

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            using (connection)
            {
                string townSelectionCommandString = "SELECT t.TownName " +
                                                      "FROM Country AS c " +
                                                     "INNER JOIN Towns AS t " +
                                                        "ON t.CountryID = c.CountryID " +
                                                     "WHERE c.CountryName = @countryName";
                SqlCommand townSelectionCommand = new SqlCommand(townSelectionCommandString, connection);
                townSelectionCommand.Parameters.AddWithValue("@countryName", input);
                SqlDataReader townsReader = townSelectionCommand.ExecuteReader();
                List<string> towns = new List<string>();
                while (townsReader.Read())
                {
                    towns.Add((string)townsReader[0]);
                }
                townsReader.Close();

                List<string> townsWithUpperCase = new List<string>();

                foreach (var town in towns)
                {
                    if (town != town.ToUpper())
                    {
                        townsWithUpperCase.Add(town.ToUpper());
                        string updateCommandString = "UPDATE Towns " +
                                                        "SET TownName = @upperName " +
                                                      "WHERE TownName = @townName";
                        SqlCommand updateCommand = new SqlCommand(updateCommandString, connection);
                        updateCommand.Parameters.AddWithValue("@upperName", town.ToUpper());
                        updateCommand.Parameters.AddWithValue("@townName", town);
                        updateCommand.ExecuteNonQuery();
                    }
                }

                StringBuilder townsResult = new StringBuilder();
                if (townsWithUpperCase.Count != 0)
                {
                    townsResult.AppendLine($"{townsWithUpperCase.Count} town names were affected.");
                    townsResult.AppendLine($"[{String.Join(", ", townsWithUpperCase)}]");
                }
                else
                {
                    townsResult.AppendLine("No town names were affected.");
                }

                Console.WriteLine(townsResult.ToString());
            }
        }
    }
}
