namespace DungeonExplorer
{
    public class Room
    {
        private string description; // Room description
        private string item; // The item in the room if there is one

        public Room(string description, string item = null)
        {
            // Initialise the room with description
            this.description = description;
            this.item = item; 
        }

        public string GetDescription()
        {
            return description;
        }

        public bool HasItem()
        {
            return item != null; // Check if the room has an item
        }

        public string GetItem()
        {
            return item;
        }

        public void RemoveItem()
        {
            item = null; // Removes the item from the room
        }
    }
}