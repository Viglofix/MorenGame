using Newtonsoft.Json;

namespace GameObjects.BasicGameMechanisms;
    public class QuestService
    {
        public QuestService()
        {
           _quests = new();
        }

        [JsonConstructor]
        public QuestService(List<Quest> quests)
        {
            _quests = quests;
        }

        public List<Quest> _quests { get; set; }  

        public void AddQuest(string QuestDesctiption)
        {
            var newQuest = new Quest() { Id = GetLastId() + 1, Name = QuestDesctiption };
            _quests.Add(newQuest);
        }

        private int GetLastId()
        {
            if(_quests.Count ==0)
            {
                return 0;
            }

            return _quests[_quests.Count - 1].Id;
        }
        public Quest UpdateQuest(Quest quest)
        {
            return quest;
        }

        public bool DeleteQuest(int id)
        {
            var quest = GetQuestById(id);
            if(quest is null)
            {
                return false;
            }

            _quests.Remove(quest);
            return true;
        }

        public Quest? GetQuestById(int id)
        {
            foreach(var item in _quests)
            {
                if(item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public void GetAllQuests()
        {
            foreach(var item in _quests)
            {
                Console.WriteLine(item.Id + ": " + item.Name);
            }
        }
        public Quest? GetQuestByName(string name)
        {
            foreach(var item in _quests)
            {
                if(item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }
    }