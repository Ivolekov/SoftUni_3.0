using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.IncreaseMinionsAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.; Database=MinionsDB; Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                connection.Open();
                var input = Console.ReadLine();
                int[] ids = input.Split(' ').Select(int.Parse).ToArray();
                var updateBuildCommandString = GetBuilderCommand(ids);
                SqlCommand command = new SqlCommand(updateBuildCommandString.ToString(), connection);
                for (int i = 0; i < ids.Length; i++)
                {
                    command.Parameters.AddWithValue(@"minionId" + i, ids[i]);
                }

                command.ExecuteNonQuery();

                string selectCommandString = "SELECT Name, Age FROM Minions";
                SqlCommand selectCommand = new SqlCommand(selectCommandString, connection);
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader[i]} ");
                    }
                    Console.WriteLine();
                }

            }
        }

        private static StringBuilder GetBuilderCommand(int[] ids)
        {
            StringBuilder commandBuilder = new StringBuilder();
            for (int i = 0; i < ids.Length; i++)
            {
                commandBuilder.AppendLine("UPDATE Minions SET Age = Age + 1, Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)) WHERE MinionID = @minionId" + i);
            }
            return commandBuilder;
        }
    }
}
