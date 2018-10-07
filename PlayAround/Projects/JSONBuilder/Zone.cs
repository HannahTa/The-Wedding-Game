namespace JSONBuilder
{
    public class Zone
    {
        public int Id;
        public string Name;
        public string Description;
        public int Width;
        public int Height;
        public int TextureID;
        public NPC[] NPCs;
        public Object[] Objects;
        public Exit[] Exits;

        public NPC GetNPC(string id, string name)
        {
            foreach(NPC npc in NPCs)
            {
                if (npc.Id.ToString().Equals(id) && npc.Name.Equals(name))
                    return npc;
            }
            return null;
        }

        public Object GetObject(string id, string name)
        {
            foreach (Object obj in Objects)
            {
                if (obj.Id.ToString().Equals(id) && obj.Name.Equals(name))
                    return obj;
            }
            return null;
        }

        public Exit GetExit(string id, string name)
        {
            foreach (Exit exit in Exits)
            {
                if (exit.Id.ToString().Equals(id) && exit.Name.Equals(name))
                    return exit;
            }
            return null;
        }
    }

    public class Object
    {
        public int Id;
        public string Name;
        public int TextureId;
        public string Position;
        //public Vector2 Position;
    }

    public class NPC
    {
        public int Id;
        public string Name;
        public int TextureId;
        public string Position;
        //public Vector2 Position;
        public string DefaultDialogue;
    }

    public class Exit
    {
        public int Id;
        public int ZoneId;
        public string Name;
        public int TextureId;
        public string Position;
        //public Vector2 Position;
    }
}
