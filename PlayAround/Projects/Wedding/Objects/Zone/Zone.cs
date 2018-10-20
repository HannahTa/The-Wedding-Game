using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PlayAround
{
    public class Zone
    {
        public int Id;
        public string Name;
        public string Description;
        public int Width;
        public int Height;
        public int TextureID;
        public Object[] Objects;
        public NPC[] NPCs;
        public Exit[] Exits;

        public void SetSources()
        {
            foreach (Object obj in Objects)
            {
                if (obj.source == new Rectangle(0,0,0,0))
                    obj.source = new Rectangle((int)obj.Position.X, (int)obj.Position.Y, SpriteLoader.GetTexture(obj.TextureId).Width, SpriteLoader.GetTexture(obj.TextureId).Height);
            }
            // Exits
            foreach (Exit ext in Exits)
            {
                if (ext.source == new Rectangle(0, 0, 0, 0))
                    ext.source = new Rectangle((int)ext.Position.X, (int)ext.Position.Y, SpriteLoader.GetTexture(ext.TextureId).Width, SpriteLoader.GetTexture(ext.TextureId).Height);
            }
        }

        public void Update(Player player, Camera2D Camera)
        {
            if (player.CheckIfAttackConnected)
            {
                foreach(NPC npc in NPCs)
                {
                    if (Camera.IsInView(npc.Position, SpriteLoader.GetTexture(npc.TextureId)))
                    {
                        if (Collision.CheckCollision(player.GetAttackBox(), new Rectangle((int)npc.Position.X, (int)npc.Position.Y, SpriteLoader.GetTexture(npc.TextureId).Width, SpriteLoader.GetTexture(npc.TextureId).Height)))
                        {
                            // SET NPC Health to whatever!
                            // Handle if below set amount
                            npc.Position = new Vector2(-1000, -1000);
                        }
                    }
                }
                player.CheckIfAttackConnected = false;
            }
            if (player.CheckIfMovementCollision)
            {
                foreach (Object obj in Objects)
                {
                    if (Camera.IsInView(obj.Position, SpriteLoader.GetTexture(obj.TextureId)))
                    {
                        if (Collision.CheckCollision(new Rectangle((int)player.Position.X, (int)player.Position.Y, player.Width, player.Height), obj.source))
                        {
                            // Undo Player movement
                            player.ResetPosition();
                        }
                    }
                }
                player.CheckIfMovementCollision = false;
            }
        }

        public void Draw(SpriteBatch sb, int playerY, Camera2D Camera)
        {
            // Background
            sb.Draw(SpriteLoader.GetTexture(TextureID), new Rectangle(0, 0, Width, Height), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.0f);
            // Objects
            foreach(Object obj in Objects)
            {
                if (Camera.IsInView(obj.Position, SpriteLoader.GetTexture(obj.TextureId)))
                    obj.Draw(sb, playerY);
            }
            // NPCs
            foreach (NPC npc in NPCs)
            {
                if (Camera.IsInView(npc.Position, SpriteLoader.GetTexture(npc.TextureId)))
                    npc.Draw(sb, playerY);
            }
            // Exits
            foreach (Exit ext in Exits)
            {
                if (Camera.IsInView(ext.Position, SpriteLoader.GetTexture(ext.TextureId)))
                    ext.Draw(sb, playerY);
            }
        }
    }
}
