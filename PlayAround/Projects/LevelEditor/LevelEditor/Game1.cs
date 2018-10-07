using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;

namespace LevelEditor
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 position;
        List<Sprite> blocks;
        Camera2D cam;
        TextureHandler textureHandler;
        MouseState prev, curr;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            cam = new Camera2D(this)
            {
                Pos = new Vector2(0.0f, 0.0f)
            };
        }

        protected override void Initialize()
        {
            position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2);
            blocks = new List<Sprite>();
            textureHandler = new TextureHandler(this);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        public bool CheckMouse(Vector2 block, Vector2 mouse, int width, int height)
        {
            if (mouse.X < block.X + width &&
                mouse.X > block.X &&
                mouse.Y < block.Y + height &&
                mouse.Y > block.Y)
                return true;
            else
                return false;
        }

        protected override void Update(GameTime gameTime)
        {
            prev = curr;
            curr = Mouse.GetState();
            KeyboardState keyState = Keyboard.GetState();
            Vector2 windowPos = new Vector2(GraphicsDevice.Viewport.X + cam.Pos.X, GraphicsDevice.Viewport.Y + cam.Pos.Y);
            cam.Update(gameTime);
            textureHandler.Update(gameTime);

            position.X = curr.X + cam.Pos.X;
            position.Y = curr.Y + cam.Pos.Y;

            bool withinWindow = CheckMouse(windowPos, position, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            if(keyState.IsKeyDown(Keys.E))
            {
                string JSONString = "";
                foreach(var item in blocks)
                {
                    JSONTexture tex = new JSONTexture();
                    tex.TextureId = item.TextureID;
                    tex.Position = item.Position.X.ToString() + ", " + item.Position.Y.ToString();
                    tex.Height = item.Texture.Height;
                    tex.Width = item.Texture.Width;
                    JSONString = JSONString + JsonConvert.SerializeObject(tex);
                }
                if(!File.Exists("Content/JSON/test.json"))
                {
                    using (var sw = new StreamWriter("Content/JSON/test.json", true))
                    {
                        sw.WriteLine(JSONString);
                        sw.Close();
                    }
                }
            }
            if (curr.RightButton == ButtonState.Pressed)
            {
                for (var i = 0; i < blocks.Count; i++)
                {
                    if (CheckMouse(blocks[i].Position, position, blocks[i].Texture.Width, blocks[i].Texture.Height))
                    {
                        blocks[i].Delete = true;
                    }
                }
                blocks.RemoveAll(x => x.Delete);
            }
            else if (curr.LeftButton == ButtonState.Released && prev.LeftButton == ButtonState.Pressed)
            {
                if (withinWindow)
                {
                    int tileX = (int)((float)(position.X) / textureHandler.GetTexture().Width);
                    int tileY = (int)((float)(position.Y) / textureHandler.GetTexture().Height);
                    blocks.Add(new Sprite(this, new Vector2(tileX * textureHandler.GetTexture().Width, tileY * textureHandler.GetTexture().Height), textureHandler.GetTexture(), textureHandler.GetTextureID(), textureHandler.GetTexture().Width, textureHandler.GetTexture().Height));
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, cam.get_transformation(GraphicsDevice));
            foreach (var item in blocks)
            {
                if (!item.Delete)
                {
                    spriteBatch.Draw(item.Texture, new Rectangle((int)item.Position.X, (int)item.Position.Y, item.Texture.Width, item.Texture.Height), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                }
            }
            spriteBatch.Draw(textureHandler.GetTexture(), new Rectangle((int)position.X, (int)position.Y, textureHandler.GetTexture().Width, textureHandler.GetTexture().Height), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
