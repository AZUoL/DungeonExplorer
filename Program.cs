using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running tests...\n");

            Tests.RunTests(); // Runs functionality tests

            Console.WriteLine("\nTests successfully complete. Press any key to start the game!");
            Console.ReadKey(); // Waits for user input before launching the game

            Console.Clear(); // Clears the clutter so game can start clean

            Console.WriteLine("Welcome to Dungeon Explorer!\n");

            Game game = new Game();
            game.Start();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
