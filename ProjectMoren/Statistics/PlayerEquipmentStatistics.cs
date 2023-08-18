using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMoren
{
    public class PlayerEquipmentStatistics : StatisticsForItems
    {
       
        public PlayerEquipmentStatistics() : base()
        {
        }

        public List<StatisticsForItems> Statistics { get; set; } = new();

        public void ComparePlayerEquipmentAndStatisticsForItem(Player player)
        {
            List<string> item = new List<string>();
            foreach (var itemX in GetT<StatisticsForItems>())
            {
                item.Add(itemX.Name);
            }
            
            // Jesli bedziemy musieli zwrocic wszystkie wspolne elementy, wtedy mozemy utworzyc liste i wsadzic
            // albo itemPlayer albo itemStatistics

            foreach(var itemPlayer in player.Equipment.Values)
            {
                foreach (var itemStatistics in item)
                {
                    if(itemPlayer == itemStatistics)
                    {
                        Console.WriteLine("Shared propertie in eq and properties object: " + itemStatistics);
                    }
                }
            }
        }

        public void ComparePlayerEquipmentAndStatisticsForItemAndValues(StatisticsForItems stat)
        {
            for(int i = 0; i<GetT<StatisticsForItems>().Count(); i++)
            {
                Console.WriteLine(stat.GetPropertyStringName(i) + ": ");
                Console.Write("health: " + stat.ItemHealthFromStatisticForItems(stat.GetPropertyById(i)) + "|");
                Console.Write("damage: " + stat.ItemDamageFromStatisticForItems(stat.GetPropertyById(i)) + "|");
                Console.Write("mana: " + stat.ItemManaFromStatisticForItems(stat.GetPropertyById(i)) + "|");
                Console.Write("price: " + stat.ItemPriceFromStatisticForItems(stat.GetPropertyById(i)) + "|");
                Console.WriteLine();
            }
        }
        // Veresion of code above but the only diffrence is that there's a price variable is concerned
        public void ComparePlayerEquipmentAndStatisticsForItemAndValuesPRICE(Player player, StatisticsForItems stat)
        {
                List<string> item = new List<string>();
                foreach (var itemX in GetT<StatisticsForItems>())
                {
                    item.Add(itemX.Name);
                }

                // Jesli bedziemy musieli zwrocic wszystkie wspolne elementy, wtedy mozemy utworzyc liste i wsadzic
                // albo itemPlayer albo itemStatistics

                foreach (var itemPlayer in player.Equipment.Values)
                {
                    foreach (var itemStatistics in item)
                    {
                        if (itemPlayer == itemStatistics)
                        {
                            Console.Write("Cena przedmiotu: " + itemStatistics + ": ");
                            Console.WriteLine(stat.ItemPriceFromStatisticForItems(stat.GetProperty(itemStatistics)));
                        }
                    }
                }
        }

        public void IterateStatistics(Player player)
        {
            DisplayPropertyNames<StatisticsForItems>();
            //foreach(var property in GetT<StatisticsForItems>())
            //{
            //    Console.WriteLine(property.Name);
            //}
            Console.WriteLine(GetTOne<StatisticsForItems>("miotla"));
        }
        public void DisplayPropertyNames<T>()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            Console.WriteLine("Nazwa wlasciwosci klasy " + typeof(T).Name + ":");
            foreach (var property in properties)
            {
                Console.WriteLine(property.Name);
            }
        }
        public IEnumerable<PropertyInfo> GetT<T>()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            return properties;
        }
        public string GetTOne<T>(string name)
        {
            try
            {
                PropertyInfo[] properties = typeof(T).GetProperties();
                var it = properties[properties.ToList().FindIndex(item => item.Name == name)];
                return it.Name;
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine("Podaj wartosc z zakresu!"); 
            }
            return default(string);
        }
    }
}
