using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMoren
{
    public class ShopTemplate
    {
        public static void ShopMethod(Dictionary<int, string> dic, Player player, LemparsMutlaService lemparsMutlaService)
        {
            string? agreement;
            string? item;
            Console.WriteLine("^Judaflin: Wybiebiebierz cos sobie Fiflinku !!!");
            agreement = Console.ReadLine();
            bool intAgreement = int.TryParse(agreement, out int result);
            Console.WriteLine();
            Box.GetBoxAll(dic);
            Console.WriteLine();
            player.IterateThroughTheEquipment();
            Console.WriteLine();

            Console.WriteLine("Wybierz miejsce na ladzie, gdzie chcesz wziac przedmiot: ");
            agreement = Console.ReadLine();
            bool intAgreementSecond = int.TryParse(agreement, out int resultSecond);
            string itemFromDictionary = Box.GetBoxItemById(dic, resultSecond);

            if (dic.ContainsValue("%%Mutla Lemparu {+10Charisma} -- 5 Morenow"))
            {
                lemparsMutlaService.Add(10);
                dic[resultSecond] = null;
                return;
            }
            if (dic.ContainsValue("%%Mutla Lemparu {+20Charisma} -- 10 Morenow"))
            {
                lemparsMutlaService.Add(20);
                dic[resultSecond] = null;
                return;
            }
            if(dic.ContainsValue("++Wywar z Lumpaxowej Jagody {+20HP} -- 20 Morenow"))
            {
                player.AddPurseHP(20);
                dic[resultSecond] = null;
                return;
            }
            if (Box.GetBoxItemById(dic, resultSecond) != null)
            {
                player.Add(player.GetEquipmentIndexByItem(dic, itemFromDictionary), itemFromDictionary);
                dic[resultSecond] = null;
                Console.WriteLine($"*Dodano {itemFromDictionary}");
            }
            else
            {
                Console.WriteLine("Niestety, ale w skrzynce nie odnaleziono takiego przedmiotu");
            }
            player.AdjustDictionaryIndexes(player.Equipment);
        }
    }
}
