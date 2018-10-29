using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace PlayAround
{
    public static class QuickBar
    {
        public static List<Item> items = new List<Item>();
        public static int selectedPos = 1;
        private static int X;
        private static readonly int Y = 400;
        private static readonly int size = 50;
        private static readonly int dist = 5;

        public static void AddItem(int ItemType)
        {
            //switch (ItemType)
            items.Add(new BlueSword(105, Y + 5));
            // Item X & Y determined by position in Inventory
        }

        public static void SelectItem(int pos)
        {
            selectedPos = pos;
        }

        public static void Draw(SpriteBatch sb, Camera2D camera)
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
