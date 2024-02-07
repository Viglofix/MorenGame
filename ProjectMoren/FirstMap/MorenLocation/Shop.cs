using GameObjects;
using GameObjects.BasicGameMechanisms;
using ProjectMoren.StaticClasses;
using ProjectMoren.Templates;

namespace ProjectMoren.FirstMap.MorenLocation
{
    public class Shop
    {
        public Dictionary<int, string> shop = new Dictionary<int, string>() { { 0, null! }, { 1, null! }, { 2, null! }, { 3, null! }, { 4, null! }, { 5, null! }, { 6, null! }, { 7, null! }, { 8, null! } };
        public bool FirstTime = true;

        public Shop()
        {
            shop[0] = "++Wywar z Lumpaxowej Jagody{+20HP} -10";
            shop[1] = "%%Mutla Lemparu{+20Charisma} -10";
            shop[2] = "%%Mutla Lemparu{+10Charisma} -5";
            shop[3] = "%%Mutla Lemparu{+10Charisma} -5";
            shop[4] = "%%Mutla Lemparu{+10Charisma} -5";
            shop[5] = "Miotla_Z_Badyli{&15Damage} -20";
            shop[6] = "++Wywar z Lumpaxowej Jagody{+20HP} -10";
            shop[7] = "++Wywar z Lumpaxowej Jagody{+20HP} -10";

        }

        public void Judaflin(PlayerObject player, QuestService questServices, LemparsMutlaService lemparsMutlaService, PlayerEquipmentStatistics playerStats, StatisticsForItems statistic)
        {
            if (FirstTime == true)
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
            Console.WriteLine("|++Wywar z Lumpaxowej Jagody {+20HP} -20Moren");
            Console.WriteLine("|%%Mutla Lemparu {+10Charisma} -5Moren");
            Console.WriteLine("|%%Mutla Lemparu {+20Charisma} -10Moren");
            Console.WriteLine("|Miotla_Z_Badyli {&15Damage} -20Moren");
            ShopTemplate.ShopMethod(shop, player, lemparsMutlaService, playerStats, statistic);
        }
    }
}
