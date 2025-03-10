using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; } // Player Name
        public int Health { get; private set; } // Player Health
        private List<string> inventory = new List<string>(); // Player inventory

        public Player(string name, int health)
        {
            // Initialise the player with name and health
            Name = name;
            Health = health;
        }
        public void PickUpItem(string item)
        {
            // Allow pick up of only 1 item
            if (inventory.Count == 0)
            {
                inventory.Add(item);
                Console.WriteLine($"{Name} picked up: {item}.");
            }
            else
            {
                Console.WriteLine($"{Name} is already carrying {inventory[0]}.");
            }
        }

        public void DropItem()
        {
            // Drops the current item
            if (inventory.Count > 0)
            {
                Console.WriteLine($"{Name} dropped {inventory[0]}.");
                inventory.Clear();
            }
            else
            {
                Console.WriteLine("You have no items to drop.");
            }
        }

        public string InventoryContents()
        {
            return inventory.Count > 0 ? string.Join(", ", inventory) : "Empty";
        }

        public void DisplayStatus()
        {
            // Shows player stats
            Console.WriteLine($"Player: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Inventory: {InventoryContents()}");
        }
    }
}