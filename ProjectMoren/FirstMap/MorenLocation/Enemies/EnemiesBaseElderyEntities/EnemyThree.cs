using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMoren.FirstMap.MorenLocation.Enemies.EnemiesBaseAdultEntities;

namespace ProjectMoren.FirstMap.MorenLocation.Enemies.EnemiesBaseElderyEntities;

public class PanMiliolin : EnemiesBase, IDisposable
{
    public PanMiliolin()
    {
        health = 15;
        damage = 5;
    }
}
