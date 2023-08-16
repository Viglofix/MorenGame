using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMoren
{
    public class DziadekRumooplin : EnemiesBase, IDisposable
    {
        public DziadekRumooplin() 
        {
            health = 10;
            damage = 5;
        }
    }
}
