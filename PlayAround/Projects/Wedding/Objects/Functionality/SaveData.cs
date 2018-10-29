using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace PlayAround
{
    class SaveData
    {
        public Vector2 PlayerPosition { get; set; }
        public int PlayerWidth { get; set; }
        public int PlayerHeight { get; set; }

        public List<Quest> ActiveQuests { get; set; }
        public List<Quest> CompletedQuests { get; set; }
        public List<Quest> IncompletedQuests { get; set; }

        public List<Item> QuickBar { get; set; }
        public List<Item> Inventory { get; set; }
    }
}
