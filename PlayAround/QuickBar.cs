using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace PlayAround
{
    public class QuickBar
    {
        private List<Item> items = new List<Item>();
        private int selectedPos = 1;
        private int X;
        private readonly int Y = 400;
        private readonly int size = 50;
        private readonly int dist = 5;

        public void AddItem(int ItemType)
        {
            //switch (ItemType)
            items.Add(new BlueSword(105, Y + 5));
            // Item X & Y determined by position in Inventory
        }

        public void SelectItem(int pos)
        {
            selectedPos = pos;
        }

        public void Draw(SpriteBatch sb, Camera2D camera)
        {
            for (int i = 0; i < 10; i++)
            {
                X = 100 + ((i * size) + (i*dist));
                // Draw Quickbar
                Texture2D texture = SpriteLoader.GetTexture(7);
                sb.Draw(texture, camera.ScreenToWorld(new Rectangle(X, Y, size, size)), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1.0f);
                // Draw Item
                if (i < items.Count) items[i].Draw(sb, camera);
            }
        }
    }
}
