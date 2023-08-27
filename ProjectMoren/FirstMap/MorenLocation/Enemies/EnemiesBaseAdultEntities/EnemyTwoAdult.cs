using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMoren.FirstMap.MorenLocation.Enemies.EnemiesBaseAdultEntities
{
    public class Hamerlin : EnemisBaseAdult, IDisposable
    {
        public Hamerlin()
        {
            health = 25;
            damage = 15;
        }
    }
}
