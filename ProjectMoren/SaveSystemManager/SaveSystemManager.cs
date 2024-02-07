using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using GameObjects;

namespace SaveLoadManager;

public sealed class SaveSystemManager {
    private static SaveSystemManager instance = null!;
    private static readonly object lockObj = new(); 
    private SaveSystemManager() {}

    public static SaveSystemManager GetInstance {
        get {
        if(instance is null) {
            lock(lockObj) {
                if(instance is null) {
                    instance = new();
                }
            }
        }
        return instance;
        }
    }

    public async Task SaveGameProgress(string path, RootObject obj){
        using(var fileStream = new FileStream(path, FileMode.Open)){
            await JsonSerializer.SerializeAsync<RootObject>(fileStream,obj,new JsonSerializerOptions(){WriteIndented = true});
        }
    }
    public RootObject LoadGameProgress(string path) {
        using(var fileStream = new FileStream(path,FileMode.Open)) { 
        RootObject? obj = JsonSerializer.Deserialize<RootObject>(fileStream,new JsonSerializerOptions() {PropertyNameCaseInsensitive = true,ReferenceHandler = ReferenceHandler.Preserve});
        return obj!;
        }
    }
    public async Task<RootObject> LoadGameProgressAsync(string path) {
        using(var fileStream = new FileStream(path,FileMode.Open)) { 
        RootObject? obj =  await JsonSerializer.DeserializeAsync<RootObject>(fileStream,new JsonSerializerOptions() {PropertyNameCaseInsensitive = true,ReferenceHandler = ReferenceHandler.Preserve});
        return obj!;
        }
    }
}