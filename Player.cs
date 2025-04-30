using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.DesignerServices;

namespace DungeonExplorer
{
    // The player class represents the player controlled by the user
    // Inherits from creature and implements IDamageable for combat logic
    public class Player : Creature, IDamageable
    {
        private Inventory inventory = new Inventory(); // Players personal inventory system

        // Sets the player with a name and health that is handled by creature constructor
        public Player(string name, int health) : base(name, health)
        {
        }

        // Picks up an item and adds it to inventory
        public void PickUpItem(Item item)
        {
            inventory.AddItem(item);
            Console.WriteLine($"{Name} picked up: {item.Name}");
        }

        // Drops single item by name
        public void DropItem(string itemName)
        {
            Item item = inventory.GetItembyName(itemName);
            if (item != null)
            {
                inventory.RemoveItem(item);
                Console.WriteLine($"{Name} dropped {item.Name}.");
            }
            else
            {
                Console.WriteLine("That item is not in your inventory.");
            }

            if (!inventory.HasItems())
            {
                Console.WriteLine("Your inventory is now empty.");
            }
        }

        // Drops all items in the players inventory
        public void DropAllItems()
        {
            var allItems = inventory.GetItems();
            if (allItems.Count > 0)
            {
                Console.WriteLine($"{Name} dropped all items: {string.Join(", ", allItems.Select(i => i.Name))}.");
                foreach (var item in allItems.ToList())
                {
                    inventory.RemoveItem(item);
                }
            }
            else
            {
                Console.WriteLine("You have no items to drop");
            }
        }


        // Returns a comma separated list of items in the inventory or notifies its empty
        public string InventoryContents()
        {
            return inventory.Display();
        }

        // Shows the players current stats
        public void DisplayStatus()
        {
            // Shows player stats
            Console.WriteLine($"Player: {Name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Inventory: {InventoryContents()}");
        }

        // Checks if the player is holding any items
        public bool HasItems()
        {
            return inventory.HasItems();
        }

        // Basic attack with fixed damage
        public override void Attack(Creature target)
        {
            int damage = 10; // basic player attacks
            Console.WriteLine($"{Name} attacks {target.Name} with a basic attack!");
            target.TakeDamage(damage);
        }

        // Optional overloaded attack method with bonus damage (not currently used)
        public void Attack(Creature target, int bonusDamage)
        {
            Console.WriteLine($"{Name} uses a special attack on {target.Name}!");
            target.TakeDamage(10 + bonusDamage);
        }

        // Heals the player - caps HP at 100
        public void Heal(int amount)
        {
            Health += amount;
            if (Health > 100)
            {
                Health = 100;
            }
            Console.WriteLine($"{Name} heals for {amount}. Health is now {Health}.");
        }

        // Uses an item by name
        public void UseItem(string itemName)
        {
            Item item = inventory.GetItembyName(itemName);
            if (item != null)
            {
                item.Use(this);
                inventory.RemoveItem(item);
            }
            else
            {
                Console.WriteLine("That item is not in your inventory.");
            }
        }

        // Displays all healing items in the inventory using LINQ inside Inventory
        public void ShowHealingItems()
        {
            inventory.ShowHealingItems(); // uses LINQ inside inventory.cs
        }

        // Displays the strongest weapon using LINQ
        public void ShowStrongestWeapon()
        {
            inventory.ShowStrongestWeapon(); // uses LINQ to find the best weapon
        }

        // Gets a specific item from the inventory by name 
        public Item GetItemByName(string name)
        {
            return inventory.GetItembyName(name);
        }

        public Weapon GetStrongestWeapon()
        {
            return inventory.GetItems()
                .OfType<Weapon>()
                .OrderByDescending(w => w.Damage)
                .FirstOrDefault();
        }
    }
}