using System.Collections.Generic;

namespace PlayAround
{
    class QuestTracker
    {
        public static List<Quest> ActiveQuests = new List<Quest>();
        public static List<Quest> CompletedQuests = new List<Quest>();
        public static List<Quest> IncompletedQuests = new List<Quest>();

        public static void CheckQuestCriteria(int enemyID = 0, int itemID = 0)
        {
            foreach(Quest quest in ActiveQuests)
            {
                switch(quest.QuestType)
                {
                    // Kill quest
                    case 1:
                        if (quest.QuestTargetType == enemyID) quest.QuestCurrentCount++;
                        break;
                    // Collection quest
                    case 2:
                        if (quest.QuestTargetType == itemID) quest.QuestCurrentCount++;
                        break;
                }
                // Complete quest if criteria done! Need to add a "Rewards" part here
                if (quest.QuestCurrentCount >= quest.QuestCompletionCount)
                {
                    CompletedQuests.Add(quest);
                    ActiveQuests.Remove(quest);
                }
            }
        }
    }
}
