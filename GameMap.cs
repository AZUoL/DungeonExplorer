using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // This class handles the full dungeon map and which room the player is in
    public class GameMap
    {
        private List<Room> rooms; // All rooms in the dungeon
        private int currentRoomIndex = 0; // Tracks which room the player is in
        private Room currentRoom; // Reference to the current room object

        // Constructor sets up the map using a list of pre-created rooms
        public GameMap(List<Room> roomList)
        {
            rooms = roomList;
            currentRoomIndex = 0;
            currentRoom = rooms[currentRoomIndex];
        }

        // Returns the room the player is currently in
        public Room GetCurrentRoom()
        {
            return currentRoom;
        }

        // Moves the player to the next room (loops if they reach the end)
        public bool MoveToNextRoom()
        {
            currentRoomIndex = (currentRoomIndex + 1) % rooms.Count;
            currentRoom = rooms[currentRoomIndex];
            return true;
        }
        
        // Returns total rooms
        public int TotalRooms()
        {
            return rooms.Count;
        }

        // Allows looking into the next room without entering it
        public Room PeekNextRoom()
        {
            int nextIndex = (currentRoomIndex + 1) % rooms.Count;
            return rooms[nextIndex];
        }

        // Allows the player to go back to the previous room (loops accounted)
        public bool MoveToPreviousRoom()
        {
            currentRoomIndex = (currentRoomIndex - 1 + rooms.Count) % rooms.Count;
            currentRoom = rooms[currentRoomIndex];
            return true;
        }
    }
}
