using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player; // Player character
        private Room currentRoom; // The current room

        public Game()
        {
            // Initialize the game with one room and one player
            player = new Player("Hero", 100);
            currentRoom = new Room("A dark, rat infested room", "Sharp Stick");

        }
        public void Start()
        {
            // Display game intro
            Console.WriteLine("\nYou have entered...The Dungeon\n");
            Console.WriteLine($"You find yourself looking around, you see: ");
            Console.WriteLine(currentRoom.GetDescription());
            bool playing = true; // Game loop control
            while (playing)
            {
                // Display player options
                Console.WriteLine("\nWhat do you wish to do?");
                Console.WriteLine("1: Take a look around");
                Console.WriteLine("2: Check your inventory");
                Console.WriteLine("3: Pick up an item");
                Console.WriteLine("4: Quit the game");

                string choice = Console.ReadLine(); // Read player input

                switch (choice)
                {
                    case "1":
                        // Show room description again
                        Console.WriteLine("You take a look around and you see: " + currentRoom.GetDescription());
                        break;
                    case "2":
                        // Show player stats
                        player.DisplayStatus();
                        break;
                    case "3":
                        // Pick up an item if one is available
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
                        // Quit the game
                        playing = false;
                        // List of random quit messages
                        string[] exitReasons =
                        {
                            "You remember that you forgot to turn the oven off and leave the dungeon.",
                            "You hear ghostly whispers, this isn't what you signed up for, so you leave the dungeon",
                            "A massive spider appears, and you decide that you have had enough and leave the dungeon",
                            "You look at the time, it's way past your bedtime, so you leave the dungeon"
                        };

                        // Selects a random message from the list
                        Random rand = new Random();
                        Console.WriteLine(exitReasons[rand.Next(exitReasons.Length)]);
                        break;
                    default:
                        // Invalid input handling
                        Console.WriteLine("Invalid choice, please type: 1, 2, 3 or 4.");
                        break;
                }
            }
        }
    }
}