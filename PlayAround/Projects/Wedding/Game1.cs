using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using System.IO;

namespace PlayAround
{
    public class Game1 : Game
    {
        // Window Stuff
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        // State Handling
        enum GameStates
        {
            MAINMENU = 1,
            GAME = 2
        }
        GameStates GameState = GameStates.MAINMENU;
        // Menus
        MainMenu menu = new MainMenu();
        // Game Objects
        Player _player;
        Zone _zoneOne;
        Camera2D Camera;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
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
        }

        private void LoadInGame()
        {
            // Window Updates
            // Make Camera
            Camera = new Camera2D(this);
            Components.Add(Camera);
            // Hide Mouse
            IsMouseVisible = false;
            // In-Game Updates
            // Populate Objects - BLOCK OF CODE BELOW IS UNIQUE TO EACH JSON FILE
            // Player
            _player = JsonConvert.DeserializeObject<Player>(File.ReadAllText("Content/JSONs/Player.json"));
            Camera.Focus = _player;
            Components.Add(_player);
            // Zones (Objects, etc)
            _zoneOne = JsonConvert.DeserializeObject<Zone>(File.ReadAllText("Content/JSONs/Zone1.json"));
            // Update State
            GameState = GameStates.GAME;
        }

        protected override void UnloadContent()
        {
            // Only be used once. Otherwise pointless method
            Content.Unload();
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            switch (GameState)
            { 
                case GameStates.MAINMENU:
                    MainMenuUpdate();
                    break;
                case GameStates.GAME:
                    InGameUpdate(gameTime);
                    break;
            }
            base.Update(gameTime);
        }

        private void MainMenuUpdate()
        {
            int action = menu.Update();
            switch(action)
            {
                case 1:
                    // New Game
                    break;
                case 2:
                    LoadInGame();
                    break;
                case 3:
                    // Options
                    break;
                case 4:
                    Exit();
                    break;
            }
        }

        private void InGameUpdate(GameTime gameTime)
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
            _zoneOne.Update(_player, Camera);
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Clears last drawn frame
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // Start drawing new frame. Switch based on State
            switch(GameState)
            {
                case GameStates.MAINMENU:
                    spriteBatch.Begin();
                    menu.Draw(spriteBatch);
                    break;
                case GameStates.GAME:
                    spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, null, null, null, null, Camera.Transform);
                    _player.Draw(spriteBatch, Camera);
                    _zoneOne.Draw(spriteBatch, (int)_player.Position.Y, Camera);
                    break;
            }
            // Finishing drawing new frame
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
