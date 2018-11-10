using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevelEditor.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LevelEditor
{
    class Sprite : SpriteComponent
    {
        public EventHandler[] events;
        public List<Widget> widgets;

        public Sprite(Game game, Rectangle collisionBox, Texture2D texture, int textureID) : base(game, collisionBox, texture, textureID)
        {
            events = new EventHandler[4];
            events[0] += Sprite_Click;
            events[1] += Sprite_Hold;
            events[2] += Sprite_RightClick;
            events[3] += Sprite_Scale;

            Sequence = 0;

            widgets = new List<Widget>
            {
                new Widget(game, new Rectangle(collisionBox.X - 8, collisionBox.Y - 8, 16, 16), Game.Content.Load<Texture2D>("editor/CornerWidget"), textureID, 1),
                new Widget(game, new Rectangle(collisionBox.X - 8 + collisionBox.Width, collisionBox.Y - 8, 16, 16), Game.Content.Load<Texture2D>("editor/CornerWidget"), textureID, 1),
                new Widget(game, new Rectangle(collisionBox.X - 8, collisionBox.Y + collisionBox.Height - 8, 16, 16), Game.Content.Load<Texture2D>("editor/CornerWidget"), textureID, 1),
                new Widget(game, new Rectangle(collisionBox.X + collisionBox.Width - 8, collisionBox.Y + collisionBox.Height - 8, 16, 16), Game.Content.Load<Texture2D>("editor/CornerWidget"), textureID, 1),
                new Widget(game, new Rectangle(collisionBox.X + (collisionBox.Width/2) - 8, collisionBox.Y + (collisionBox.Height/2) - 8, 16, 16), Game.Content.Load<Texture2D>("editor/CentreWidget"), textureID, 2)
            };
        }

        public override void Update(GameTime gameTime, Rectangle windowPos, Camera2D cam)
        {
            _previousMoseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
            var mouseRectangle = new Rectangle(_currentMouseState.X + (int)cam.Pos.X, _currentMouseState.Y + (int)cam.Pos.Y, 10, 10);

            _isHovering = false;

            foreach (var widg in widgets)
            {
                if(mouseRectangle.Intersects(widg.CollisionBox))
                {
                    widg.Selected = true;
                } else
                {
                    widg.Selected = false;
                }
            }

            if (mouseRectangle.Intersects(widgets[0].CollisionBox) || mouseRectangle.Intersects(widgets[1].CollisionBox) || mouseRectangle.Intersects(widgets[2].CollisionBox) || mouseRectangle.Intersects(widgets[3].CollisionBox))
            {
                if (_currentMouseState.LeftButton == ButtonState.Pressed && _previousMoseState.LeftButton == ButtonState.Pressed)
                {
                    events[3]?.Invoke(this, new EventArgs());
                }
            } else if(mouseRectangle.Intersects(widgets[4].CollisionBox)) {
                if (_currentMouseState.LeftButton == ButtonState.Pressed && _previousMoseState.LeftButton == ButtonState.Pressed)
                {
                    events[1]?.Invoke(this, new EventArgs());
                }
            } else if (mouseRectangle.Intersects(CollisionBox)) {
                _isHovering = true;

                if (_currentMouseState.LeftButton == ButtonState.Released && _previousMoseState.LeftButton == ButtonState.Pressed)
                {
                    if (!IsNew)
                        events[0]?.Invoke(this, new EventArgs());
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

            WidgetUpdate();
        }

        public void WidgetUpdate()
        {
            widgets[0].CollisionBox = new Rectangle(widgets[2].CollisionBox.X, widgets[1].CollisionBox.Y, 16, 16);
            widgets[1].CollisionBox = new Rectangle(widgets[3].CollisionBox.X, widgets[0].CollisionBox.Y, 16, 16);
            widgets[2].CollisionBox = new Rectangle(widgets[0].CollisionBox.X, widgets[3].CollisionBox.Y, 16, 16);
            widgets[3].CollisionBox = new Rectangle(widgets[1].CollisionBox.X, widgets[2].CollisionBox.Y, 16, 16);
            widgets[4].CollisionBox = new Rectangle((widgets[0].CollisionBox.X + widgets[1].CollisionBox.X) / 2, (widgets[0].CollisionBox.Y + widgets[2].CollisionBox.Y) / 2, 16, 16);
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            if (Selected)
            {
                foreach(var widg in widgets)
                {
                    widg.Draw(sb);
                }
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

            foreach (var widg in widgets)
            {
                widg.Delete = true;
            }
        }

        private void Sprite_Hold(object sender, EventArgs e)
        {
            if (Selected)
            {
                var deltaX = _currentMouseState.X - _previousMoseState.X;
                var deltaY = _currentMouseState.Y - _previousMoseState.Y;
                CollisionBox = new Rectangle(CollisionBox.X + deltaX, CollisionBox.Y + deltaY, CollisionBox.Width, CollisionBox.Height);
                IsHold = true;
                foreach(var widg in widgets)
                {
                    widg.CollisionBox = new Rectangle(widg.CollisionBox.X + deltaX, widg.CollisionBox.Y + deltaY, widg.CollisionBox.Width, widg.CollisionBox.Height);
                }
            }
        }

        private void Sprite_Scale(object sender, EventArgs e)
        {
            if (Selected)
            {
                var deltaX = _currentMouseState.X - _previousMoseState.X;
                var deltaY = _currentMouseState.Y - _previousMoseState.Y;
                CollisionBox = new Rectangle(CollisionBox.X, CollisionBox.Y, CollisionBox.Width + deltaX, CollisionBox.Height + deltaY);
                IsHold = true;

                
                if (widgets[0].Selected) // If the top left widget increase the Y of the top right widget, and the X of the bottom left widget
                {
                    widgets[0].CollisionBox = new Rectangle(widgets[0].CollisionBox.X + deltaX, widgets[0].CollisionBox.Y + deltaY, widgets[0].CollisionBox.Width, widgets[0].CollisionBox.Height);
                    widgets[1].CollisionBox = new Rectangle(widgets[1].CollisionBox.X, widgets[0].CollisionBox.Y, widgets[1].CollisionBox.Width, widgets[1].CollisionBox.Height);
                    widgets[2].CollisionBox = new Rectangle(widgets[0].CollisionBox.X, widgets[2].CollisionBox.Y, widgets[2].CollisionBox.Width, widgets[2].CollisionBox.Height);
                }
                else if (widgets[1].Selected) // If the top right widget increase the Y of the top left widget, and the X of the bottom right widget
                {
                    widgets[1].CollisionBox = new Rectangle(widgets[1].CollisionBox.X + deltaX, widgets[1].CollisionBox.Y + deltaY, widgets[1].CollisionBox.Width, widgets[1].CollisionBox.Height);
                    widgets[0].CollisionBox = new Rectangle(widgets[0].CollisionBox.X, widgets[1].CollisionBox.Y, widgets[0].CollisionBox.Width, widgets[0].CollisionBox.Height);
                    widgets[3].CollisionBox = new Rectangle(widgets[1].CollisionBox.X, widgets[3].CollisionBox.Y, widgets[3].CollisionBox.Width, widgets[3].CollisionBox.Height);
                }
                else if (widgets[2].Selected) // If the bottom left widget increase the Y of the bottom right widget, and the X of the top left widget
                {
                    widgets[2].CollisionBox = new Rectangle(widgets[2].CollisionBox.X + deltaX, widgets[2].CollisionBox.Y + deltaY, widgets[2].CollisionBox.Width, widgets[2].CollisionBox.Height);
                    widgets[0].CollisionBox = new Rectangle(widgets[2].CollisionBox.X, widgets[0].CollisionBox.Y, widgets[0].CollisionBox.Width, widgets[0].CollisionBox.Height);
                    widgets[3].CollisionBox = new Rectangle(widgets[3].CollisionBox.X, widgets[2].CollisionBox.Y, widgets[3].CollisionBox.Width, widgets[3].CollisionBox.Height);
                }
                else if (widgets[3].Selected) // If the bottom right widget increase the Y of the bottom left widget, and the X of the top right widget
                {
                    widgets[3].CollisionBox = new Rectangle(widgets[3].CollisionBox.X + deltaX, widgets[3].CollisionBox.Y + deltaY, widgets[3].CollisionBox.Width, widgets[3].CollisionBox.Height);
                    widgets[1].CollisionBox = new Rectangle(widgets[3].CollisionBox.X, widgets[1].CollisionBox.Y, widgets[1].CollisionBox.Width, widgets[1].CollisionBox.Height);
                    widgets[2].CollisionBox = new Rectangle(widgets[2].CollisionBox.X, widgets[3].CollisionBox.Y, widgets[3].CollisionBox.Width, widgets[3].CollisionBox.Height);
                }

                widgets[4].CollisionBox = new Rectangle((widgets[0].CollisionBox.X + widgets[2].CollisionBox.X) / 2, (widgets[0].CollisionBox.Y + widgets[2].CollisionBox.Y) / 2, 16, 16);

                CollisionBox = new Rectangle(widgets[0].CollisionBox.X + (16/2), widgets[0].CollisionBox.Y + (16/2), widgets[1].CollisionBox.X - widgets[0].CollisionBox.X, widgets[2].CollisionBox.Y - widgets[0].CollisionBox.Y);
            }
        }
    }
}
