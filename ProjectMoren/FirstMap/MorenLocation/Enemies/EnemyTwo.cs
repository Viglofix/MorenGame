using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMoren;

    public class PanHeinzelin : EnemiesBase, IDisposable
    {
    public PanHeinzelin()
    {
        health = 15;
        damage = 5;
    }
    }
