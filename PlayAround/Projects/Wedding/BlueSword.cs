using System;
using Microsoft.Xna.Framework.Graphics;

namespace PlayAround
{
    class BlueSword : Item
    {
        public BlueSword(int x, int y)
        {
            X = x;
            Y = y;
            TextureId = 6;
            // Set size
            Texture2D texture = SpriteLoader.GetTexture(TextureId);
            if (texture.Width < Width)
            {
                X += Math.Abs(Width - texture.Width) / 2;
                Width = texture.Width;
            }
        }
    }
}
