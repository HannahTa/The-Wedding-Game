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
    class Sprite : SpriteComponent
    {
        public EventHandler[] events;

        public Sprite(Game game, Rectangle collisionBox, Texture2D texture, int textureID) : base(game, collisionBox, texture, textureID)
        {
            events = new EventHandler[3];
            events[0] += Sprite_Click;
            events[1] += Sprite_Hold;
            events[2] += Sprite_RightClick;
            Sequence = 0;
        }

        public override void Update(GameTime gameTime, Rectangle windowPos, Camera2D cam)
        {
            _previousMoseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
            var mouseRectangle = new Rectangle(_currentMouseState.X + (int)cam.Pos.X, _currentMouseState.Y + (int)cam.Pos.Y, 10, 10);

            _isHovering = false;

            if (mouseRectangle.Intersects(CollisionBox))
            {
                _isHovering = true;

                if (_currentMouseState.LeftButton == ButtonState.Released && _previousMoseState.LeftButton == ButtonState.Pressed)
                {
                    if(!IsNew)
                        events[0]?.Invoke(this, new EventArgs());
                }

                if(_currentMouseState.LeftButton == ButtonState.Pressed && _previousMoseState.LeftButton == ButtonState.Pressed)
                {
                    events[1]?.Invoke(this, new EventArgs());
                }

                if (_currentMouseState.RightButton == ButtonState.Released && _previousMoseState.RightButton == ButtonState.Pressed)
                {
                    events[2]?.Invoke(this, new EventArgs());
                }
            }

            if (_currentMouseState.LeftButton == ButtonState.Released && _previousMoseState.LeftButton == ButtonState.Released && (IsHold || IsNew))
            {
                if (IsHold)
                    IsHold = false;
                else if (IsNew)
                    IsNew = false;
            }
        }

        private void Sprite_Click(object sender, EventArgs e)
        {
            if (Selected)
            {
                Selected = false;
                SpriteColor = Color.White;
            }
            else
            {
                Selected = true;
                SpriteColor = Color.Purple;
            }
        }

        private void Sprite_RightClick(object sender, EventArgs e)
        {
            if(Selected)
                Delete = true;
        }

        private void Sprite_Hold(object sender, EventArgs e)
        {
            if (Selected)
            {
                var deltaX = _currentMouseState.X - _previousMoseState.X;
                var deltaY = _currentMouseState.Y - _previousMoseState.Y;
                CollisionBox = new Rectangle(CollisionBox.X + deltaX, CollisionBox.Y + deltaY, CollisionBox.Width, CollisionBox.Height);
                IsHold = true;
            }
        }
    }
}
