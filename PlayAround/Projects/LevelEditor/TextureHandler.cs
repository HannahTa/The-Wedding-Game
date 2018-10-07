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

namespace LevelEditor
{
    class TextureHandler : GameComponent
    {
        private Dictionary<int, Texture2D> textures;
        private int textureMax;
        private int currentTexture;
        private int previousScrollValue;
        System.IO.DirectoryInfo dir;

        public TextureHandler(Game game) : base(game)
        {
            Texture[] json = JsonConvert.DeserializeObject<Texture[]>(File.ReadAllText("Content/JSON/Texture.json"));
            dir = new System.IO.DirectoryInfo("Content");
            textures = new Dictionary<int, Texture2D>();
            textureMax = json.Length;
            foreach (Texture tex in json)
            {
                textures.Add(tex.Id, Game.Content.Load<Texture2D>(tex.ImageName));
            }
            currentTexture = 1;
        }

        public Texture2D GetTexture()
        {
            return textures[currentTexture];
        }

        public int GetTextureID()
        {
            return currentTexture;
        }

        public override void Update(GameTime gameTime)
        {
            MouseState state = Mouse.GetState();
            if (previousScrollValue > state.ScrollWheelValue)
            {
                currentTexture++;
            }
            else if (previousScrollValue < state.ScrollWheelValue)
            {
                currentTexture--;
            }

            if (currentTexture >= textureMax)
            {
                currentTexture = textureMax - 1;
            }
            else if (currentTexture < 1)
            {
                currentTexture = 1;
            }

            previousScrollValue = state.ScrollWheelValue;
            base.Update(gameTime);
        }
    }
}
