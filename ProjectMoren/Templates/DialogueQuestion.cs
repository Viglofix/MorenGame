using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMoren
{
    public class DialogueQuestion
    {
        public static void ThreeHeroesTwo(int countOfPossbilities, string hero, string heroTwo, string d1, string d2, string d3, string d4)
        {
            switch (countOfPossbilities)
            {
                case 0:
                    Console.WriteLine($"^{hero}: {d1}");
                    Thread.Sleep(3000);
                    break;
                case 1:
                    Console.WriteLine($"^{hero}: {d1}");
                    Thread.Sleep(3000);
                    Console.WriteLine($"^{heroTwo}: {d2}");
                    break;
                case 2:
                    Console.WriteLine($"^{hero}: {d1}");
                    Thread.Sleep(3000);
                    Console.WriteLine($"^{heroTwo}: {d2}");
                    Thread.Sleep(2000);
                    Console.WriteLine($"^{hero}: {d3}");
                    Thread.Sleep(2000);
                    Console.WriteLine($"^{heroTwo}: {d4}");
                    break;
            }
        }
    }
}
