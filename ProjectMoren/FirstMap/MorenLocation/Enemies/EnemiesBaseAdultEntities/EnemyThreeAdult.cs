using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMoren.FirstMap.MorenLocation.Enemies.EnemiesBaseAdultEntities
{
    public class GombaShin : EnemisBaseAdult, IDisposable
    {
        public GombaShin()
        {
            health = 35;
            damage = 10;
        }
    }
}
