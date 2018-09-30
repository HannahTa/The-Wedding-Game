using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace PlayAround
{
    public class Player : GameComponent, IFocusable
    {
        // Position?
        public Vector2 Position { get; set; }
        // Settings
        public string Name;
        public int TextureId;
        private readonly QuickBar quickBar = new QuickBar();
        private readonly Inventory inventory = new Inventory();
        // Combat Properties
        private Rectangle attackBox;
        public bool CheckIfAttackConnected = false;
        public enum Directions
        {
            UP = 1,
            RIGHT = 2,
            DOWN = 3,
            LEFT = 4
        };
        public Directions direction;
        // Animation Properties
        public int Width;
        public int Height;
        private int frame;
        private int frameRow = 0;
        private float elapsedTime;
        private float frameDelay = 0.5f;
        // Movement Properties
        private readonly float WalkSpeed = 150;
        private readonly float RunSpeed = 200;

        public Player(Game game) : base(game)
        {
            TextureId = 1;
            // Added below for testing purposes
            quickBar.AddItem(1);
            inventory.AddItem(1);
        }

        public override void Update(GameTime gameTime)
        {
            float X = Position.X;
            float Y = Position.Y;
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            // Handle Movement
            float speed = WalkSpeed;
            var keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.LeftShift)) speed = RunSpeed;
            if (keyState.IsKeyDown(Keys.W))
            {
                Y -= (speed * delta);
                direction = Directions.UP;
            }
            if (keyState.IsKeyDown(Keys.D))
            {
                X += (speed * delta);
                direction = Directions.RIGHT;
            }
            if (keyState.IsKeyDown(Keys.S))
            {
                Y += (speed * delta);
                direction = Directions.DOWN;
            }
            if (keyState.IsKeyDown(Keys.A))
            {
                X -= (speed * delta);
                direction = Directions.LEFT;
            }
            inventory.Update();
            // Combat
            var mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                // Will eventually need to be a method in QuickBar to get Item properties
                switch (direction)
                {
                    case Directions.UP:
                        // Top Left, Top Right, Width, Height
                        /// Assume magic properties below are coming from an Item stored in QB

                        // X
                        // Y - Item Length
                        // Player Width (?)
                        // Item Length
                        attackBox = new Rectangle((int)X, (int)Y - 50, Width, 50);
                        break;
                    case Directions.RIGHT:
                        attackBox = new Rectangle((int)X + Width, (int)Y, 50, Height);
                        break;
                    case Directions.DOWN:
                        attackBox = new Rectangle((int)X, (int)Y + Height, Width, 50);
                        break;
                    case Directions.LEFT:
                        attackBox = new Rectangle((int)X - 50, (int)Y, 50, Height);
                        break;
                }
                // Alert Zone to check if colliding with NPCs
                CheckIfAttackConnected = true;
                // Change frame row (for animation)
            }
            else
            {
                attackBox = new Rectangle(); // For visual aid, remove in future
            }
            // Handle Animations
            elapsedTime += delta;
            if (elapsedTime >= frameDelay)
            {
                if (frame >= 3) frame = 0;
                else frame++;
                elapsedTime = 0;
            }
            // Update new position
            Position = new Vector2(X, Y);
            base.Update(gameTime);// ?? It this alright
        }

        public void Draw(SpriteBatch sb, Camera2D camera)
        {
            Texture2D texture = SpriteLoader.GetTexture(TextureId);
            sb.Draw(texture, new Rectangle((int)Position.X, (int)Position.Y, Width, Height), new Rectangle(Width * frame, Height * frameRow, Width, Height), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.5f);
            sb.Draw(texture, attackBox, new Rectangle(Width, Height, Width, Height), Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.5f); // Debugging purposes
            quickBar.Draw(sb, camera);
            inventory.Draw(sb, camera);
        }

        public Rectangle GetAttackBox()
        {
            return attackBox;
        }
    }
}
