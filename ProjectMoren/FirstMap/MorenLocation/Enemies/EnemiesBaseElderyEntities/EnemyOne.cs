using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMoren.FirstMap.MorenLocation.Enemies.EnemiesBaseAdultEntities;

namespace ProjectMoren.FirstMap.MorenLocation.Enemies.EnemiesBaseElderyEntities
{
    public class DziadekRumooplin : EnemiesBase, IDisposable
    {
        public DziadekRumooplin()
        {
            health = 10;
            damage = 2;
        }
    }
}
