using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // This abstract class is the base for anything alive like the player or monsters
    public abstract class Creature
    {
        // Name of the creature 
        public string Name { get; protected set; }

        // Health value
        public int Health { get; protected set; }

        // Constructor sets up the creature's name and starting health
        public Creature(string name, int health)
        {
            Name = name;
            Health = health;
        }

        // Every creature must have their own way of attacking
        public abstract void Attack(Creature target);

        // Quick check to see if the creature is still alive
        public bool IsAlive()
        {
            return Health > 0;
        }

        // Default way to take damage
        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} took {damage} damage. Remaining heatlh: {Health}");
            if (Health <= 0)
            {
                Console.WriteLine($"{Name} has been slayed!");
            }
        }
    }
}
