using System;
using System.Collections.Generic; // required for multiple items


namespace DungeonExplorer
{
    public class Room
    {
        private string description; // Room description
        private List<Item> items = new List<Item>(); // stores real items now
        private Monster monster; // stores real monster now

        public Room(string description, List<Item> items = null, Monster monster = null)
        {
            // Initialise the room with description
            this.description = description;
            this.items = items ?? new List<Item>(); // If no items are given, initialises empty list
            this.monster = monster;
        }

        public string GetDescription()
        {
            return description;
        }

        public bool HasItems()
        {
            return items.Count > 0; // Check if the room has items
        }

        public List<Item> GetItems()
        {
            return new List<Item>(items); // Returns a copy to avoid changing original list
        }

        public void RemoveItem(Item item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
            }
        }

        public bool HasMonster()
        {
            return monster != null;
        }

        public Monster GetMonster()
        {
            return monster;
        }

        public void RemoveMonster()
        {
            monster = null; // Removes the monster if defeated
        }

        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine($"{item.Name} has been added to the room.");
        }

        private bool isLocked;

        public Room(string description, List<Item> items = null, Monster monster = null, bool locked = false)
        {
            this.description = description;
            this.items = items ?? new List<Item>();
            this.monster = monster;
            this.isLocked = locked;
        }

        public bool IsLocked()
        {
            return isLocked;
        }

        public void Unlock()
        {
            isLocked = false;
            Console.WriteLine("You unlocked the door with the Old Key.");
        }
    }
}