using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
        }
        public void PickUpItem(string item)
        {
            if (inventory.Count == 0) // this only allows one item
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
            Console.WriteLine($"Player: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Inventory: {InventoryContents()}");
        }
    }
}