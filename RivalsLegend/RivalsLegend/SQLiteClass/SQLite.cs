using Microsoft.Data.Sqlite;
using RivalsLegend;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RivalsLegend
{
    public class SQLite
    {

        static public void CreateBDD()
        {

            using (SqliteConnection conn = new SqliteConnection("Data Source = ../../../SQLiteCLass/RivalsLegend.db"))

            {

                using (SqliteCommand cmd = new SqliteCommand())

                {
                    cmd.Connection = conn;
                    conn.Open();
                    // Drop table if exists Player
                    string strSql = @" Create Table Player(
                             IdPlayer INTEGER PRIMARY KEY AUTOINCREMENT,
                             Name Text NOT NULL,
                             AGR INTEGER DEFAULT 0 CHECK (AGR >= 0 and AGR <= 10),
                             CON INTEGER DEFAULT 0 CHECK (CON >= 0 and CON <= 10),
                             DIS INTEGER DEFAULT 0 CHECK (DIS >= 0 and DIS <= 10),
                             FAR INTEGER DEFAULT 0 CHECK (FAR >= 0 and FAR <= 10),
                             GLU INTEGER DEFAULT 0 CHECK (GLU >= 0 and GLU <= 10),
                             MAC INTEGER DEFAULT 0 CHECK (MAC >= 0 and MAC <= 10),
                             MEC INTEGER DEFAULT 0 CHECK (MEC >= 0 and MEC <= 10),
                             VDJ INTEGER DEFAULT 0 CHECK (VDJ >= 0 and VDJ <= 10));";

                    cmd.CommandText = strSql;



                    cmd.ExecuteNonQuery();
                    // Créationde la DBB
                    /*try {

                        //SQLitePCL.Batteries.Init();

                        connection.Open();
                        var createDb = connection.CreateCommand();
                        createDb.CommandText =
                        @" DROP DATABASE RivalsLegends IF EXISTS;
                                CREATE DATABASE RivalsLegends;
                                USE RivalsLegends;
                                ";
                        createDb.ExecuteNonQuery();
                        Console.WriteLine(" Database Rivals created ");
                    /*}
                    catch (Exception e){
                        Console.WriteLine("Creating the Database failed : "+ e + "   " + e.Message);
                    }*/
                    { 
                    /*
                    // Creation des tables
                    try
                    {

                    // Create Player table
                    try
                    {
                        var createPlayer = connection.CreateCommand();
                        createPlayer.CommandText =
                        @"
                        CREATE TABLE [IF NOT EXISTS] Player(
                        IdPlayer INTEGER PRIMARY KEY,
                        Name VARCHAR(200) NOT NULL,
                         AGR INTEGER DEFAULT 0, CHECK (AGR >= 0 and number <= 10),
                         CON INTEGER DEFAULT 0, CHECK (CON >= 0 and number <= 10),
                         DIS INTEGER DEFAULT 0, CHECK (DIS >= 0 and number <= 10),
                         FAR INTEGER DEFAULT 0, CHECK (FAR >= 0 and number <= 10),
                         GLU INTEGER DEFAULT 0, CHECK (GLU >= 0 and number <= 10),
                         MAC INTEGER DEFAULT 0, CHECK (MAC >= 0 and number <= 10),
                         MEC INTEGER DEFAULT 0, CHECK (MEC >= 0 and number <= 10),
                         VDJ INTEGER DEFAULT 0, CHECK (VDJ >= 0 and number <= 10)
                        );
                    ";
                        createPlayer.ExecuteNonQuery();
                        Console.WriteLine(" player table created ");
                    }
                    catch (SqliteException e)
                    {
                        Console.WriteLine("pb create player table : " + e + "   " +  e.Message);
                    }

                    // Create Profile table
                    try
                    {
                        var createProfile = connection.CreateCommand();
                        createProfile.CommandText =
                        @"
                        CREATE TABLE [IF NOT EXISTS] Profile(
                        IdProfile INTEGER PRIMARY KEY,
                        Pseudo VARCHAR(200) NOT NULL,
                        );";
                        createProfile.ExecuteNonQuery();
                        Console.WriteLine(" Profile table created ");
                    }
                    catch (SqliteException e)
                    {
                        Console.WriteLine("pb create profil table: " +  e + "   " + e.Message);
                    }

                    // Create Position table
                    try
                    {
                        var createPositions = connection.CreateCommand();
                        createPositions.CommandText =
                        @"
                        CREATE TABLE [IF NOT EXISTS] Position(
                        IdPosition INTEGER PRIMARY KEY,
                        Name VARCHAR(200) NOT NULL,
                        Code INTEGER(2),
                        IsMain INTEGER(1) DEFAULT 1,
                        Description VARCHAR(2000),
                        );";
                        createPositions.ExecuteNonQuery();
                        Console.WriteLine(" Position table created ");
                    }
                    catch (SqliteException e)
                    {
                        Console.WriteLine("pb create Position table: " + e + "   " + e.Message);
                    }

                    // Create Role table
                    try
                    {

                        var createRoles = connection.CreateCommand();
                        createRoles.CommandText =
                        @"
                        CREATE TABLE [IF NOT EXISTS] Role(
                        IdRole INTEGER PRIMARY KEY,
                        Name VARCHAR(200) NOT NULL,
                        Code VARCHAR(4),
                        Description VARCHAR(2000),
                        );";
                        createRoles.ExecuteNonQuery();
                        Console.WriteLine(" Role table created ");
                    }
                    catch (SqliteException e)
                    {
                        Console.WriteLine("pb create role table: " + e + "   " + e.Message);
                    }

                    // Create Champion table
                    try
                    {
                        //foreignKey Role ID
                        var createChampion = connection.CreateCommand();
                        createChampion.CommandText =
                        @"
                        CREATE TABLE [IF NOT EXISTS] Champion(
                        IdChampion INTEGER PRIMARY KEY,
                        Name VARCHAR(200) NOT NULL,
                        RoleID INTEGER UNIQUE
                        );";

                        createChampion.ExecuteNonQuery();
                        Console.WriteLine(" Champion table created ");
                    }
                    catch (SqliteException e)
                    {
                        Console.WriteLine("pb create Champion table: " + e + "   " + e.Message);
                    }

                    // Create Team table
                    try
                    {
                        var createTeams = connection.CreateCommand();
                        createTeams.CommandText =
                        @"
                        CREATE TABLE [IF NOT EXISTS] Team(
                        IdTeam INTEGER PRIMARY KEY,
                        Name VARCHAR(200) NOT NULL,
                        Initial VARCHAR(4),
                        Logo VARCHAR(1000) DEFAULT 1,
                        Description VARCHAR(2000),
                        ProfileID INTEGER UNIQUE NOT NULL
                        );";


                        Console.WriteLine(" Team table created ");
                    }
                    catch (SqliteException e)
                    {
                        Console.WriteLine("pb create Team table: " + e + "   " + e.Message);
                    }

                    // Create Match table
                    try
                    {
                        // foreignKey ID team 1 et 2 + MVP player ID
                        var createMatchs = connection.CreateCommand();
                        createMatchs.CommandText =
                        @"
                        CREATE TABLE [IF NOT EXISTS] Match(
                        IdMatch INTEGER PRIMARY KEY,
                        Winner INTEGER NOT NULL,
                        NbVicMax VARCHAR(4) DEFAULT '1',
                        Team1ID INTEGER NOT NULL,
                        Team2ID INTEGER NOT NULL,
                        NbVicTeam1 INTEGER(2),
                        NbVicTeam2 INTEGER(2),
                        MVPID INTEGER,

                        CHECK(NbVicTeam1 >= 0 AND NbVicTeam1 <= NbVicMax),
                        CHECK(NbVicTeam2 >= 0 AND NbVicTeam2 <= NbVicMax),
                        CHECK(Team1ID != Team2ID)
                        );";


                        Console.WriteLine(" Match table created ");
                    }
                    catch (SqliteException e)
                    {
                        Console.WriteLine("pb create match table: " + e + "   " + e.Message);
                    }

                    // Create Game table
                    try
                    {
                        //foreign Key Match ID
                        var creategames = connection.CreateCommand();
                        creategames.CommandText =
                        @"
                        CREATE TABLE [IF NOT EXISTS] Game(
                        IdGame INTEGER PRIMARY KEY,
                        Winner INTEGER NOT NULL,
                        TimeEnd TIME NOT NULL,
                        Map VARCHAR(200) Default 'Summoner Rift',
                        Mode INTEGER(1) DEFAULT 1,
                        MatchID INTEGER NOT NULL,
                        );";


                        Console.WriteLine(" Game table created ");
                    }
                    catch (SqliteException e)
                    {
                        Console.WriteLine("pb create game table: " + e + "   " + e.Message);
                    }

                    // Create Performance table
                    try
                    {
                        //foreign Key PLayer ID + Game ID + Chamion ID
                        var createPerformances = connection.CreateCommand();
                        createPerformances.CommandText =
                        @"
                        CREATE TABLE [IF NOT EXISTS] Performance(
                        IdContract INTEGER PRIMARY KEY,
                        Kills INTEGER NOT NULL,
                        Deaths INTEGER NOT NULL,
                        Assists INTEGER NOT NULL,
                        Gold INTEGER,
                        Farming INTEGER,
                        DmgDone INTEGER,
                        DmgTaken INTEGER,
                        DmgReduced INTEGER,
                        PlayerID INTEGER NOT NULL UNIQUE,
                        ChampionID INTEGER NOT NULL UNIQUE,
                        GameID INTEGER NOT NULL UNIQUE
                        );";

                        Console.WriteLine(" Performance table created ");
                    }
                    catch (SqliteException e)
                    {
                        Console.WriteLine("pb create Performance table: " + e + "   " + e.Message);
                    }

                    // Create Contract table
                    try
                    {
                        //foreign Key PLayer ID + Game ID + Chamion ID
                        var createContracts = connection.CreateCommand();
                        createContracts.CommandText =
                        @"
                        CREATE TABLE [IF NOT EXISTS] Contract(
                        IdContract INTEGER PRIMARY KEY,
                        DateEntry DATE,
                        DateEnd DATE,
                        PlayerID INTEGER NOT NULL,
                        PositionID INTEGER NOT NULL,
                        TeamID INTEGER NOT NULL
                        );";


                        Console.WriteLine(" Contract table created ");
                    }
                    catch (SqliteException e)
                    {
                        Console.WriteLine("pb create Performance table: " + e + "   " + e.Message);
                    }

                    //Create Stratégie table
                    {  
                    /* 
                    try
                    {

                        var createStrategies = connection.CreateCommand();
                        createStrategies.CommandText =
                        @"
                        CREATE TABLE [IF NOT EXISTS] Strategy(
                        IdStrategy INTEGER PRIMARY KEY,
                        Name VARCHAR(200),
                        Code INTEGER(2)NOT NULL,
                        Description VARCHAR(2000),
                        );";
                    }
                    catch (SqliteException e)
                    {
                        Console.WriteLine("pb insert role table: " +  e + "   " + e.Message);
                    }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Tables' Creation has stopped with an error : " + e + "   " + e.Message);
                }

               return connection;
            }*/
                }
                }
            }
        }


        public void InsertIntoDb()
            {
                using (var connection = new SqliteConnection("Data Source=RivalsLegends.db"))
                    {
                        // Implémentation des données de bases
                        try {
                            connection.Open();


                            // Insert player data
                            try
                            {
                                var insertPlayer = connection.CreateCommand();
                                insertPlayer.CommandText =
                                @"
                                INSERT INTO TABLE Player(Name,  FAR , GLU)
                                    VALUES ('Troodon', 2, 15);
                                    VALUES ('ShadowOfADream', 6, 8);
                                    VALUES ('Spiroti', 5, 9);
                            ";
                            }
                            catch (SqliteException e)
                            {
                                Console.WriteLine("pb insert player data : " +  e + "   " + e.Message);
                            }

                            // Insert Champion data
                            try
                            {
                                var insertChampion = connection.CreateCommand();
                                insertChampion.CommandText =
                                @"
                                INSERT INTO TABLE Champion(Name)
                                    VALUES ('Elise');
                                    VALUES ('Aatrox');
                                    VALUES ('Viego');
                            ";
                            }
                            catch (SqliteException e)
                            {
                                Console.WriteLine("pb insert Champion data : " +  e + "   " + e.Message);
                            }
                        }
                        catch(Exception e) {
                            Console.WriteLine("Tables' Insert has stopped with an error : " + e + "   " + e.Message);
                        }
                    }
            }

        /*public void SelectAllPlayers()
        {
            var connection = CreateBDD();

            var command = connection.CreateCommand();
            command.CommandText =
                @"
                    SELECT name
                    FROM Player
                ";
                    //command.Parameters.AddWithValue("$id", id);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var name = reader.GetString(0);

                    Console.WriteLine($"Hello, {name}!");
                }
            }
        }

        public void SelectPlayerById(uint uId)
        {
            var connection = CreateBDD();

            var command = connection.CreateCommand();
            command.CommandText =
                @"
                    SELECT name
                    FROM Player
                    WHERE id = $id
                ";
            //command.Parameters.AddWithValue("$id", id);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var name = reader.GetString(0);

                    Console.WriteLine($"Hello, {name}!");
                }
            }
        }*/
    }
}
