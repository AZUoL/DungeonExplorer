using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // Base monster class - all enemies in the game start from here
    public class Monster : Creature, IDamageable
    {
        // How strong this monster's attacks are
        public int Strength { get; private set; }

        // Sets up the monster with a name, health and strenght 
        public Monster(string name, int health, int strength) : base(name, health)
        {
            Strength = strength;
        }

        // Monster's version of the attack method (using their strenght stat)
        public override void Attack(Creature target)
        {
            Console.WriteLine($"{Name} strikes {target.Name} with strength {Strength}!");
            target.TakeDamage(Strength);
        }
    }
}
