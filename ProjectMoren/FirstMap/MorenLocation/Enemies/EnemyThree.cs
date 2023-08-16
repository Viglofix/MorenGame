using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMoren;

    public class PanMiliolin : EnemiesBase, IDisposable
    {
        public PanMiliolin()
        {
            health = 20;
            damage = 10;
        }
    }
