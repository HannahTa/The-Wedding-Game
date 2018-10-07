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
        Rectangle windowPos;
        List<Sprite> blocks;
        Camera2D cam;
        TextureHandler textureHandler;
        ActionHandler actionHandler;
        bool WasHold;
        int SelectedId;

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
            actionHandler = new ActionHandler(this);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        public void HandleAction()
        {
            bool withinWindow = actionHandler.CheckMouse(windowPos, cam);

            if (actionHandler.CurrentKeyboardState.IsKeyDown(Keys.E))
            {
                //TODO: add JSON handling here, The current implementation is for testing.
                string JSONString = "";
                foreach (var item in blocks)
                {
                    JSONTexture tex = new JSONTexture
                    {
                        TextureId = item.TextureID,
                        Position = item.Position.X.ToString() + ", " + item.Position.Y.ToString(),
                        Height = item.Texture.Height,
                        Width = item.Texture.Width
                    };
                    JSONString = JSONString + JsonConvert.SerializeObject(tex);
                }
                if (!File.Exists("Content/JSON/test.json"))
                {
                    using (var sw = new StreamWriter("Content/JSON/test.json", true))
                    {
                        sw.WriteLine(JSONString);
                        sw.Close();
                    }
                }
            }

            //Mouse Actions
            if(actionHandler.CurrentMouseState.RightButton == ButtonState.Pressed)
            {
                for (var i = 0; i < blocks.Count; i++)
                {
                    if (actionHandler.CheckMouse(blocks[i].CollisionBox, cam))
                    {
                        blocks[i].Delete = true;
                    }
                }
                blocks.RemoveAll(x => x.Delete);
            }
            else if (actionHandler.HeldDown)
            {
                for (var i = 0; i < blocks.Count; i++)
                {
                    if (actionHandler.CheckMouse(blocks[i].CollisionBox, cam) && i == SelectedId)
                    {
                        var deltaX = actionHandler.CurrentMouseState.X - actionHandler.PreviousMouseState.X;
                        var deltaY = actionHandler.CurrentMouseState.Y - actionHandler.PreviousMouseState.Y;
                        blocks[i].CollisionBox = new Rectangle(blocks[i].CollisionBox.X + deltaX, blocks[i].CollisionBox.Y + deltaY, blocks[i].CollisionBox.Width, blocks[i].CollisionBox.Height);
                    }
                }
            }
            else if (actionHandler.CurrentMouseState.LeftButton == ButtonState.Pressed && !actionHandler.HeldDown)
            {
                if (actionHandler.CheckMouse(windowPos, cam) && !WasHold)
                {
                    bool blockSelected = false;
                    for (var i = 0; i < blocks.Count; i++)
                    {
                        if (actionHandler.CheckMouse(blocks[i].CollisionBox, cam))
                        {
                            if (SelectedId == i)
                                SelectedId = -1;
                            else
                                SelectedId = i;
                            
                            blockSelected = true;
                        }
                    }
                    if (!blockSelected)
                    {
                        int tileX = (int)((float)(position.X) / textureHandler.GetTexture().Width) * textureHandler.GetTexture().Width;
                        int tileY = (int)((float)(position.Y) / textureHandler.GetTexture().Height) * textureHandler.GetTexture().Height;
                        blocks.Add(new Sprite(this, new Vector2(tileX, tileY), new Rectangle(tileX, tileY, textureHandler.GetTexture().Width, textureHandler.GetTexture().Height), textureHandler.GetTexture(), textureHandler.GetTextureID()));
                    }
                }
                WasHold = false;
            }

        }

        protected override void Update(GameTime gameTime)
        {

            windowPos = new Rectangle((int)(GraphicsDevice.Viewport.X + cam.Pos.X), (int)(GraphicsDevice.Viewport.Y + cam.Pos.Y), GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            cam.Update(gameTime);
            position.X = actionHandler.CurrentMouseState.X + cam.Pos.X;
            position.Y = actionHandler.CurrentMouseState.Y + cam.Pos.Y;
            textureHandler.Update(gameTime);
            actionHandler.Update(gameTime);
            HandleAction();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, cam.get_transformation(GraphicsDevice));
            for (var i = 0; i < blocks.Count; i++)
            {
                if (!blocks[i].Delete)
                {
                    var color = Color.White;
                    if (i == SelectedId)
                        color = Color.Violet;

                    spriteBatch.Draw(blocks[i].Texture, blocks[i].CollisionBox, null, color, 0, Vector2.Zero, SpriteEffects.None, 0);
                }
            }
            spriteBatch.Draw(textureHandler.GetTexture(), new Rectangle((int)position.X, (int)position.Y, textureHandler.GetTexture().Width, textureHandler.GetTexture().Height), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
