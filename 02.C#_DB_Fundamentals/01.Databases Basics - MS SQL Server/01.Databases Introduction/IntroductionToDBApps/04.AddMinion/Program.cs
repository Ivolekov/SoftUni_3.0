using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AddMinion
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.; Database=MinionsDB; Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);

            string[] minion = Console.ReadLine().Split(':')[1].Trim().Split(' ');
            string minionName = minion[0];
            int age = int.Parse(minion[1]);
            string town = minion[2];
            string[] villain = Console.ReadLine().Split(':');
            string villainName = villain[1].Trim();

            using (connection)
            {
                connection.Open();

                if(!ChechIfTownExist(town, connection))
                {
                    AddTown(town, connection);
                    Console.WriteLine($"Town {town} was added to the database.");
                }
                if (!CheckVillainExist(villainName, connection))
                {
                    AddVillain(villainName, connection);
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                int townId = GetTownIdByName(town, connection);
                AddMinion(minionName, age, townId, connection);
                int minionId = GetMinionIdByName(minionName, connection);
                int villainId = GetVillainIdByName(villainName, connection);
                AddMinionToVillain(minionId, villainId, connection);
                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }

        private static int GetTownIdByName(string town, SqlConnection connection)
        {
            int townID = 0;
            string commandString = "SELECT TownID FROM Towns WHERE TownName = @town";
            SqlCommand command = new SqlCommand(commandString, connection);
            command.Parameters.AddWithValue("@town", town);
            townID = (int)command.ExecuteScalar();

            return townID;
        }

        private static void AddMinionToVillain(int minionId, int villainId, SqlConnection connection)
        {
            string commandString = "INSERT INTO VillainsMinions(MinionID, VillainID) VALUES(@minionId, @villainId)";
            SqlCommand command = new SqlCommand(commandString, connection);
            command.Parameters.AddWithValue("@minionId", minionId);
            command.Parameters.AddWithValue("@villainId", villainId);
            command.ExecuteNonQuery();
        }

        private static int GetVillainIdByName(string villainName, SqlConnection connection)
        {
            int villainID = 0;
            string commandString = "SELECT VillainID FROM Villains WHERE [Name] = @villainName";
            SqlCommand command = new SqlCommand(commandString, connection);
            command.Parameters.AddWithValue("@villainName", villainName);
            villainID = (int)command.ExecuteScalar();

            return villainID;
        }

        private static int GetMinionIdByName(string minionName, SqlConnection connection)
        {
            int minionID = 0;
            string commandString = "SELECT minionID FROM Minions WHERE [Name] = @minionName";
            SqlCommand command = new SqlCommand(commandString, connection);
            command.Parameters.AddWithValue("@minionName", minionName);
            minionID = (int)command.ExecuteScalar();

            return minionID;
        }

        private static void AddMinion(string minionName, int age, int townId, SqlConnection connection)
        {
            string commandString = "INSERT INTO Minions([Name], Age, TownID) VALUES(@minionName, @age, @townId)";
            SqlCommand command = new SqlCommand(commandString, connection);
            command.Parameters.AddWithValue("@minionName", minionName);
            command.Parameters.AddWithValue("@age", age);
            command.Parameters.AddWithValue("@townId", townId);
            command.ExecuteNonQuery();
        }

        private static void AddVillain(string villainName, SqlConnection connection)
        {
            string commandString = "INSERT INTO Villains([Name], EvilnessFactor) VALUES(@villainName, 'evil')";
            SqlCommand command = new SqlCommand(commandString, connection);
            command.Parameters.AddWithValue("@villainName", villainName);
            command.ExecuteNonQuery();
        }

        private static bool CheckVillainExist(string villainName, SqlConnection connection)
        {
            string commandString = "SELECT COUNT(*) FROM Villains WHERE [Name] = @villainName";
            SqlCommand command = new SqlCommand(commandString, connection);
            command.Parameters.AddWithValue("@villainName", villainName);

            if ((int)command.ExecuteScalar() == 0)
            {
                return false;
            }
            return true;
        }

        private static void AddTown(string town, SqlConnection connection)
        {
            string commandString = "INSERT INTO Towns(TownName) VALUES(@town)";
            SqlCommand command = new SqlCommand(commandString, connection);
            command.Parameters.AddWithValue("@town", town);
            command.ExecuteNonQuery();
        }

        private static bool ChechIfTownExist(string town, SqlConnection connection)
        {
            string commandString = "SELECT COUNT(*) FROM Towns WHERE TownName = @town";
            SqlCommand command = new SqlCommand(commandString, connection);
            command.Parameters.AddWithValue("@town", town);

            if ((int)command.ExecuteScalar() == 0)
            {
                return false;
            }
            return true;
        }
    }
}
