namespace PlayAround
{
    class Quest
    {
        public int QuestType;
        public int QuestTargetType = 1; // Based on quest type will match against Enemy or ItemID
        public int QuestCurrentCount = 0; // Current amount towards completion
        public int QuestCompletionCount = 1; // Amount needed to complete quest
    }
}
