using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // Potion is a type of item that restores the player's health
    public class Potion : Item
    {

        // Amount of health the potion restores
        public int HealingAmount { get; private set; }


        // Creates a new potion with a name and healing value
        public Potion(string name, int healingAmount) : base(name)
        {
            HealingAmount = healingAmount;
        }


        // When used, the potion heals the player
        public override void Use(Player player)
        {
            Console.WriteLine($"{player.Name} uses {Name} and restores {HealingAmount} HP!");
            player.Heal(HealingAmount);
        }
    }
}
