using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMoren.FirstMap.MorenLocation.Enemies.EnemiesBaseAdultEntities
{
    public class Voxenfix : EnemisBaseAdult, IDisposable
    {
        public Voxenfix()
        {
            health = 30;
            damage = 10;
        }
    }
}
