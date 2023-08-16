using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMoren
{
    public class Shop
    {
        public Dictionary<int, string> shop = new Dictionary<int, string>() { { 0, null! }, { 1, null! }, { 2, null! }, { 3, null! }, { 4, null! }, { 5, null! }, { 6, null! }, { 7, null! }, { 8, null! } };
        public bool FirstTime = true;

        public Shop()
        {
            shop[0] = "++Wywar z Lumpaxowej Jagody {+20HP}";
            shop[1] = "%%Mutla Lemparu {+10Charisma}";
            shop[2] = "%%Mutla Lemparu {+10Charisma}";
            shop[3] = "%%Mutla Lemparu {+10Charisma}";
            shop[4] = "%%Mutla Lemparu {+10Charisma}";
            shop[5] = "Miotla_Z_Badyli {&15Damage}";
        }

        public void Judaflin(Player player, QuestServices questServices, LemparsMutlaService lemparsMutlaService)
        {
            if(FirstTime == true)
            {
                if (questServices.GetQuestByName("Odwiedz Sklep {MorenArmorShop}") != null)
                {
                    questServices.DeleteQuest(questServices.GetQuestByName("Odwiedz Sklep {MorenArmorShop}").Id);
                }
                FirstTime = false;
            }
            Thread.Sleep(2000);
            Console.WriteLine("^Judaflin: WIIIIITAJ FIFFFFLIIIINIE! CZYCZYMMM MOGE DLA CIEBIE SLUZYC ?");
            Thread.Sleep(2000);
            Console.WriteLine("^Fiflin: Sie zobaczy! \n");
            Console.WriteLine("|++Wywar z Lumpaxowej Jagody {+20HP} -- 20 Morenow");
            Console.WriteLine("|%%Mutla Lemparu {+10Charisma} -- 5 Morenow");
            Console.WriteLine("|Miotla_Z_Badyli {&15Damage} -- 20 Morenow");
            ShopTemplate.ShopMethod(shop, player, lemparsMutlaService);
        }
    }
}
