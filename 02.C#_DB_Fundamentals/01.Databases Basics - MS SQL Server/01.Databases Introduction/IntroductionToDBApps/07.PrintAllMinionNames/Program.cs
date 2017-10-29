using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _07.PrintAllMinionNames
{
    class Program
    {
        public static string connectionString = "Server=.; Database=MinionsDB; Trusted_Connection=True;";

        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                string selectMinionsNames = "SELECT [Name] FROM Minions";
                SqlCommand command = new SqlCommand(selectMinionsNames, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    List<string> names = new List<string>();
                    while (reader.Read())
                    {
                        names.Add(reader["Name"].ToString());
                    }

                    PrintNames(names);
                }
            }
        }

        private static void PrintNames(IList<string> names)
        {
            int firstIndex = 0;
            int lastIndex = names.Count - 1;

            for (int i = 0; i < names.Count; i++)
            {
                int currentIndex = 0;
                if (i % 2 == 0)
                {
                    currentIndex = firstIndex;
                    firstIndex++;
                }
                else
                {
                    currentIndex = lastIndex;
                    lastIndex--;
                }

                Console.WriteLine(names[currentIndex]);
            }
        }
    }
}
