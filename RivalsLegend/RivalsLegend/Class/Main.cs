using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RivalsLegends
{
    public class Main
    {            
        public static void Start(object sender, System.EventArgs e)
        {
            int name;
            MessageBox.Show("Game start\n Create your profile");

            Console.WriteLine("####################################");
            Console.WriteLine("         The game will start");
            Console.WriteLine("####################################");

            SQLiteConnec.CreateBDD();


            Console.WriteLine("Enter the player's name");
            string test = Console.ReadLine();
            while( !int.TryParse(test, out int force))
            {
                name = force;
                Console.WriteLine("Error format");
            }


            Console.WriteLine("####################################");
            Console.WriteLine("         End of the game");
            Console.WriteLine("####################################");
        }

    }
}