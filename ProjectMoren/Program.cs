using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Media;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Castle.DynamicProxy;

namespace ProjectMoren; 
   
public class Program
{

    [DllImport("kernel32.dll", ExactSpelling = true)]
    private static extern IntPtr GetConsoleWindow();
    private static IntPtr ThisConsole = GetConsoleWindow();
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    private const int HIDE = 0;
    private const int MAXIMIZE = 3;
    private const int MINIMIZE = 6;
    private const int RESTORE = 9;

    public static void Main(string[] args)
    {
        // Visual section
        Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        ShowWindow(ThisConsole, MAXIMIZE);
        Console.ForegroundColor = ConsoleColor.Green;
        /* if (OperatingSystem.IsWindows()) { SoundPlayer sound = new SoundPlayer("D:\\ytdlp\\Beware the Forest's Mushrooms - Super Mario RPG [iudB3TreJfM].wav"); sound.PlayLooping(); }
         else { Console.WriteLine("Muzyka jest nieobsługiwana"); } */

        // Logical Map structure Section

        Graph graph = new(3);
        graph.AddEdges(0, 1);
        graph.AddEdges(0, 2);
        graph.AddEdges(1, 2);
        graph.PrintGraph();

        // Serialization
        string playerSerialized;
        string morenSerialized;
        string gesSerialized;
        string questSerialized;
        string lemparsMutlaServiceSerialized;
        string morenChiefHomeSerialized;

        string playerSerializedSecond;
        Player playerDeserialized;

        string morenSerializedSecond;
        Moren morenDeserialized;

        string gesSerializedSecond;
        Ges gesDeserialized;
        
        string questSerializedSecond;
        QuestServices questDeserialized;

        string lemparsSerializedSecond;
        LemparsMutlaService lemparsMutlaServiceDeserialized;

        string morenChiefHomeSerializedSecond;
        MorenChiefHome morenChiefHomeDeserialized;


        // QuestManager
        QuestServices questService = new();
        Quest quest = new();

        // Mutla System

        LemparsMutlaService lemparsMutlaService = new();

        // Menu Section
        var menuService = new MenuService(MenuService.CreateMenus());
        var menus = menuService.GetMenus();
        MenuService.ShowMenus(menus);

        // Map Section

        var moren = new Moren();

        // PlayersObcjest Section
        var player = new Player();
        var PlayerEq = new PlayerEquipmentStatistics();
        var ges = new Ges();

        // Game Working
        string q;
        int p;
        player.PlayerPosition = graph.getVertexIndex(0);
        var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

        // Preparing settings for player 
        do
        {
            Console.Write("> ");
            try
            {
                p = Convert.ToInt32(Console.ReadLine());
                switch (p)
                {
                    case 1:
                        Console.WriteLine("Rozpoczynamy nową przygodę!");
                        //Thread.Sleep(2000);
                        //Console.WriteLine("");
                        //Thread.Sleep(2000);
                        //Console.WriteLine("W odleglym Moren... ");
                        //Thread.Sleep(2000);
                        //Console.WriteLine("^Fiflin: Chyba musimy sie udac do szopy Swinko Hrumlinie, zbliza sie rocznica dostania \n przez nas swinki maskotki od Fifolina");
                        //Thread.Sleep(2000);
                        //Console.WriteLine("^Hrumlin: Hrum hrum...");
                        //Thread.Sleep(2000);
                        //Console.WriteLine("^Fiflin: Dokladnie!");
                        //Thread.Sleep(2000);
                        //Console.WriteLine("^Fiflin: Patrz ktos tam idzie Hrumlinie!");
                        //Thread.Sleep(2000);
                        //Console.WriteLine("^Popilin: Sluchaj Fiflinie ! Jesli nie oddasz mi pieniedzy za te 10 mutli lemparu {50Morenow}, ktore wypisles \n na ostatnim Morenskim Ognisku Narodowym z mojego portfela to obiecuje ci, ze obudzisz sie bez glowy \n czyli w sumie sie nie obudzisz... A ta twoja swinia zostaie przerobiona na schabowe");
                        //Thread.Sleep(2000);
                        //Console.WriteLine("^Hrumlin: :O");
                        //Thread.Sleep(2000);
                        //Console.WriteLine("^Fiflin: :O");
                        //Thread.Sleep(2000);
                        //Console.WriteLine("^Popilin: Żegnam Ozieble!");
                        //Thread.Sleep(2000);
                        //Console.WriteLine("^Hrumlin: Hrum Hruuum Hrum Hrum!?");
                        //Thread.Sleep(2000);
                        //Console.WriteLine("^Fiflin: Jest tylko jedno rozwiazanie, musimy isc do Wodza poszukac pracy!");
                        //Thread.Sleep(2000);
                        //Console.WriteLine("^Hrumlin: Hrum Hrum!?");
                        //Thread.Sleep(2000);
                        //Console.WriteLine("^Fiflin: Ale pierwsze musimy udac sie do naszej szopy!");
                        //Console.WriteLine("^Fiflin: Swinko biegnij do szopy, ja sam musze rozprawic sie ze zlodziejami!");
                        //Thread.Sleep(2000);
                        //Console.WriteLine();
                        //Console.WriteLine("!Mozesz udac sie do szopy Fiflina {Home}. Za pomoca polecenia quest mozesz sprawdzic aktualna liste zadan!");
                        //Console.WriteLine("!Mozesz udac sie do Wodza Moren {Chief}. Za pomoca polecenia quest mozesz sprawdzic aktualna liste zadan!");
                        questService.AddQuest("Udaj sie do szopy {Home}");
                        questService.AddQuest("Udaj sie do Wodza {Chief}");

                        break;
                    case 2:
                        Console.WriteLine("Wczytano!");
                        playerSerializedSecond = File.ReadAllText(@"D:\ProjektMoren\playerSerialized.json");
                        playerDeserialized = JsonConvert.DeserializeObject<Player>(playerSerializedSecond);
                        player = playerDeserialized;

                        morenSerializedSecond = File.ReadAllText(@"D:\ProjektMoren\moren.json");
                        morenDeserialized = JsonConvert.DeserializeObject<Moren>(morenSerializedSecond);
                        moren = morenDeserialized;

                        gesSerializedSecond = File.ReadAllText(@"D:\ProjektMoren\ges.json");
                        gesDeserialized = JsonConvert.DeserializeObject<Ges>(gesSerializedSecond);
                        ges = gesDeserialized;

                        questSerializedSecond = File.ReadAllText(@"D:\ProjektMoren\quest.json");
                        questDeserialized = JsonConvert.DeserializeObject<QuestServices>(questSerializedSecond);
                        questService = questDeserialized;

                        lemparsSerializedSecond = File.ReadAllText(@"D:\ProjektMoren\lempar.json");
                        lemparsMutlaServiceDeserialized = JsonConvert.DeserializeObject<LemparsMutlaService>(lemparsSerializedSecond);
                        lemparsMutlaService = lemparsMutlaServiceDeserialized;

                        break;
                    case 3:
                        Console.WriteLine("Opowiadano!");
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja.");
                        break;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Nieprawidłowy format. Wprowadź liczbę.");
                p = 0; // Set p to an invalid value to continue the loop.
            }
        }
        while (p != 1 && p != 2 && p != 3);

        Dictionary<int, string>? dic = new Dictionary<int, string>() { { 0, null! }, { 1, null! }, { 2, null! }, { 3, null! }, { 4, null! }, {5, null! }, { 6, null! }, { 7, null! }, {8, null! } };

        do
        {
            Console.Write("> ");
            q = Console.ReadLine();
            switch (q)
            {
                case "map": player.PlayerMove(graph); break;
                case "position":
                    for (int i = 0; i < graph.TotalNumber - 1; i++)
                    {
                        
                        switch (player.PlayerPosition[i])
                        {
                            case 0: Console.WriteLine("Mozes udac sie do Moren!!!"); break;
                            case 1: Console.WriteLine("Mozesz udac sie do Jaskini Knuriona!!!"); break;
                            case 2: Console.WriteLine("Mozesz udac sie do Lasu Druidow!!!"); break;
                        }
                    }
                    break;
                case "save":

                    playerSerialized = JsonConvert.SerializeObject(player);
                    File.WriteAllText(@"D:\ProjektMoren\playerSerialized.json", playerSerialized);

                    morenSerialized = JsonConvert.SerializeObject(moren);
                    File.WriteAllText(@"D:\ProjektMoren\moren.json", morenSerialized);

                    gesSerialized = JsonConvert.SerializeObject(ges);
                    File.WriteAllText(@"D:\ProjektMoren\ges.json", gesSerialized);

                    questSerialized = JsonConvert.SerializeObject(questService);
                    File.WriteAllText(@"D:\ProjektMoren\quest.json", questSerialized);

                    lemparsMutlaServiceSerialized = JsonConvert.SerializeObject(lemparsMutlaService);
                    File.WriteAllText(@"D:\ProjektMoren\lempar.json", lemparsMutlaServiceSerialized);

                    break;
                case "load":

                    playerSerializedSecond = File.ReadAllText(@"D:\ProjektMoren\playerSerialized.json");
                    playerDeserialized = JsonConvert.DeserializeObject<Player>(playerSerializedSecond);
                    player = playerDeserialized;

                    morenSerializedSecond = File.ReadAllText(@"D:\ProjektMoren\moren.json");
                    morenDeserialized = JsonConvert.DeserializeObject<Moren>(morenSerializedSecond);
                    moren = morenDeserialized;
                    
                    gesSerializedSecond = File.ReadAllText(@"D:\ProjektMoren\ges.json");
                    gesDeserialized = JsonConvert.DeserializeObject<Ges>(gesSerializedSecond);
                    ges = gesDeserialized;

                    questSerializedSecond = File.ReadAllText(@"D:\ProjektMoren\quest.json");
                    questDeserialized = JsonConvert.DeserializeObject<QuestServices>(questSerializedSecond);
                    questService = questDeserialized;

                    lemparsSerializedSecond = File.ReadAllText(@"D:\ProjektMoren\lempar.json");
                    lemparsMutlaServiceDeserialized = JsonConvert.DeserializeObject<LemparsMutlaService>(lemparsSerializedSecond);
                    lemparsMutlaService = lemparsMutlaServiceDeserialized;

                    break;
                case "eq":
                    player!.IterateThroughTheEquipment(); break;
                case "eqShed": moren!.ShowShedItems(); break;
                case "stat": PlayerEq.IterateStatistics(player!); break;
                case "compare": PlayerEq.ComparePlayerEquipmentAndStatisticsForItem(player!); break;
                case "compareAll": PlayerEq.ComparePlayerEquipmentAndStatisticsForItemAndValues(PlayerEq); break;
                case "gesHp": Console.WriteLine(); break;
                case "playerHp": Console.WriteLine(player!.GetHp()); break;
                case "playerCharisma": Console.WriteLine(player!.GetCharism()); break;
                case "playerPunch": Console.WriteLine(player!.GetPunch()); break;
                case "playerMoreny": Console.WriteLine(player!.GetMoreny()); break;
                case "AddMoreny": player.Moreny += 50; break;
                case "abs": player!.GetAllAbilities(); break;
                case "counter": Console.WriteLine(EnemiesBase.counter); break;
                case "quest": questService!.GetAllQuests(); break;
                case "questAdd": questService!.AddQuest("QuestTest1"); break;
                case "questDelete": questService!.DeleteQuest(questService._quests.Count); break;
                case "DrinkMutla": lemparsMutlaService!.DrinkMutlaAsync(player!, lemparsMutlaService.mutlas.Count); break;
                case "DrinkAdd": lemparsMutlaService!.Add(10); break;
                case "DrinkDelete": Console.WriteLine(lemparsMutlaService!.DeleteMutla(lemparsMutlaService.mutlas.Count)); break;
                case "GetAllMutlas": lemparsMutlaService!.GetAllMutlas(); break;
                case "Box":
                    Box.BoxMethod(dic, player!); 
                    break;
                case "BoxAll":
                    Box.GetBoxAll(dic); break;

            }
            // Method SequenceEqual compares two Lists according to the value -- it is the Linq method
            // Mozemy rowniez posortowac dwie listy w kolejnosci rosnacej dzieki czemu mozemy porowanac dwie listy
            // gdy sa one nieuporzadkowane. Mozna tez uzyc kolekcji HashSet, ktora usuwa duplikaty
            // W NASZYM PRZYPADKU korzystamy z tego, poniewaz przy wczytywaniu danych z json ewidentnie
            // gubimy referencje do naszych obiektow, wiec nie mozemy ich porownac. dlatego porownujemy je za pomoca
            // sequenceEqual po wartosci elementow [1,2] i [1,2] zwraca true

            if (player.PlayerPosition.SequenceEqual(graph.getVertexIndex(0)) && q == "Home")
            {
                moren.FiflinsShed(player, quest, questService, lemparsMutlaService);
            }
            if(player.PlayerPosition.SequenceEqual(graph.getVertexIndex(0)) && q == "TitalinHome")
            {
                moren.TitalinHouse(player, PlayerEq, ges, questService); 
            }
            if(player.PlayerPosition.SequenceEqual(graph.getVertexIndex(0)) && q == "MARKS")
            {
                moren.MARKSEnterAgreement = true;
                if (moren.MARKSEnterPossibility == true)
                {
                    moren.MARKSBeginning(player, ges!, PlayerEq, questService!);
                }
            else if (moren.MARKSEnterPossibility == false && moren.DeathAgreement == false) {
                    if (moren.MARKSAge >= 55)
                    {
                        object[] EnemiesObjectsArray = { new DziadekRumooplin(), new PanHeinzelin(), new PanMiliolin() };
                        Random random = new Random();
                        int luckyIndex = random.Next(0, EnemiesObjectsArray.Length);
                        object luckyObject = EnemiesObjectsArray[luckyIndex];

                        using (EnemiesBase enemy = luckyObject as EnemiesBase)
                        {
                            moren.MARKSArena(player, enemy, PlayerEq);
                            Console.WriteLine($"Wygrales pojedynek {moren.MARKSName}");
                            // enemyOne.Dispose(); Nalezy pamietac o tym, ze metoda ta jest wywolywana automatycznie w using, a uzywanie jej jawnie moze prowadzic do wycieku pamieci i nieprawidlowego zarzadzanania zasobow
                        }
                    }
                    else
                    {
                        // Tutaj beda trudniejsi przeciwnicy... 
                        object[] EnemiesObjectsArray = { new DziadekRumooplin(), new PanHeinzelin(), new PanMiliolin() };
                        Random random = new Random();
                        int luckyIndex = random.Next(0, EnemiesObjectsArray.Length);
                        object luckyObject = EnemiesObjectsArray[luckyIndex];

                        using (EnemiesBase enemy = luckyObject as EnemiesBase)
                        {
                            moren.MARKSArena(player, enemy, PlayerEq);
                            Console.WriteLine($"Wygrales pojedynek {moren.MARKSName}");
                            // enemyOne.Dispose(); Nalezy pamietac o tym, ze metoda ta jest wywolywana automatycznie w using, a uzywanie jej jawnie moze prowadzic do wycieku pamieci i nieprawidlowego zarzadzanania zasobow
                        }
                    }
                }
                else
                {
                    Console.WriteLine("^BuchMajster: WYPAD PTASIMOZGU!");
                }
                
            }
            if (player.PlayerPosition.SequenceEqual(graph.getVertexIndex(0)) && q == "Chief")
            {
                moren.ChiefHome(player, questService);
            } 
            if (player.PlayerPosition.SequenceEqual(graph.getVertexIndex(0)) && q == "MorenArmorShop")
            {
                moren.Judaflin(player, questService, lemparsMutlaService);
            }
        } while (q != "quit");

    }
}
