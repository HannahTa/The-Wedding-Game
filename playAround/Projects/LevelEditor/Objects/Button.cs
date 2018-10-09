using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LevelEditor.Objects
{
    class Button : GameComponent
    {
        private MouseState _currentMouseState;

        private SpriteFont _font;

        private bool _isHovering;

        private MouseState _previousMoseState;

        private Texture2D _texture;

        public event EventHandler Click;

        public bool Clicked { get; private set; }

        public Color PenColour { get; set;}

        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
            set { }
        }

        public string Text { get; set; }

        public Button(Game game, Texture2D texture, SpriteFont font) : base(game)
        {
            _texture = texture;
            _font = font;
            PenColour = Color.Black;
        }


        public void Draw(SpriteBatch sb, Camera2D camera)
        {
            var colour = Color.White;

            if (_isHovering)
                colour = Color.Gray;

            sb.Draw(_texture, Rectangle, colour);

            if (!string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

                sb.DrawString(_font, Text, new Vector2(x, y), PenColour);
            }
        }

        public void Update(GameTime gameTime, Rectangle windowPos)
        {
            _previousMoseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 1, 1);

            _isHovering = false;
            
            if(mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;

                if(_currentMouseState.LeftButton == ButtonState.Released && _previousMoseState.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
            base.Update(gameTime);
        }

    }
}
