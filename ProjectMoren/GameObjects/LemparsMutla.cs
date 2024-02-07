using System.Text.Json.Serialization;

namespace GameObjects;
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
    public class LemparsMutlaService
    {
        // pozostalosci po probie z "lock" private readonly object mutlasLock = new object();
        public List<LemparsMutla> mutlas { get; set; } 
        private readonly object _SyncObj = new object();
        private static int methodCounter = 0;
        
        [JsonConstructor]
        public LemparsMutlaService(List<LemparsMutla> mutlasX) {
            mutlas = mutlasX;
        }
        public LemparsMutlaService(){
            mutlas = new();
        }

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

        public async Task DrinkMutlaAsync(PlayerObject player, int id)
        {
            int? charismaPoints = id != 0 ? GetMutlasById(id)!.Charisma : null;
            var mutla = GetMutlasById(id);
                if (mutla != null)
                {
                    player.Charisma += mutla.Charisma;
                    mutlas.Remove(mutla);
                }
                else { await Console.Out.WriteLineAsync("Niestety, ale nie posiadasz zadnych Mutlii!"); return; }
            
            // This section is dedicated to the timer system
            // At first we need to invoke new thread from the pool using
            // the Task.Run method which takes an Action delegate and return new task 
            // directly from our method.
            // Next we have to declare a lock keyword to block another threads from the pool
            // Then every single thread invoked by this Task will be able to done the given quest
            // by calculating from 30 to zero every single invocation
            // lock must be necessary with the await Task.Run because lock itself in that case is blocking a main thread itself
            // so we arent able to do anything.
            // We can't use await so we are not sure if the compiler doesnt avoid our Task before the the complshion
            // 

            await Task.Run(() =>
            {
                lock (_SyncObj)
                {
                    player.MutlaTime = 30;
                    while (player.MutlaTime != 0 || player.MutlaTime! > 0)
                    {
                        Thread.Sleep(1000);
                        player.MutlaTime--;
                    }
                }
            });
           
            player.Charisma -= charismaPoints ?? 0;
        }
        public async Task GetMutlaTime(PlayerObject player)
        {
            await Task.Run(() => { Console.Out.WriteLineAsync("Zostalo ci mutlomocy: " + player.MutlaTime); }); 
        }
    }
