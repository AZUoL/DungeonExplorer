using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{

    // This interface is for anything that can take damage such as players or monsters
    public interface IDamageable
    {
        // Forces any class using this interface to take damage
        void TakeDamage(int damage);
    }
}
