using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMoren
{
    public class StatisticsDefinition
    {
        public int damage { get; set; }
        public int health { get; set; }
        public int mana { get; set; }

        public StatisticsDefinition()
        {

        }
    }
    public class StatisticsForItems : IEnumerable<StatisticsDefinition>
    {
        // Items
        public List<StatisticsDefinition> Miotla { get; set; }
        public List<StatisticsDefinition> Zardzewiala_Siekiera { get; set; }
        public List<StatisticsDefinition> Swinka_Maskotka { get; set; }
        public List<StatisticsDefinition> Stary_Kubrak_Titalina { get; set; }
        public List<StatisticsDefinition> Klucz_Do_Szopy_W_Lesie_Swietego_Fiflaxa { get; set; }
        public List<StatisticsDefinition> Miotla_Z_Badyli { get; set; }

         
        public StatisticsForItems() : base()
        {
            Miotla = new List<StatisticsDefinition>() { new StatisticsDefinition() { damage = 5 } };
            Swinka_Maskotka = new List<StatisticsDefinition>() { new StatisticsDefinition() { mana = 5 } };
            Zardzewiala_Siekiera = new List<StatisticsDefinition>() { new StatisticsDefinition() { damage = 10 } };
            Stary_Kubrak_Titalina = new List<StatisticsDefinition>() { new StatisticsDefinition() { health = 5 } };
            Klucz_Do_Szopy_W_Lesie_Swietego_Fiflaxa = new List<StatisticsDefinition> { new StatisticsDefinition() { mana = 10 } };
            Miotla_Z_Badyli = new List<StatisticsDefinition> { new StatisticsDefinition() { damage = 15 } };
        }

        public List<StatisticsDefinition> GetProperty(string property)
        {
            switch (property)
            {
                case "Miotla": return Miotla; break;
                case "Swinka_Maskotka": return Swinka_Maskotka; break;
                case "Zardzewiala_Siekiera": return Zardzewiala_Siekiera; break;
                case "Stary_Kubrak_Titalina": return Stary_Kubrak_Titalina; break;
                case "Klucz_Do_Szopy_W_Lesie_Swietego_Fiflaxa": return Klucz_Do_Szopy_W_Lesie_Swietego_Fiflaxa; break;
                case "Miotla_Z_Badyli": return Miotla_Z_Badyli; break;
            }
            return null;
        }
        public List<StatisticsDefinition> GetPropertyById(int id)
        {
            switch (id)
            {
                case 0: return Miotla; break;
                case 1: return Swinka_Maskotka; break;
                case 2: return Zardzewiala_Siekiera; break;
                case 3: return Stary_Kubrak_Titalina; break;
                case 4: return Klucz_Do_Szopy_W_Lesie_Swietego_Fiflaxa; break;
                case 5: return Miotla_Z_Badyli; break;

            }
            return null;
        }public string GetPropertyStringName(int id)
        {
            switch (id)
            {
                case 0: return "Miotla"; break;
                case 1: return "Swinka_Maskotka"; break;
                case 2: return "Zardzewiala_Siekiera"; break;
                case 3: return "Stary_Kubrak_Titalina"; break;
                case 4: return "Klucz_Do_Szopy_W_Lesie_Swietego_Fiflaxa"; break;
                case 5: return "Miotla_Z_Badyli"; break;
            }
            return null;
        }

        public int ItemHealthFromStatisticForItems(List<StatisticsDefinition> prop)
        {
            foreach (var item in prop)
            {
                return item.health;
            }
            return default(int);
        }
        public int ItemManaFromStatisticForItems(List<StatisticsDefinition> prop)
        {
            foreach (var item in prop)
            {
                return item.mana;
            }
            return default(int);
        }
        //System.NullReferenceException:
        public int ItemDamageFromStatisticForItems(List<StatisticsDefinition> prop)
        {
            try
            {
                foreach (var item in prop)
                {
                    return item.damage;
                }
            }
            catch(System.NullReferenceException ex)
            {
                Console.WriteLine("Prosze podac wartosc z zakresu ekwipunku");
                return default(int);
            }
            return default(int);
        }

        public IEnumerator<StatisticsDefinition> GetEnumerator()
        {
            foreach(var item in this)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
