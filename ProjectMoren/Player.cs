using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using System.Dynamic;
using System.Numerics;
using System.Security.Cryptography;

namespace ProjectMoren
{
    public class Player : PurseService
    {
        public List<int> PlayerPosition { get; set; }
        public List<int> PlayerPositionMoren { get; set; }
        public Dictionary<int, string> Equipment = new Dictionary<int, string>().OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        public int number { get; set; }
        public string enterToLocation { get; set; }
        private bool playerPositionFlag { get; set; } = true;

        // Stats Section
        public int Hp { get; set; } = 50;
        public int? Charisma { get; set; } = 0;
        public int Moreny { get; set; } = 0;
        public int punch { get; set; } = 2;
        public int MutlaTime { get; set; } = 0;

        public Player() : base()
        {
        }

        public int GetHp() => Hp;
        public int? GetCharism() => Charisma;
        public int GetMoreny() => Moreny;
        public int GetPunch() => punch;

        public void GetAllAbilities()
        {
            Console.WriteLine($"HP: {Hp}");
            Console.WriteLine($"Charisma: {Charisma}");
            Console.WriteLine($"Moreny: {Moreny}");
            Console.WriteLine($"punch: {punch}");
        }

        // Money And HP section In the future will be more responsive money system

        public void AddPurseMoreny(int money)
        {
            Moreny += money;
        }
        public void AddPurseHP(int hp)
        {
            Hp += hp;
        }
        public void DeletePurseMoreny(int money)
        {
            Moreny -= money;
        }
        public void DeletePurseHP(int hp)
        {
            Hp -= hp;
        }

