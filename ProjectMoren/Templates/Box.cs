using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMoren
{
    public static class Box
    {
        public static void BoxMethod(Dictionary<int, string> dic, Player player)
        {
            string? agreement;
            string? item;
            DefaultTemplate.DefaultTemplateMethod(1, "Wez przedmiot", "Odloz przedmiot");
            agreement = Console.ReadLine();
            bool intAgreement = int.TryParse(agreement, out int result);
            switch (result)
            {
                case 0:
                    {
                        Console.WriteLine();
                        GetBoxAll(dic);
                        Console.WriteLine();
                        player.IterateThroughTheEquipment();
                        Console.WriteLine();

                        Console.WriteLine("Wybierz miejsce w skrzynce, gdzie chcesz wziac przedmiot: ");
                        agreement = Console.ReadLine();
                        bool intAgreementSecond = int.TryParse(agreement, out int resultSecond);
                        string itemFromDictionary = GetBoxItemById(dic, resultSecond);

                        if (GetBoxItemById(dic, resultSecond) != null)
                        {
                            player.Add(player.GetEquipmentIndexByItem(dic, itemFromDictionary), itemFromDictionary);
                            dic[resultSecond] = null;
                            Console.WriteLine($"*Dodano {itemFromDictionary}");
                        }
                        else
                        {
                            Console.WriteLine("Niestety, ale w skrzynce nie odnaleziono takiego przedmiotu");
                        }
                    }
                break;
                case 1:
                    {
                        Console.WriteLine();
                        GetBoxAll(dic);
                        Console.WriteLine();
                        player.IterateThroughTheEquipment();
                        Console.WriteLine();

                        Console.WriteLine("Wybierz miejsce w skrzynce: ");
                        agreement = Console.ReadLine();
                        Console.WriteLine("Wybierz przedmiot, ktory chcesz odlozyc: ");
                        item = Console.ReadLine();

                        bool intItem = int.TryParse(item, out int resultItem);
                        bool intAgreementSecond = int.TryParse(agreement, out int resultSecond);

                        string stringItem = player.GetEquipmentItemByIndex(player.Equipment, resultItem);

                        if (GetBoxItemById(dic, resultSecond) == null && player.Equipment.ContainsValue(stringItem) == true)
                        {
                            player.Remove(player.GetEquipmentIndexByItem(player.Equipment, stringItem));
                            dic[resultSecond] = stringItem;
                        }
                        else
                        {
                            Console.WriteLine("Niestety, ale nie posiadasz danego przedmiotu w ekwipunku, lub tez wybrales zajete miejsce w box");
                        }
                    }
                break;
                default: Console.WriteLine("Lepiej sie zdecyduj, bo juz mnie wkurwia ten kod"); break;
            }
            player.AdjustDictionaryIndexes(player.Equipment);
        }
        public static int GetEquipmentIndexByItem(Dictionary<int, string> dic, string item)
        {
            var index = dic.FirstOrDefault(x => x.Value == item).Key;
            return index;
        }
        public static string GetBoxItemById(Dictionary<int, string> dic, int indeXX)
        {
            var index = dic.FirstOrDefault(x => x.Key == indeXX).Value;
            return index;

        }
        public static void GetBoxAll(Dictionary<int, string> dic)
        {
            foreach(var item in dic)
            {
                Console.Write(item.Key + ": " + item.Value + " ");
                if(item.Key == 2)
                {
                    Console.WriteLine();
                }
                if(item.Key == 5)
                {
                    Console.WriteLine();
                }
                if(item.Key == 8)
                {
                    Console.WriteLine();
                }
            }
        }  
        public static void GetBoxAllLonger(Dictionary<int, string> dic)
        {
            foreach(var item in dic)
            {
                Console.WriteLine(item.Key + ": " + item.Value + " ");
            }
        }
    }
}
