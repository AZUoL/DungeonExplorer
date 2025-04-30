using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // This interface is used for any item that can be picked up and used
    public interface ICollectible
    {
        // Every collectible item must have a name
        string Name { get; }

        // Every collectible must be usable by the player in some way
        void Use(Player player);
    }
}
