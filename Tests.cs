using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DungeonExplorer
{
    public class Tests
    {
        public static void RunTests()
        {
       
            // Test #1: See if room description is correct
            Room testRoom = new Room("A dark, rat infested room", new List<string> { "Sharp Stick" });
            Debug.Assert(testRoom.GetDescription() == "A dark, rat infested room", "Test 1 has failed. Incorrect Description");
            Console.WriteLine("Test 1 successful. Correct description");

            // Test #2: Check if room has item
            Debug.Assert(testRoom.HasItems(), "Test 2 has failed. Room doesn't have an item at the start");
            Console.WriteLine("Test 2 successful. Room has an item");

            // Test #3: Check if player can pick up the item
            Player testPlayer = new Player("Tester", 100);
            testPlayer.PickUpItem("Sharp Stick");
            Debug.Assert(testPlayer.InventoryContents() == "Sharp Stick", "Test 3 has failed. Player should have picked up the item.");
            Console.WriteLine("Test 3 successful. Player has picked up the item.");

            // Test #4: Check if player can pick up multiple items
            testPlayer.PickUpItem("Sharper Stick");
            Debug.Assert(testPlayer.InventoryContents() == "Sharp Stick, Sharper Stick", "Test 4 has failed. Player shouldn't be able to pick up multiple items.");
            Console.WriteLine("Test 4 successful. Player can carry multiple items.");

            // Test #5: Check if room removes item after pickup
            testRoom.RemoveItem("Sharp Stick");
            Debug.Assert(!testRoom.HasItems(), "Test 5 has failed. Room item should be removed after pick up.");
            Console.WriteLine("Test 5 successful. Room has no item after pickup.");

            // Test #6: Check if player can drop item
            testPlayer.DropAllItems();
            // debug for print
            Console.WriteLine("Inventory after dropping: " + testPlayer.InventoryContents());
            Debug.Assert(testPlayer.InventoryContents() == "Empty", "Test 6 has failed. Inventory should be empty after dropping item.");
            Console.WriteLine("Test 6 successful. Player has dropped the item.");

            Console.WriteLine("\nAll tests passed (thankfully)!");
        }
    }
}
