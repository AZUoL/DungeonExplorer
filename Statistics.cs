using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // Tracks overall gameplay stats for the player
    public class Statistics
    {
        // Number of rooms the player has gone into
        public int RoomsVisited { get; private set; } = 0;

        // Total monsters defeated by the player
        public int MonstersDefeated { get; private set; } = 0;

        // Total number of items picked up
        public int ItemsPickedUp { get; private set; } = 0;

        // Increases the room counter when the player moves forward
        public void IncrementRoomsVisited()
        {
            RoomsVisited++;
        }

        // Tracks how many monsters were defeated
        public void IncrementMonstersDefeated()
        {
            MonstersDefeated++;
        }

        // Tracks how many items the player has picked up
        public void IncrementItemsPickedUp()
        {
            ItemsPickedUp++;
        }

        // Displays the players stats at the end of the game
        public void Display()
        {
            Console.WriteLine("\n *** Player Statistics ***");
            Console.WriteLine($"Rooms Visited: {RoomsVisited}");
            Console.WriteLine($"Monsters Defeated: {MonstersDefeated}");
            Console.WriteLine($"Items Picked Up: {ItemsPickedUp}");
        }
    }
}
