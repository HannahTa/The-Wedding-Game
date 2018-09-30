using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PlayAround
{
    public class Item
    {
        public int X;
        public int Y;
        public int TextureId;
        public int Width = 40;
        private readonly int Height = 40;

        public virtual void Draw(SpriteBatch sb, Camera2D camera)
        {
            Texture2D texture = SpriteLoader.GetTexture(TextureId);
            sb.Draw(texture, camera.ScreenToWorld(new Rectangle(X, Y, Width, Height)), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1.0f);
        }
    }
}
