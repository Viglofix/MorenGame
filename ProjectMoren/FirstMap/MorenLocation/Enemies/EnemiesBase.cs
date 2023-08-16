using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMoren;

public class EnemiesBase : IEnemy, IDisposable
{
    public int damage { get; set; }
    public int health { get; set; }

    public static int counter = 0;

    public EnemiesBase()
    {
        counter++;
        health = 0;
        damage = 0;
    }
    ~EnemiesBase()
    {
        counter--;
    }

    public void Dispose()
    {
        counter--;
    }
}

