using GameObjects;
using ProjectMoren.FirstMap.MorenLocation;
using ProjectMoren.FirstMap.MorenLocation.Enemies;
using ProjectMoren.FirstMap.MorenLocation.Enemies.EnemiesBaseElderyEntities;
using ProjectMoren.StaticClasses;
using ProjectMoren.Templates;
using SaveLoadManager;

namespace GameCommandManager;

public class CommandManager {
    private RootObject? tempObj = null;
    public void CommandManagerMethod(string q,Quest quest, Moren moren,StatisticsForItems statistics, PlayerEquipmentStatistics? PlayerEq,AllMorenLocations allMorenLocations,Graph graph,Graph graphmoren,RootObject rootObject,ref RootObject referenceObject){
          Dictionary<int, string>? dic = new Dictionary<int, string>() { { 0, null! }, { 1, null! }, { 2, null! }, { 3, null! }, { 4, null! }, {5, null! }, { 6, null! }, { 7, null! }, {8, null! } };
          switch (q)
            {
                case "map": rootObject!.playerObject!.PlayerMove(graph); break;
                case "position": rootObject!.playerObject!.PlayerPositionSystem(rootObject!.playerObject!, graph); break;
                case "moveSystem": rootObject!.playerObject!.PlayerMoveSystem(rootObject!.playerObject!, graph); break;
                case "moveSystemMoren": rootObject!.playerObject!.PlayerMoveSystem(rootObject!.playerObject!, graph); break;
                case "positionSystemMoren": allMorenLocations.PlayerPositionSystemMoren(rootObject!.playerObject!, graph); break;
                case "save":
            /*      playerSerialized = JsonConvert.SerializeObject(player);
                    File.WriteAllText(@"D:\ProjektMoren\playerSerialized.json", playerSerialized); */
                    Action action = new Action(async () => {
                    var context = AppContext.BaseDirectory;
                    var path = Path.Combine(context,"config.json");
                    await SaveSystemManager.GetInstance.SaveGameProgress(path,rootObject);
                    });
                    action.Invoke();
                    break;
                case "load":
                 /*   playerSerializedSecond = File.ReadAllText(@"D:\ProjektMoren\playerSerialized.json");
                    playerDeserialized = JsonConvert.DeserializeObject<Player>(playerSerializedSecond);
                    player = playerDeserialized; */
                    RootObject? loadedObj = null;
                    Action action1 = new Action(async ()=> {
                    var contextLoad = AppContext.BaseDirectory;
                    var pathLoad = Path.Combine(contextLoad,"config.json");
                    loadedObj = await SaveSystemManager.GetInstance.LoadGameProgressAsync(pathLoad);
                    });
                    action1.Invoke();
                    referenceObject = loadedObj!;
                    break;
                case "eq":
                     rootObject.playerObject!.IterateThroughTheEquipment(); break;
                case "eqShed": rootObject.moren!.ShowShedItems(); break;
                case "stat": PlayerEq!.IterateStatistics(rootObject.playerObject!); break;
                case "compare": PlayerEq!.ComparePlayerEquipmentAndStatisticsForItem(rootObject.playerObject!); break;
                case "compareAll": PlayerEq!.ComparePlayerEquipmentAndStatisticsForItemAndValues(PlayerEq); break;
                case "gesHp": Console.WriteLine(rootObject.ges); break;
                case "playerHp": Console.WriteLine(rootObject.playerObject!.GetHp()); break;
                case "playerCharisma": Console.WriteLine(rootObject.playerObject!.GetCharism()); break;
                case "playerPunch": Console.WriteLine(rootObject.playerObject!.GetPunch()); break;
                case "playerMoreny": Console.WriteLine(rootObject.playerObject!.GetMoreny()); break;
                case "AddMoreny": rootObject.playerObject!.Moreny += 50; break;
                case "abs": rootObject.playerObject!.GetAllAbilities(); break;
                case "counter": Console.WriteLine(EnemiesBase.counter); break;
                case "quest": rootObject.questService!.GetAllQuests(); break;
                case "questAdd": rootObject.questService!.AddQuest("QuestTest1"); break;
                case "questDelete": rootObject.questService!.DeleteQuest(rootObject.questService._quests.Count); break;
                case "DrinkMutla": 
                Action action3 = new Action(async ()=>{
                await rootObject.lemparsMutlaService!.DrinkMutlaAsync(rootObject.playerObject!, rootObject.lemparsMutlaService.mutlas.Count); 
                });
                action3.Invoke();
                break;
                case "timer": 
                Action action4 = new Action(async()=> {
                await rootObject.lemparsMutlaService!.GetMutlaTime(rootObject.playerObject!); 
                });
                action4.Invoke();
                break;
                case "DrinkAdd": rootObject.lemparsMutlaService!.Add(10); break;
                case "DrinkDelete": Console.WriteLine(rootObject.lemparsMutlaService!.DeleteMutla(rootObject.lemparsMutlaService.mutlas.Count)); break;
                case "GetAllMutlas": rootObject.lemparsMutlaService!.GetAllMutlas(); break;
                case "Box":
                    Box.BoxMethod(dic, rootObject.playerObject!); 
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

            if (rootObject.playerObject!.PlayerPosition.SequenceEqual(graph.getVertexIndex(0)) && q == "Home")
            {
                moren.FiflinsShed(rootObject.playerObject!, quest, rootObject.questService!, rootObject.lemparsMutlaService!);
            }
            if(rootObject.playerObject.PlayerPosition.SequenceEqual(graph.getVertexIndex(0)) && q == "TitalinHome")
            {
                moren.TitalinHouse(rootObject.playerObject, PlayerEq!, rootObject.ges!, rootObject.questService!); 
            }
            if(rootObject.playerObject.PlayerPosition.SequenceEqual(graph.getVertexIndex(0)) && q == "MARKS")
            {
                moren.MARKSFight(rootObject.playerObject, moren, rootObject.ges!, PlayerEq!, rootObject.questService!);
            }
            if (rootObject.playerObject.PlayerPosition.SequenceEqual(graph.getVertexIndex(0)) && q == "Chief")
            {
                moren.ChiefHome(rootObject.playerObject, rootObject.questService!);
            } 
            if (rootObject.playerObject.PlayerPosition.SequenceEqual(graph.getVertexIndex(0)) && q == "MorenArmorShop")
            {
                moren.Judaflin(rootObject.playerObject, rootObject.questService, rootObject.lemparsMutlaService, PlayerEq, statistics);
            }

            // I KNOW THAT IT IS A FUCKING CODE REDUNDANCY BUT WHO CARES
            // This section is for the Moren Location movment and invoking things

            if(q == "!enter")
            {
                if (rootObject.playerObject.PlayerPositionMoren.SequenceEqual(graphmoren.getVertexIndex(0)))
                {
                    moren.FiflinsShed(rootObject.playerObject, quest, rootObject.questService!, rootObject.lemparsMutlaService!);
                }
                if (rootObject.playerObject.PlayerPositionMoren.SequenceEqual(graphmoren.getVertexIndex(1)))
                {
                    moren.TitalinHouse(rootObject.playerObject, PlayerEq!, rootObject.ges!, rootObject.questService!);
                }
                if (rootObject.playerObject.PlayerPositionMoren.SequenceEqual(graphmoren.getVertexIndex(2)))
                {
                }
                if (rootObject.playerObject.PlayerPositionMoren.SequenceEqual(graphmoren.getVertexIndex(3)))
                {
                    moren.Judaflin(rootObject.playerObject, rootObject.questService!, rootObject.lemparsMutlaService!, PlayerEq!, statistics);
                }
                if (rootObject.playerObject.PlayerPositionMoren.SequenceEqual(graphmoren.getVertexIndex(4)))
                {
                    moren.ChiefHome(rootObject.playerObject,rootObject.questService!);
                } 
                if (rootObject.playerObject.PlayerPositionMoren.SequenceEqual(graphmoren.getVertexIndex(5)))
                {
                    moren.MARKSFight(rootObject.playerObject, moren, rootObject.ges!, PlayerEq!, rootObject.questService!);
                }
            }
    }
    public RootObject? LoadMng() {
          var contextLoad = AppContext.BaseDirectory;
                    var pathLoad = Path.Combine(contextLoad,"config.json");
                    var loadedObj =  SaveSystemManager.GetInstance.LoadGameProgress(pathLoad);
                    return loadedObj;
    }

}