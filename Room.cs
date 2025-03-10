namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private string item; // The item in the room if there is one

        public Room(string description, string item = null)
        {
            this.description = description;
            this.item = item; 
        }

        public string GetDescription()
        {
            return description;
        }

        public bool HasItem()
        {
            return item != null; // returns true if there is an item in the room
        }

        public string GetItem()
        {
            return item;
        }

        public void RemoveItem()
        {
            item = null; // clears the item when the player picks it up
        }
    }
}