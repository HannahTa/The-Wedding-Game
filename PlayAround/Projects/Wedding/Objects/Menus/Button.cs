using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PlayAround
{
    class Button
    {
        private readonly int TextureId = 999;
        private int XFrame = 0;
        public int YFrame = 0;
        private readonly int Height = 29;
        private readonly int Width = 175;
        // Positioning
        public Rectangle source;

        public Button(int xframe, int x, int y)
        {
            XFrame = xframe;
            source = new Rectangle(x, y, Width, Height);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(SpriteLoader.GetTexture(TextureId), source, new Rectangle(Width * XFrame, Height * YFrame, Width, Height), Color.CornflowerBlue, 0, Vector2.Zero, SpriteEffects.None, 1.0f);
        }
    }
}
