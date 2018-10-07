using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LevelEditor
{
    class Sprite : GameComponent
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle CollisionBox { get; set; }
        public int TextureID { get; set; }
        public bool Delete { get; set; }
        public bool Selected { get; set; }

        public Sprite(Game game, Vector2 position, Rectangle collisionBox, Texture2D texture, int textureID) : base(game)
        {
            Position = position;
            Texture = texture;
            TextureID = textureID;
            CollisionBox = collisionBox;
            Delete = false;
        }
    }
}
