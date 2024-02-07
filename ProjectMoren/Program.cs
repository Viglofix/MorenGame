using System.Runtime.InteropServices;
using GameObjects;
using GameObjects.BasicGameMechanisms;
using ProjectMoren.StaticClasses;
using GameCommandManager;
using ProjectMoren.FirstMap.MorenLocation;
using Newtonsoft.Json;

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

        // || Moren Map Section

        Graph graphMoren = new(6);
        graphMoren.AddEdges(0, 1);
        graphMoren.AddEdges(0, 2);
        graphMoren.AddEdges(0, 3);
        graphMoren.AddEdges(0, 4);
        graphMoren.AddEdges(0, 5);
        graphMoren.AddEdges(1, 2);
        graphMoren.AddEdges(1, 3);
        graphMoren.AddEdges(1, 4);
        graphMoren.AddEdges(1, 5);
        graphMoren.AddEdges(2, 3);
        graphMoren.AddEdges(2, 4);
        graphMoren.AddEdges(2, 5);
        graphMoren.AddEdges(3, 4);
        graphMoren.AddEdges(3, 5);
        graphMoren.AddEdges(4, 5);

        // Serialization
        RootObject obj = new();
        Quest quest = new();

        // Menu Section
        var menuService = new MenuService(MenuService.CreateMenus());
        var menus = menuService.GetMenus();
        MenuService.ShowMenus(menus);

        // Map Section
        AllMorenLocations allMorenLocations = new();
        // PlayersObcjest Section
        var PlayerEq = new PlayerEquipmentStatistics();
        var statistic = new StatisticsForItems();

        // Game Working
        string? q;
        int p;
        CommandManager manager = new();

        obj.playerObject!.PlayerPosition = graph.getVertexIndex(0);
        obj.playerObject!.PlayerPositionMoren = graphMoren.getVertexIndex(0);

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
                        //Console.WriteLine("^Popilin: Sluchaj Fiflinie ! Jesli nie oddasz mi pieniedzy za te 10 mutli lemparu {100Morenow}, ktore wypisles \n na ostatnim Morenskim Ognisku Narodowym z mojego portfela to obiecuje ci, ze obudzisz sie bez glowy \n czyli w sumie sie nie obudzisz... A ta twoja swinia zostaie przerobiona na schabowe");
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
                        obj.questService!.AddQuest("Udaj sie do szopy {Home}");
                        obj.questService!.AddQuest("Udaj sie do Wodza {Chief}");
                        obj.questService!.AddQuest("Glowny Cel: Oddaj 100Morenow {PopilinBasement}");

                        break;
                    case 2:
                        Console.WriteLine("Wczytano!");
                       /* playerSerializedSecond = File.ReadAllText(@"D:\ProjektMoren\playerSerialized.json");
                        playerDeserialized = JsonConvert.DeserializeObject<Player>(playerSerializedSecond);
                        player = playerDeserialized; */
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

      //  Dictionary<int, string>? dic = new Dictionary<int, string>() { { 0, null! }, { 1, null! }, { 2, null! }, { 3, null! }, { 4, null! }, {5, null! }, { 6, null! }, { 7, null! }, {8, null! } };
        
        do
        {
            Console.Write("> ");
            q = Console.ReadLine();
            manager?.CommandManagerMethod(q!,quest!,obj.moren!,statistic,PlayerEq,allMorenLocations,graph,graphMoren,obj,ref obj);
            if(q == "load2"){
               obj = manager?.LoadMng()!;
            }
        } while (q != "quit");

    }
}