        public Dictionary<int, string> orderByKeyMethod()
        {
            return Equipment.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        public void AdjustDictionaryIndexes(Dictionary<int, string> originalDictionary)
        {
            Dictionary<int, string> modifiedDictionary = new Dictionary<int, string>();
            int NewIndex = 0;

            foreach(var item in originalDictionary)
            {
                modifiedDictionary.Add(NewIndex, item.Value);
                NewIndex++;
            }
            originalDictionary.Clear();
            foreach(var item in modifiedDictionary)
            {
                originalDictionary.Add(item.Key, item.Value);
            }
        }

        public void Add(int index, string item)
        {
            Equipment.Add(index, item);
        }
        public void Remove(int index)
        {
            Equipment.Remove(index);
        }
        public string GetEquipmentItemByItem(Dictionary<int, string> dic, string item)
        {
            var findItem = dic.FirstOrDefault(x => x.Value == item).Value;
            return findItem;
        }
        public int GetEquipmentIndexByItem(Dictionary<int, string> dic, string item)
        {
            var index = dic.FirstOrDefault(x => x.Value == item).Key;
            return index;
        }
        public string GetEquipmentItemByIndex(Dictionary<int, string> dic, int index)
        {
            var item = dic.FirstOrDefault(x => x.Key == index).Value;
            return item;
        }
        public void IterateThroughTheEquipment()
        {
            foreach (var item in Equipment)
            {
                Console.WriteLine(item.Key + " : " + item.Value);
            }
        }
        public int GetLastIndexOfEquipment()
        {
            return Equipment.Count;
        }

        public void PlayerMove(Graph graph)
        {
            Console.WriteLine("Wybierz Lokacje do ktorej chcesz sie udac: ");
            string? read = Console.ReadLine();
            if (read == "Moren")
            {
                Console.WriteLine("Vertex 0: ");
                PlayerPosition = graph.getVertexIndex(0);
                Console.WriteLine(PlayerPosition);
                Console.WriteLine("Moren!!!");
            }
            if (read == "Jaskinia Knuriona")
            {
                Console.WriteLine("Vertex 1: ");
                PlayerPosition = graph.getVertexIndex(1);
                Console.WriteLine(PlayerPosition);
                Console.WriteLine("Jaskinia Knuriona!!!");
            }
            if (read == "Las Druida")
            {
                Console.WriteLine("Vertex 2: ");
                PlayerPosition = graph.getVertexIndex(2);
                Console.WriteLine(PlayerPosition);
                Console.WriteLine("Las Druidow!!!");
            }
           
        }
        public void PlayerMoveSystem(Player player, Graph graph)
        {
            ConsoleKeyInfo keyinfo;
            ConsoleKeyInfo keyinfoTemp;
            string? PlayerPositionMoren = "O";
            string? PlayerPositionJaskinia = "O";
            string? PlayerPositionLas = "O";
            do
            {
                // Flag reset to prevent multiple statment execution
                playerPositionFlag = true;

                if (player.PlayerPosition.SequenceEqual(graph.getVertexIndex(0)))
                {
                    PlayerPositionMoren = "X";
                }
                else if (player.PlayerPosition.SequenceEqual(graph.getVertexIndex(1)))
                {
                    PlayerPositionJaskinia = "X";
                }
                else
                {
                    PlayerPositionLas = "X";
                }

                // Tutaj będzie pozycja gracza jako zmienna przekazana np jak tak

                Console.WriteLine($"(Moren: {PlayerPositionMoren})-------(Jaskinia: {PlayerPositionJaskinia})");
                Console.WriteLine("|                      |");
                Console.WriteLine("|                      |");
                Console.WriteLine("|                      |");
                Console.WriteLine($"Las: ({PlayerPositionLas})");

                if (player.PlayerPosition.SequenceEqual(graph.getVertexIndex(0)) && playerPositionFlag == true)
                {
                    Console.WriteLine("!Udaj sie do: ");
                    keyinfoTemp = Console.ReadKey();
                    if (keyinfoTemp.Key == ConsoleKey.DownArrow)
                    {
                        PlayerPositionMoren = "O";
                        player.PlayerPosition = graph.getVertexIndex(2);
                    }
                    else if (keyinfoTemp.Key == ConsoleKey.RightArrow)
                    {
                        PlayerPositionMoren = "O";
                        player.PlayerPosition = graph.getVertexIndex(1);
                    }
                    else
                    {
                        Console.WriteLine("Tam sie kurwa nie ruszysz xD");
                    }
                    playerPositionFlag = false;
                }

                if (player.PlayerPosition.SequenceEqual(graph.getVertexIndex(1)) && playerPositionFlag == true)
                {
                    Console.WriteLine("!Udaj sie do: ");
                    keyinfoTemp = Console.ReadKey();
                    if (keyinfoTemp.Key == ConsoleKey.LeftArrow)
                    {
                        PlayerPositionJaskinia = "O";
                        player.PlayerPosition = graph.getVertexIndex(0);
                    }
                    else
                    {
                        Console.WriteLine("Tam sie kurwa nie ruszysz xD");
                    }
                    playerPositionFlag = false;
                } 
                if (player.PlayerPosition.SequenceEqual(graph.getVertexIndex(2)) && playerPositionFlag == true)
                {
                    Console.WriteLine("!Udaj sie do: ");
                    keyinfoTemp = Console.ReadKey();
                    if (keyinfoTemp.Key == ConsoleKey.UpArrow)
                    {
                        PlayerPositionLas = "O";
                        player.PlayerPosition = graph.getVertexIndex(0);
                    }
                    else
                    {
                        Console.WriteLine("Tam sie kurwa nie ruszysz xD");
                    }
                    playerPositionFlag = false;
                }

                Console.WriteLine("Jesli chcesz wyjsc to kliknij X | Jesli Nie to wszystko inne");
                keyinfo = Console.ReadKey();

            } while (keyinfo.Key != ConsoleKey.X);
        }

        public void PlayerPositionSystem(Player player, Graph graph)
        {
            for (int i = 0; i < graph.TotalNumber - 1; i++)
            {

                switch (player.PlayerPosition[i])
                {
                    case 0: Console.WriteLine("Mozes udac sie do Moren!!!"); break;
                    case 1: Console.WriteLine("Mozesz udac sie do Jaskini Knuriona!!!"); break;
                    case 2: Console.WriteLine("Mozesz udac sie do Lasu Druidow!!!"); break;
                }
            }
        }
        public List<int> PlayerPositionCurrent(Player player, Graph graph)
        {
            for (int i = 0; i < graph.TotalNumber - 1; i++)
            {
                if (player.PlayerPosition[i].Equals(graph.getVertexIndex(0)))
                {
                    return player.PlayerPosition;
                }
                else if (player.PlayerPosition[i].Equals(graph.getVertexIndex(1)))
                {
                    return player.PlayerPosition;
                }
                else
                {
                    return player.PlayerPosition;
                }

            }
            return null;
        }
    }
}
