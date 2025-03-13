using System;
using System.Collections.Generic; // required for multiple items


namespace DungeonExplorer
{
    public class Room
    {
        private string description; // Room description
        private List<string> items = new List<string>(); // Multiple items
        private string monster; // A monster in the room 

        public Room(string description, List<string> items = null, string monster = null)
        {
            // Initialise the room with description
            this.description = description;
            this.items = items ?? new List<string>(); // If no items are given, initialises empty list
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

        public List<string> GetItems()
        {
            return new List<string>(items); // Returns a copy to avoid changing original list
        }

        public void RemoveItem(string item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
            }
        }

        public bool HasMonster()
        {
            return !string.IsNullOrEmpty(monster); // Check if the room has a monster
        }

        public string GetMonster()
        {
            return monster;
        }

        public void RemoveMonster()
        {
            monster = null; // Removes the monster if defeated
        }

        public void AddItem(string item)
        {
            items.Add(item);
            Console.WriteLine($"{item} has been added to the room.");
        }
    }
}