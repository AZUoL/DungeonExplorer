using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{

    // This class handles all of the logic for the players inventory
    public class Inventory
    {
        private List<Item> items = new List<Item>(); // Stores all the items

        // Adds an item to the inventory and notifies player
        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine($"{item.Name} added to inventory.");
        }

        // Removes specific item
        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        // Checks if the inventory has an item by name
        public bool Contains(string name)
        {
            return items.Any(i => i.Name == name);
        }

        // Finds and returns an item by name
        public Item GetItembyName(string name)
        {
            return items.FirstOrDefault(i => i.Name == name);
        }

        // Shows all items or notifies of empty inventory
        public string Display()
        {
            return items.Count > 0 ? string.Join(", ", items.Select(i => i.Name)) : "Empty";
        }

        // Check to see if player has any items
        public bool HasItems()
        {
            return items.Count > 0;
        }

        // Returns the full list of items
        public List<Item> GetItems()
        {
            return items;
        }

        // Filters and displays only healing items
        public void ShowHealingItems()
        {
            var healing = items.Where(i => i is Potion).Select(i => i.Name).ToList();
            Console.WriteLine(healing.Count > 0 ? "Healing items: " + string.Join(", ", healing) : "No healing items found.");
        }

        // Finds and displays the weapon with the highest damage
        public void ShowStrongestWeapon()
        {
            var strongest = items
                .OfType<Weapon>()
                .OrderByDescending(w => w.Damage)
                .FirstOrDefault();

            Console.WriteLine(strongest != null
                ? $"Strongest weapon: {strongest.Name} ({strongest.Damage} damage)"
                : "No weapons in inventory.");
        }
    }
}
