using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // A weapon is a tpye of item that deals damage
    public class Weapon : Item
    {
        // Damage value of the weapon
        public int Damage { get; private set; }

        public Weapon(string name, int damage) : base(name)
        {
            Damage = damage;
        }

        // When the weapon is used, it's "equipped" (just a message for now)
        public override void Use(Player player)
        {
            Console.WriteLine($"{player.Name} equips the {Name}. (+{Damage} attack power, but no real equip system yet!)");
            
        }
    }
}
