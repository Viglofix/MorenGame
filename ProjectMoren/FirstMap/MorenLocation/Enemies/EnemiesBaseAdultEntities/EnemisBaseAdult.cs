namespace ProjectMoren.FirstMap.MorenLocation.Enemies.EnemiesBaseAdultEntities;

public class EnemisBaseAdult : IEnemy, IDisposable
{
    public int damage { get; set; }
    public int health { get; set; }

    public static int counter = 0;

    public EnemisBaseAdult()
    {
        counter++;
        health = 0;
        damage = 0;
    }
    ~EnemisBaseAdult()
    {
        counter--;
    }

    public void Dispose()
    {
        counter--;
    }
}
