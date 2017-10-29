using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.InitialSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.; Database=master; Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string createDataBase = "CREATE DATABASE MinionsDB ";

            string createTableMinions = "CREATE TABLE Minions(" +
                                            "MinionID INT PRIMARY KEY IDENTITY, " +
                                            "Name VARCHAR(30), " +
                                            "Age INT, " +
                                            "TownID INT," +
                                            "CONSTRAINT FK_Minions_Towns FOREIGN KEY(TownID) " +
                                            "REFERENCES Towns(TownID))";

            string createTableTowns = "USE MinionsDB "+"CREATE TABLE Towns(" +
                                       "TownID INT PRIMARY KEY IDENTITY, " +
                                       "TownName VARCHAR(50), " +
                                       "Country VARCHAR(50))";

            string createTableVillains = "CREATE TABLE Villains(" +
                                         "VillainID INT PRIMARY KEY IDENTITY," +
                                         "Name VARCHAR(50)," +
                                         "EvilnessFactor VARCHAR(50))";

            string createTableVillainsMinions = "CREATE TABLE VillainsMinions(" +
                                                "MinionID INT, " +
                                                "VillainID INT, " +
                                                "CONSTRAINT PK_VillainsMinions PRIMARY KEY" +
                                                " (MinionID, VillainID)," +
                                                "CONSTRAINT FK_VillainsMinions_Minions FOREIGN KEY (MinionID)" +
                                                "REFERENCES Minions(MinionID)," +
                                                "CONSTRAINT FK_VillainsMinions_Villains FOREIGN KEY (VillainID)" +
                                                "REFERENCES Villains(VillainID))";

            string insertTownValues = "INSERT INTO Towns(TownName, Country)"+
                                      "VALUES"+
                                      "('Sofia', 'Bulgaria'), ('Berlin', 'Germany'), ('Eindhoven', 'Netherlands'), ('Liverpool','England'), ('Pleven', 'Bulgaria') ";

            string insertMinionsValues = "INSERT INTO Minions (Name, Age, TownID) " +
                                         "VALUES " +
                                         "('Bob', 13, 1), ('Kevin', 14, 2), ('Steward', 19, 3), ('Petar', 30, 5), ('Lidiya', 22, 1) ";

            string insertVillainsValues = "INSERT INTO Villains (Name, EvilnessFactor) " +
                                          "VALUES " +
                                          "('Gru', 'super evil'), ('Victor', 'evil'), ('Victor Jr', 'good'), ('Spongebob','bad'), ('Doofenschmurtz', 'good') ";

            string insertVillainsMinionsValues = "INSERT INTO VillainsMinions (MinionID, VillainID) " +
                                                 "VALUES " +
                                                 "(1, 1), (2, 1), (3, 1), (4, 5), (5, 4) ";

            SqlCommand command = new SqlCommand(createDataBase, connection);

            using (connection)
            {
                command.ExecuteNonQuery();
                command.CommandText = createTableTowns;
                command.ExecuteNonQuery();
                command.CommandText = createTableMinions;
                command.ExecuteNonQuery();
                command.CommandText = createTableVillains;
                command.ExecuteNonQuery();
                command.CommandText = createTableVillainsMinions;
                command.ExecuteNonQuery();
                command.CommandText = insertTownValues;
                command.ExecuteNonQuery();
                command.CommandText = insertMinionsValues;
                command.ExecuteNonQuery();
                command.CommandText = insertVillainsValues;
                command.ExecuteNonQuery();
                command.CommandText = insertVillainsMinionsValues;
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }
}
