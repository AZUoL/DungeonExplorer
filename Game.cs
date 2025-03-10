using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Initialize the game with one room and one player
            player = new Player("Hero", 100);
            currentRoom = new Room("A dark, rat infested room", "Sharp Stick");

        }
        public void Start()
        {
            Console.WriteLine("You have entered...The Dungeon\n");
            Console.WriteLine($"You find yourself looking around, you see: ");
            Console.WriteLine(currentRoom.GetDescription());
            bool playing = true;
            while (playing)
            {
                Console.WriteLine("\nWhat do you wish to do?");
                Console.WriteLine("1: Take a look around");
                Console.WriteLine("2: Check your inventory");
                Console.WriteLine("3: Pick up an item");
                Console.WriteLine("4: Quit the game");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("You take a look around and you see: " + currentRoom.GetDescription());
                        break;
                    case "2":
                        player.DisplayStatus();
                        break;
                    case "3":
                        if (currentRoom.HasItem())
                        {
                            string item = currentRoom.GetItem();
                            player.PickUpItem(item);
                            currentRoom.RemoveItem();
                        }
                        else
                        {
                            Console.WriteLine("There is nothing to pick up");
                        }
                        break;
                    case "4":
                        playing = false;
                        Console.WriteLine("You remember that you forgot to turn the oven off and leave the dungeon. Game over!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please type: 1, 2, 3 or 4.");
                        break;
                }
            }
        }
    }
}