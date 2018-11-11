using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;
using LevelEditor.Objects;

namespace LevelEditor
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle windowPos;
        List<SpriteComponent> blocks;
        Camera2D cam;
        private Dictionary<int, Texture2D> textures;
        DirectoryInfo dir;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true; // Might come in handy for you!

            cam = new Camera2D(this)
            {
                Pos = new Vector2(0.0f, 0.0f)
            };
        }

        protected override void Initialize()
        {
            blocks = new List<SpriteComponent>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture[] json = JsonConvert.DeserializeObject<Texture[]>(File.ReadAllText("Content/JSONs/Texture.json"));
            dir = new System.IO.DirectoryInfo("Content");
            textures = new Dictionary<int, Texture2D>();
            foreach (Texture tex in json)
            {
                textures.Add(tex.Id, Content.Load<Texture2D>(tex.ImageName));
            }

            blocks.Add(new Cursor(this, new Rectangle(250, 250, textures[1].Width, textures[1].Height), textures[1], 1, textures, Add_Click));
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            windowPos = new Rectangle((int)(GraphicsDevice.Viewport.X), (int)(GraphicsDevice.Viewport.Y), GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            cam.Update(gameTime);

            foreach(var component in blocks.ToArray())
            {
                component.Update(gameTime, windowPos, cam);
            }

            if (blocks.FindAll(x => x.Delete).Count > 10 || blocks.FindAll(x => x.Delete).Count == blocks.Count - 1)
                blocks.RemoveAll(x => x.Delete);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // Changed from Immeditate to BackToFront so Z value is relevant. I got ya back homie <3
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, cam.get_transformation(GraphicsDevice));
            foreach (var block in blocks)
            {
                block.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Add_Click(object sender, EventArgs e)
        {
            bool overBlock = false;
            Cursor cursor = blocks.OfType<Cursor>().First();
            for (int i = 0; i < blocks.Count; i++)
            {
                if (cursor.CollisionBox.Intersects(blocks[i].CollisionBox) && blocks[i].GetType() != typeof(Cursor))
                {
                    overBlock = true;
                }
            }

            if (!overBlock)
            {
                /*** Once I figure out the math here I will re-enable snap mode ***/
                int tileX = (int)((float)(cursor.CollisionBox.X) / cursor.Textures[cursor.TextureID].Width) * cursor.Textures[cursor.TextureID].Width;
                int tileY = (int)((float)(cursor.CollisionBox.Y) / cursor.Textures[cursor.TextureID].Height) * cursor.Textures[cursor.TextureID].Height;
                blocks.Add(new Sprite(this, new Rectangle(tileX, tileY, cursor.Textures[cursor.TextureID].Width, cursor.Textures[cursor.TextureID].Height), cursor.Textures[cursor.TextureID], cursor.TextureID));
                blocks = blocks.OrderBy(x => x.Sequence).ToList();
            }
        }
    }
}
