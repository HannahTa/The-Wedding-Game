using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using System.IO;

namespace PlayAround
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Camera2D Camera;

        Player _player;
        Zone _zoneOne;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // Make Camera
            Camera = new Camera2D(this);
            Components.Add(Camera);
            // Now Initialize
            base.Initialize();
            // Other
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // Load Sprites
            SpriteLoader.LoadTextures(Content);
            // Populate Objects - BLOCK OF CODE BELOW IS UNIQUE TO EACH JSON FILE
            /// Player
            _player = JsonConvert.DeserializeObject<Player>(File.ReadAllText("JSONs/Player.json"));
            Camera.Focus = _player;
            Components.Add(_player);
            /// Zones (Objects, etc)
            _zoneOne = JsonConvert.DeserializeObject<Zone>(File.ReadAllText("../../../../JSONs/Zone1.json"));
        }

        protected override void UnloadContent()
        {
            // Only be used once. Otherwise pointless method
            Content.Unload();
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                var playerData = JsonConvert.SerializeObject(_player, Formatting.Indented);
                if (File.Exists("JSONs/Player.json")) //File.Exists
                {
                    File.WriteAllText("JSONs/Player.json", playerData);
                }
                Exit();
            }

            //_player.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            _zoneOne.Update(_player, Camera);
            
            base.Update(gameTime);
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Clears last drawn frame
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // Start drawing new frame
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, null, null, null, null, Camera.Transform);
            // Drawing order
            _player.Draw(spriteBatch, Camera);
            _zoneOne.Draw(spriteBatch, (int)_player.Position.Y, Camera);
            // Finishing drawing new frame
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
