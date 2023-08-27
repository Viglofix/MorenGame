using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjectMoren.FirstMap.MorenLocation.Enemies.EnemiesBaseElderyEntities;

namespace ProjectMoren.FirstMap.MorenLocation.Enemies;

public class Ges : EnemiesBase
{
    public Ges()
    {
        health = 20;
        damage = 10;
    }
}
