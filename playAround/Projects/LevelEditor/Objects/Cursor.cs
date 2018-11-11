using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using System.IO;

namespace LevelEditor.Objects
{
    class Cursor : SpriteComponent
    {
        public Dictionary<int, Texture2D> Textures;
        private int textureMax;
        private int previousScrollValue;
        private int previousTextureValue;
        public EventHandler Add { get; set; }
        System.IO.DirectoryInfo dir;

        public Cursor(Game game, Rectangle collisionBox, Texture2D texture, int textureID, Dictionary<int, Texture2D> textures, EventHandler add) : base(game, collisionBox, texture, textureID)
        {
            Texture[] json = JsonConvert.DeserializeObject<Texture[]>(File.ReadAllText("Content/JSONs/Texture.json"));
            dir = new System.IO.DirectoryInfo("Content");
            textureMax = json.Length;
            Textures = textures;
            TextureID = 1;
            Add += add;
            Sequence = 999;
        }

        public override void Update(GameTime gameTime, Rectangle windowPos, Camera2D cam)
        {
            base.Update(gameTime, windowPos, cam);
            Texture = Textures[TextureID];

            if (previousScrollValue > _currentMouseState.ScrollWheelValue)
            {
                TextureID++;
            }
            else if (previousScrollValue < _currentMouseState.ScrollWheelValue)
            {
                TextureID--;
            }

            if (TextureID >= textureMax)
            {
                TextureID = textureMax - 1;
            }
            else if (TextureID < 1)
            {
                TextureID = 1;
            }
            if (CheckMouse(windowPos))
            {
                if (_currentMouseState.LeftButton == ButtonState.Released && _previousMoseState.LeftButton == ButtonState.Pressed)
                    Add?.Invoke(this, new EventArgs());
            }


            previousScrollValue = _currentMouseState.ScrollWheelValue;
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(Textures[TextureID], new Rectangle(CollisionBox.X, CollisionBox.Y, Texture.Width, Texture.Height), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
        }

        public bool CheckMouse(Rectangle windowPos)
        {
            var mouseRectangle = new Rectangle((int)(_currentMouseState.X), (int)(_currentMouseState.Y), 1, 1);

            if (mouseRectangle.Intersects(windowPos))
                return true;
            else
                return false;
        }
    }
}
