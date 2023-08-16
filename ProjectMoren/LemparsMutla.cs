using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Markup;

namespace ProjectMoren
{
    public class LemparsMutla 
    {
        public int Id { get; set; }
        public int Charisma { get; set; }
        public bool IsDrinking { get; set; } = true;

        public override string ToString()
        {
            return $"{Charisma}";
        }
    }
    public interface ILemparsMutlaService
    {
        public async Task DrinkMutlaAsync() {}
    }
    public class LemparsMutlaService : ILemparsMutlaService
    {
        // pozostalosci po probie z "lock" private readonly object mutlasLock = new object();
        public List<LemparsMutla> mutlas { get; set; } = new();
        public void Add(int number)
        {
            var newMutla = new LemparsMutla() { Id = GetLastIndex() + 1, Charisma = number };
            mutlas.Add(newMutla);

        }
        public int GetLastIndex()
        {
            if (mutlas.Count == 0)
            {
                return 0;
            }
            return mutlas[mutlas.Count - 1].Id;
        }
        public void GetAllMutlas()
        {
            Console.WriteLine("Ilosc mutlii: ");
            foreach(var item in mutlas)
            {
                Console.WriteLine($"{item.Id}: {item.Charisma}");
            }
        }
        public LemparsMutla? GetMutlasById(int id) 
        {
            foreach(var item in mutlas)
            {
                if(item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
        public bool DeleteMutla(int id)
        {
            var item = GetMutlasById(id);
            if(item is null)
            {
                return false;
            }
            mutlas.Remove(item);
            return true;
        }

        public async Task DrinkMutlaAsync(Player player, int id)
        {
            int? charismaPoints = id != 0 ? GetMutlasById(id).Charisma : null;
            var mutla = GetMutlasById(id);
                if (mutla != null)
                {
                    player.Charisma += mutla.Charisma;
                    mutlas.Remove(mutla);
                }
                else { await Console.Out.WriteLineAsync("Niestety, ale nie posiadasz zadnych Mutlii!"); }
                await Task.Delay(30000);
            player.Charisma -= charismaPoints ?? 0;
        }
    }
}
