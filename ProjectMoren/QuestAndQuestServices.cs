using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjectMoren
{
    public class Quest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id}. {Name}";
        }
    }
    public class QuestServices : Quest
    {
        public QuestServices()
        {

        }

        [JsonConstructor]
        public QuestServices(List<Quest> quests)
        {
            _quests = quests;
        }

        public List<Quest> _quests { get; set; } = new List<Quest>(); 

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

} 
