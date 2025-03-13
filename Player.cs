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
            inventory.Add(item);
            // Console.WriteLine($"{Name} picked up: {item}");
        }

        public void DropItem(string item)
        {
            // Drops specific item if its in the inventory
            if (inventory.Remove(item))
            {
                Console.WriteLine($"{Name} dropped {item}.");
            }
            else
            {
                Console.WriteLine($"{item} is not in your inventory");
            }

            // Ensures that inventory is completely empty if items are gone
            if (inventory.Count == 0)
            {
                Console.WriteLine("Your inventory is now empty");
            }
         
        }

        public void DropAllItems()
        {
            // Drops all items from inventory
            if (inventory.Count > 0)
            {
                Console.WriteLine($"{Name} dropped all items: {string.Join(", ", inventory)}.");
                inventory.Clear(); // Clears inventory
            }
            else
            {
                Console.WriteLine("You have no items to drop");
            }
        }

        public string InventoryContents()
        {
            // If inventory has items, join them into a single string that are separted by commas.
            // Otherwise return "empty" if no items are there
            return inventory.Count > 0 ? string.Join(", ", inventory) : "Empty"; 
        }

        public void DisplayStatus()
        {
            // Shows player stats
            Console.WriteLine($"Player: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Inventory: {InventoryContents()}");
        }

        public bool HasItems()
        {
            return inventory.Count > 0; // Return true if the player has at least one item
        }
    }
}