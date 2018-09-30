using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PlayAround
{
    public class BaseDraw
    {
        public Vector2 Position;
        public int TextureId;

        public virtual void Draw(SpriteBatch sb, int playerY)
        {
            float Z;
            float diff = Math.Abs(playerY - Position.Y) /1000;
            // Above player
            if (Position.Y <= playerY) Z = (0.5f - diff);
            // Below player
            else Z = Z = (0.5f + diff);
            Texture2D texture = SpriteLoader.GetTexture(TextureId);
            //sb.Draw(texture, new Rectangle(X, Y, texture.Width, texture.Height), Color.White);
            sb.Draw(texture, new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, Z);
        }
    }
}
