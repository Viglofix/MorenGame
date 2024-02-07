using System.Text.Json.Serialization;
using GameObjects.BasicGameMechanisms;
using ProjectMoren.FirstMap.MorenLocation;
using ProjectMoren.FirstMap.MorenLocation.Enemies;

namespace GameObjects;

public class RootObject {
    public RootObject()
    {
        playerObject = new();
        moren = new();
        ges = new();
        questService = new();
        lemparsMutlaService = new();
    }
    [JsonConstructor]
    public RootObject(PlayerObject? playerObject, Moren? moren, Ges? ges,QuestService? questService,LemparsMutlaService? lemparsMutlaService) {
        this.playerObject = playerObject;
        this.moren = moren;
        this.ges = ges;
        this.questService = questService;
        this.lemparsMutlaService = lemparsMutlaService;
    }
    public PlayerObject? playerObject {get;set;}
    public Moren? moren {get;set;}
    public Ges? ges {get;set;}
    public QuestService? questService {get;set;}
    public LemparsMutlaService? lemparsMutlaService {get;set;}
}