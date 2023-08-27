using ProjectMoren.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMoren.Templates
{
    public class ShopTemplate
    {
        public static void ShopMethod(Dictionary<int, string> dic, Player player, LemparsMutlaService lemparsMutlaService, PlayerEquipmentStatistics playerStats, StatisticsForItems statistic)
        {
            var m1 = "%%Mutla Lemparu {+10Charisma} -5Moren";
            var m2 = "%%Mutla Lemparu {+20Charisma} -10Moren";
            var m3 = "++Wywar z Lumpaxowej Jagody {+20HP} -20";

            string? agreement;
            string? item;

            Console.WriteLine("buy == kupno, sell == sprzedarz, check == cena twoich itemow:");

            agreement = Console.ReadLine();
            if (agreement == "check")
            {
                playerStats.ComparePlayerEquipmentAndStatisticsForItemAndValuesPRICE(player, statistic);
            }
            if (agreement == "buy")
            {
                Console.WriteLine("^Judaflin: Wybiebiebierz cos sobie Fiflinku !!!");
                Box.GetBoxAllLonger(dic);
                Console.WriteLine();
                player.IterateThroughTheEquipment();
                Console.WriteLine();

                Console.WriteLine("Wybierz miejsce na ladzie, gdzie chcesz wziac przedmiot: ");
                agreement = Console.ReadLine();
                bool intAgreementSecond = int.TryParse(agreement, out int resultSecond);
                string itemFromDictionary = Box.GetBoxItemById(dic, resultSecond);

                var boxShortCut = Box.GetBoxItemById(dic, resultSecond); // ---- BOX SHORTCUT


                if (Box.GetBoxItemById(dic, resultSecond) == "%%Mutla Lemparu{+10Charisma} -5")
                {
                    if (player.Moreny < 0 && player.Moreny == 0)
                    {
                        Console.WriteLine("^Judalin: Le Le Le piej przy y y jdz z pieniedzmi nas ss tepnym razem!");
                        return;
                    }
                    else if (5 > player.Moreny)
                    {
                        Console.WriteLine("^Judalin: Przy y ykro mi Fiflinie, ale nie mamy pie pie niedzy!");
                        return;
                    }
                    else
                    {
                        lemparsMutlaService.Add(10);
                        dic[resultSecond] = null;
                        player.Moreny -= 5;
                        player.AdjustDictionaryIndexes(player.Equipment);
                        return;
                    }
                }
                if (Box.GetBoxItemById(dic, resultSecond) == "%%Mutla Lemparu{+20Charisma} -10")
                {
                    if (player.Moreny < 0 && player.Moreny == 0)
                    {
                        Console.WriteLine("^Judalin: Le Le Le piej przy y y jdz z pieniedzmi nas ss tepnym razem!");
                        return;
                    }
                    else if (10 > player.Moreny)
                    {
                        Console.WriteLine("^Judalin: Przy y ykro mi Fiflinie, ale nie mamy pie pie niedzy!");
                        return;
                    }
                    else
                    {
                        lemparsMutlaService.Add(20);
                        dic[resultSecond] = null;
                        player.Moreny -= 10;
                        player.AdjustDictionaryIndexes(player.Equipment);
                        return;
                    }
                }
                if (Box.GetBoxItemById(dic, resultSecond) == "++Wywar z Lumpaxowej Jagody{+20HP} -20")
                {
                    if (player.Moreny < 0 && player.Moreny == 0)
                    {
                        Console.WriteLine("^Judalin: Le Le Le piej przy y y jdz z pieniedzmi nas ss tepnym razem!");
                        return;
                    }
                    else if (20 > player.Moreny)
                    {
                        Console.WriteLine("^Judalin: Przy y ykro mi Fiflinie, ale nie mamy pie pie niedzy!");
                        return;
                    }
                    else
                    {
                        player.AddPurseHP(20);
                        dic[resultSecond] = null;
                        player.Moreny -= 20;
                        player.AdjustDictionaryIndexes(player.Equipment);
                        return;
                    }
                }
                if (boxShortCut != null && boxShortCut != m1 && boxShortCut != m2 && boxShortCut != m3)
                {
                    int indexOfBracket = itemFromDictionary.IndexOf('{');
                    int indexOfBracketEnd = itemFromDictionary.IndexOf('}');


                    int indexOfMoney = itemFromDictionary.IndexOf('-');
                    string? MoneyToPay = itemFromDictionary.Remove(0, indexOfMoney + 1);
                    int MoneyToPayInt = int.Parse(MoneyToPay);

                    itemFromDictionary = itemFromDictionary.Remove(indexOfBracket, itemFromDictionary.Length - indexOfBracket);

                    if (player.Moreny < 0 && player.Moreny == 0)
                    {
                        Console.WriteLine("^Judalin: Le Le Le piej przy y y jdz z pieniedzmi nas ss tepnym razem!");
                        return;
                    }
                    else if (MoneyToPayInt > player.Moreny)
                    {
                        Console.WriteLine("^Judalin: Przy y ykro mi Fiflinie, ale nie mamy pie pie niedzy!");
                        return;
                    }
                    else
                    {
                        player.Moreny -= MoneyToPayInt;
                    }

                    player.Add(player.Equipment.Count, itemFromDictionary);
                    dic[resultSecond] = null;
                    Console.WriteLine($"-Straciles {MoneyToPayInt} Morenow");
                    Console.WriteLine($"*Dodano {itemFromDictionary}");

                    player.AdjustDictionaryIndexes(player.Equipment);
                }
                else
                {
                    Console.WriteLine("Niestety, ale w skrzynce nie odnaleziono takiego przedmiotu");
                }
            }
            // Else for the sell
            if (agreement == "sell")
            {
                bool allows = true;

                Console.WriteLine("^Judaflin: Da da daj mi cos sobie Fiflinku !!!");
                player.IterateThroughTheEquipment();
                Console.WriteLine();

                do
                {
                    if (allows == false)
                    {
                        player.IterateThroughTheEquipment();
                    }
                    Console.WriteLine("Wybierz swoj item");
                    agreement = Console.ReadLine();
                    bool agreementInt = int.TryParse(agreement, out int indexResult);
                    var itemByIndex = player.GetEquipmentItemByIndex(player.Equipment, indexResult);

                    int priceOfItem = playerStats.ItemPriceFromStatisticForItems(playerStats.GetProperty(itemByIndex));
                    try
                    {
                        if (playerStats.GetTOne<StatisticsForItems>(itemByIndex) == player.Equipment[player.GetEquipmentIndexByItem(player.Equipment, itemByIndex)])
                        {
                            player.Remove(player.GetEquipmentIndexByItem(dic, itemByIndex));
                            player.Moreny += priceOfItem;

                            Console.WriteLine($"--Straciles: {itemByIndex}");
                            Console.WriteLine($"++Twoje Moreny: {player.Moreny}");
                            allows = false;
                        }
                        else
                        {
                            Console.WriteLine("Wprowadz chuju poprawna wartosc!");
                            return;
                        }
                    }
                    catch (KeyNotFoundException ex)
                    {
                        Console.WriteLine("Podaj Kurwa wartosc z zakresu!");
                    }

                    if (allows == false)
                    {
                        Console.WriteLine("^Judaflin: Czy czy chcesz cos jeszcze ? | yes | no");
                        string? allowsAgreement = Console.ReadLine();
                        if (allowsAgreement == "yes")
                        {
                            player.AdjustDictionaryIndexes(player.Equipment);
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("^Judaflin: Pie Pie ppie nke rzeczy");
                            allows = true;
                        }
                    }
                    player.AdjustDictionaryIndexes(player.Equipment);
                } while (allows != true); ;
            }
        }
    }
}
