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
            // Run tests before starting game
            Tests.RunTests();

            // Start game
            Game game = new Game();
            game.Start();

            // End message
            Console.WriteLine("\nGame over.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();


        }
    }
}
