using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // All items in the game (weapons, potions) inherit from this base class
    public abstract class Item : ICollectible
    {
        // Name of the item, e.g. "rusty dagger" or "healing potion"
        public string Name { get; protected set; }

        // Constructor sets the item's name
        public Item (string name)
        {
            Name = name;
        }

        // Every item must define what happens when its used
        public abstract void Use(Player player);
    }
}
