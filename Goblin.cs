using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Goblin : Monster
    {
        public Goblin(string name, int health, int strength)
            : base(name, health, strength)
        {
        }

        public override void Attack(Creature target)
        {
            Console.WriteLine($"{Name} screeches and lunges with a rusted blade at {target.Name}, dealing {Strength} damage!");
            target.TakeDamage(Strength);
        }
    }
} 
