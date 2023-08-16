using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMoren
{
    public class MorenChiefHome : MARKS
    {
        public bool possibilityOne = true;
        public bool possibilityZero= true;
        public Dictionary<int, string> toolsBox = new Dictionary<int, string>() { { 0, null! }, { 1, null! }, { 2, null! }, { 3, null! }, { 4, null! }, { 5, null! }, { 6, null! }, { 7, null! }, { 8, null! } };

        public MorenChiefHome()
        {
            toolsBox[8] = "Mlotek_Wodza";
            toolsBox[4] = "Bambus_Do_Nawadniania_Kwiatow";
            toolsBox[6] = "Siatka_Na_Morliny";
        }

        public void ChiefHome(Player player, QuestServices questServices)
        {

            int boolMlotek;
            int boolBambus;
            int boolMorliny;

            string agreement;
            if (questServices.GetQuestByName("Udaj sie do Wodza {Chief}") != null)
            {
                questServices.DeleteQuest(questServices.GetQuestByName("Udaj sie do Wodza {Chief}").Id);
            }

            if (possibilityOne == true && possibilityZero == true)
            {
                DialogueQuestion.ThreeHeroesTwo(1, "Wodz z oddali", "Skryba Penntilin z oddali", "To jest jakis absurd by Fiflaxy w kraju \n w ktorym nie dziala system emerytalny  \n chcialy zmniejszyc definicje bycia seniorem \n do 55 roku zycia, tylko dodaja mi bez przerwy roboty", "Trudno sie z Panem nie zgodzic Panie Wodzu, iscie smysny pomysl. \n Jednakze wasza Wodzowatosc ze swoja jakze ponad przecietna inteligencja \n upora sie z kolejnym problemem natury biurokratycznej...", "","");
                Console.WriteLine("^Wodz: No no wiem wiem...");

                Thread.Sleep(3000);
                DialogueQuestion.ThreeHeroesTwo(0, "Fiflin", "Wodz", "Znowu przy schodach do tego tlustego lumpaxa...", "", "", "");
                DialogueQuestion.ThreeHeroesTwo(2, "Wodz", "Fiflin", "Fiflin ? Czego tutaj szukasz przyglupie !?", "Szukam u Pana Wodza pracy", "HaHaHa ! Obchody Dnia Moren byly tydzien temu, No wlasnie... Pewnie zbyt bardzo zabalangowales przyglupie. Przyznaj sie!", "....");
                DefaultTemplate.DefaultTemplateMethod(1, "Powiedz prawde", "Sklam -- 10 punktow charyzmy");
                agreement = Console.ReadLine();
                bool parseAgreement = int.TryParse(agreement, out int result);
                if (result == 1 && player.Charisma >= 10)
                {
                    Console.WriteLine("Idz poscieraj kurze w piwnicy, w ktorej nie ma swiatla.");
                    Console.WriteLine("W tym scenariuszu Fiflin zdobedzie 50 Morenow w piwnicy a na dodatek zarobi dzieki swojemu kreatywnemu klamstwu");
                    possibilityOne = false;
                }
                else
                {
                    if (possibilityOne == true)
                    {
                        DialogueQuestion.ThreeHeroesTwo(1, "Fiflin", "Wodz", "Musze przyanzac racje, jednakze tym razem mam zamiar odpracowac swoje winy!", "Z okazji tego, ze jeszcze nigdy nie bylo w historii tak, ze Fiflin z Moren probowal podjac u mnie legalnej pracy \n to z lekkim przymrozeniem oka moge sie zgodzic...", "", "");
                        DialogueQuestion.ThreeHeroesTwo(1, "Fiflin", "Wodz", "Dziekuje ci Wodzu najwspanialszy, a wiec co mam robic?", "Zacznij od poukładania przedmiotow w mojej skrzyni z narzedziami debi... Fiflinie", "", "");
                        do
                        {
                            Console.WriteLine("Mlotek_Wodza {3} | Bambus_Do_Nawadniania_Kwiatow {1} | Siatka_Na_Morliny {2}");
                            Box.BoxMethod(toolsBox, player);
                            boolMlotek = Box.GetEquipmentIndexByItem(toolsBox, "Mlotek_Wodza");
                            boolBambus = Box.GetEquipmentIndexByItem(toolsBox, "Bambus_Do_Nawadniania_Kwiatow");
                            boolMorliny = Box.GetEquipmentIndexByItem(toolsBox, "Siatka_Na_Morliny");
                        } while (!(boolMlotek == 3 && boolBambus == 1 && boolMorliny == 2));
                        Console.WriteLine("8 godzin pozniej....");
                        Thread.Sleep(2000);
                        DialogueQuestion.ThreeHeroesTwo(1, "Fiflin", "Wodz", "Skonczylem Szefie !", "No dobra, masz tu {*10 Morenow} i zmykaj", "", "");
                        DialogueQuestion.ThreeHeroesTwo(1, "Fiflin", "Wodz", "Tylko tyle jak ja sie wyplace?!", "Bylo o tym pomyslec tydzien temu przylupie!", "", "");
                        player.Moreny += 10;
                        Thread.Sleep(2000);
                        Console.WriteLine();
                        Console.WriteLine("...Fiflin rozpaczony cala sytuacja postanowil sprobowac jedynego slusznego sposobu \n na szybki zarobek wiedzac ze i tak obicie mordy go nie ominie. \n Chodzi oczywiscie o Morenska Arene Rekreacyjno-Kulturalna-Sportowa w skorocie {MARKS}...");
                        questServices.AddQuest("Odwiedz Sklep {MorenArmorShop}");
                        questServices.AddQuest("Udaj sie na arene, chociaz pierwsze polecalbym udac sie do sklepu {MARKS}");
                        possibilityZero = false;
                    }
                    else
                    {
                        return;
                    }
                }

            }
            else
            {
                Console.WriteLine("Tutaj bedzie mozliwosc wlamania sie do Wodza...");
            }
        }
    }
}
