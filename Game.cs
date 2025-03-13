using System;
using System.Media;
using System.Collections.Generic;
using System.Linq; // required for multiple items

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player; // Player character
        private Room currentRoom; // The current room
        private List<Room> rooms = new List<Room>(); // List of rooms
        private int currentRoomIndex = 0; // track players position

        public Game()
        {
            // Asks the player for their name
            Console.WriteLine("Enter your name: ");
            string playerName = Console.ReadLine().Trim();

            // Prevention of empty or too long names
            while (string.IsNullOrEmpty(playerName) || playerName.Length > 16)
            {
                Console.WriteLine("Invalid name. Please make sure it is between 1 - 16 characters and try again.");
                playerName = Console.ReadLine().Trim();
            }

            // Joke for numeric names
            if (playerName.All(char.IsDigit))
            {
                Console.WriteLine("Just numbers...? Are you some rogue AI trying to enter the dungeon? Very well, proceed...");
            }

            // Initialise the player with their chosen name
            player = new Player(playerName, 100);

            // Create rooms
            Room room1 = new Room("A dark, rat infested room", new List<string> { "Sharp Stick", "Old Key" }, "Giant Rat");
            Room room2 = new Room("An eerie corridor that is filled with cobwebs", new List<string> { "Healing potion", "Rusty Dagger" }, "Eldritch Accountant");
            Room room3 = new Room("A treaure room with gold, money and different artifacts", new List<string> { "£5 Note" }, "Undead Treasure Guardian");

            // Add rooms to a list
            rooms.Add(room1);
            rooms.Add(room2); 
            rooms.Add(room3); 

            // Set the starting room
            currentRoom = rooms[currentRoomIndex];
        }

        public void Start()
        {
            // Display game intro
            Console.WriteLine("\nYou have entered...The Dungeon\n");
            bool playing = true; // Game loop control
            while (playing)
            {
                DisplayMenu(); // Show the player's options
                string choice = Console.ReadLine(); // Get player input
                HandleChoice(choice, ref playing); // Process the input
            }
        }

        private void DisplayMenu()
        {
            // Display player options
            Console.WriteLine("\nWhat do you wish to do?");
            Console.WriteLine("1: Take a look around");
            Console.WriteLine("2: Check your inventory");
            Console.WriteLine("3: Pick up an item");
            Console.WriteLine("4: Drop an item");
            Console.WriteLine("5: Move to the next room");
            if (currentRoom.HasMonster()) // Only display "FIGHT!" if monster exists
            {
                Console.WriteLine("6: FIGHT!");
            }
            Console.WriteLine("7: Quit the game");
        }

        private void HandleChoice(string choice, ref bool playing)
        {
            Console.Clear(); // Clears previous output

            switch (choice)
            {
                case "1":
                    // Show room description again
                    Console.WriteLine("You take a look around and you see: " + currentRoom.GetDescription());
                    if (currentRoom.HasMonster())
                    {
                        Console.WriteLine($"A {currentRoom.GetMonster()} is lurking here!");
                    }
                    break;
                case "2":
                    // Show player stats
                    player.DisplayStatus();
                    break;
                case "3":
                    // Pick up an item if one is available
                    if (currentRoom.HasItems())
                    {
                        string item = currentRoom.GetItems()[0]; // Pick up the first available item
                        player.PickUpItem(item);
                        currentRoom.RemoveItem(item); // Removes the item from the room
                        Console.WriteLine($"You have picked up: {item}");
                    }
                    else
                    {
                        Console.WriteLine("There is nothing to pick up.");
                    }
                    break;

                case "4":
                    if (player.HasItems())
                    {
                        Console.WriteLine("Which item do you want to drop?");
                        Console.WriteLine(player.InventoryContents());
                        string dropItem = Console.ReadLine().Trim();

                        if (player.InventoryContents().Contains(dropItem))
                        {
                            player.DropItem(dropItem);
                            currentRoom.AddItem(dropItem);
                        }
                        else
                        {
                            Console.WriteLine("You do not have that item to drop.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have no items to drop.");
                    }
                    break;
                case "5":
                    // Move to the next room
                    if (currentRoomIndex < rooms.Count - 1)
                    {
                        currentRoomIndex++;
                        currentRoom = rooms[currentRoomIndex];
                        Console.WriteLine("\nYou move onto the next room...");
                        Console.WriteLine($"You are now in: {currentRoom.GetDescription()}");
                    }
                    else
                    {
                        Console.WriteLine("There are no more rooms ahead.");
                    }
                    break;
                case "6": // New option to "fight"
                    if (currentRoom.HasMonster())
                    {
                        Console.WriteLine($"You engage in battle with {currentRoom.GetMonster()}");
                        Console.WriteLine("You attempt to fight, but then recall that confrontation gives you anxiety. You promptly flee!");
                    }
                    else
                    {
                        Console.WriteLine("There are no enemies here...");
                    }
                    break;
                case "7":
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
                    Console.WriteLine("Invalid choice, please type: 1, 2, 3, 4, 5, 6 or 7.");
                    break;
                
            }
        }
    }
}