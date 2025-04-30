using System;
using System.Media;
using System.Collections.Generic;
using System.Linq; // required for multiple items

namespace DungeonExplorer
{
    // Main class that handles all game logic and interactions
    internal class Game
    {
        private Statistics stats = new Statistics(); // Tracks player kills, items looted and rooms visited
        private Player player; // Player character
        private GameMap gameMap; // Manages the room and navigation

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
            Room room1 = new Room(
                "A dark, rat infested room",
                new List<Item> { new Weapon("Sharp Stick", 5), new Weapon("Old Key", 1) },
                new Monster("Giant Rat", 30, 5)
            );
            Room room2 = new Room(
                "An eerie corridor filled with cobwebs",
                new List<Item> { new Potion("Healing Potion", 20), new Weapon("Rusty Dagger", 7) },
                new Monster("Eldritch Accountant", 45, 8)
            );
            Room room3 = new Room(
                "A treasure room filled with gold, money and artifacts.",
                new List<Item> { new Weapon("£5 Note", 2) },
                new Monster("Undead Treasure Guardian", 60, 10),
                locked: true
            );
            Room room4 = new Room(
                "A bloodstained prison cell.",
                new List<Item> { new Weapon("Rusty Pipe", 10) },
                new Goblin("Goblin Brute", 40, 12)
            );

            Room room5 = new Room(
                "A suspiciously empty vault.",
                new List<Item> { new Potion("Greater Healing Potion", 30), new Weapon("Arcane Spear", 15) },
                new Monster("Phantom Warden", 70, 15)
            );

            List<Room> roomList = new List<Room> { room1, room2, room3, room4, room5 };
            gameMap = new GameMap(roomList ); // initialises the full map
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
            Console.WriteLine("6: Move back to previous room");
            Console.WriteLine("7: Use an item");
            Console.WriteLine("8: Show healing items");
            Console.WriteLine("9: Show strongest weapon");
            Console.WriteLine("10: Quit the game");
        }

        private void HandleChoice(string choice, ref bool playing)
        {
            Console.Clear(); // Clears previous output
            Room currentRoom = gameMap.GetCurrentRoom();

            switch (choice)
            {
                case "1":
                    // Show room description again
                    Console.WriteLine("You take a look around and you see: " + currentRoom.GetDescription());
                    if (currentRoom.HasMonster())
                    {
                        Monster monster = currentRoom.GetMonster();

                        Console.WriteLine($"You engage in battle with {monster.Name}!");

                        while (player.IsAlive() && monster.IsAlive())
                        {
                            Console.WriteLine("\nChoose your action:");
                            Console.WriteLine("1: Attack");
                            Console.WriteLine("2: Flee");
                            string input = Console.ReadLine();

                            if (input == "1")
                            {
                                // Checks if player has a weapon and if so, use overloaded attack with bonus
                                Weapon strongest = player.GetStrongestWeapon();
                                if (strongest != null)
                                {
                                    Console.WriteLine($"{player.Name} pulls out their strongest weapon: {strongest.Name}!");
                                    player.Attack(monster, strongest.Damage); // use attack with bonus damage
                                    Console.WriteLine($"Bonus damage applied: {strongest.Damage}");
                                }
                                else
                                {
                                    player.Attack(monster); // use base attack if no weapon
                                }

                                // if monster is still alive, it fights back
                                if (monster.IsAlive())
                                {
                                    monster.Attack(player);
                                }
                            }
                            else if (input == "2")
                            {
                                Console.WriteLine("You flee from battle!");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Choose 1 or 2.");
                            }
                        }

                        // Checks if monster has been defeated
                        if (!monster.IsAlive())
                        {
                            Console.WriteLine($"You have defeated the {monster.Name}!");
                            currentRoom.RemoveMonster();
                            stats.IncrementMonstersDefeated();
                        }

                        // Checks if player has been defeated
                        if (!player.IsAlive())
                        {
                            Console.WriteLine($"You have died. Game over.");
                            Environment.Exit(0);
                        }
                    }

                    else
                    {
                        Console.WriteLine("There are no enemies here...");
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
                        Item item = currentRoom.GetItems()[0]; 
                        player.PickUpItem(item);
                        stats.IncrementItemsPickedUp();
                        currentRoom.RemoveItem(item); 
                        Console.WriteLine($"You have picked up: {item.Name}");
                    }
                    else
                    {
                        Console.WriteLine("There is nothing to pick up.");
                    }
                    break;

                case "4":
                    // Drop selected item
                    if (player.HasItems())
                    {
                        Console.WriteLine("Which item do you want to drop?");
                        Console.WriteLine(player.InventoryContents());
                        string dropItemName = Console.ReadLine().Trim();

                        Item itemToDrop = player.GetItemByName(dropItemName);
                        if (itemToDrop != null)
                        {
                            player.DropItem(dropItemName);
                            currentRoom.AddItem(itemToDrop);
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
                    // Tries to move forward unless next room is locked
                    Room nextRoom = gameMap.PeekNextRoom();

                    if (nextRoom.IsLocked())
                    {
                        Console.WriteLine("The next room is locked. Use a key to unlock it first.");
                    }
                    else
                    {
                        gameMap.MoveToNextRoom();
                        Console.WriteLine("\nYou move onto the next room...");
                        Console.WriteLine($"You are now in: {gameMap.GetCurrentRoom().GetDescription()}");
                        stats.IncrementRoomsVisited();
                    }
                    break;
                case "6":
                    // Goes back to previous room
                    gameMap.MoveToPreviousRoom();
                    Console.WriteLine("\nYou move back to the previous room... must've forgotten something");
                    Console.WriteLine($"You are now in: {gameMap.GetCurrentRoom().GetDescription()}");
                    break;
                case "7": 
                    // Use an item
                    if (player.HasItems())
                    {
                        Console.WriteLine("Which item do you want to use?");
                        Console.WriteLine(player.InventoryContents());
                        string useItem = Console.ReadLine().Trim();

                        Item item = player.GetItemByName(useItem);
                        if (item != null)
                        {
                            // if its a key and next room is locked, unlock it
                            Room upcomingRoom = gameMap.PeekNextRoom();
                            if (item.Name.ToLower().Contains("key") && upcomingRoom.IsLocked())
                            {
                                upcomingRoom.Unlock();
                                player.DropItem(useItem); // consumes the key
                            }
                            else
                            {
                                player.UseItem(useItem);
                            }
                        }
                        else
                        {
                            Console.WriteLine("You don't have that item.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have no items to use.");
                    }
                    break;
                case "8":
                    player.ShowHealingItems();
                    break;
                case "9":
                    player.ShowStrongestWeapon();
                    break;
                case "10":
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
                    stats.Display(); // Shows final player statistics
                    break;
                default:
                    // Invalid input handling
                    Console.WriteLine("Invalid choice, please type: 1, 2, 3, 4, 5, 6, 7, 8, 9 or 10.");
                    break;
                
            }
        }
    }
}