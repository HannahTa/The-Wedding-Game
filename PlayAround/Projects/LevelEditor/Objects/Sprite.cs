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

        // Used for re-sizing Widgets
        private string EventType = "";
        private string calcType = ""; 

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
                new Widget(game, new Rectangle(collisionBox.X - 8, collisionBox.Y - 8, 16, 16), Game.Content.Load<Texture2D>("Sprites/editor/CornerWidget"), textureID, "Scale"),
                new Widget(game, new Rectangle(collisionBox.X - 8 + collisionBox.Width, collisionBox.Y - 8, 16, 16), Game.Content.Load<Texture2D>("Sprites/editor/CornerWidget"), textureID, "Scale"),
                new Widget(game, new Rectangle(collisionBox.X - 8, collisionBox.Y + collisionBox.Height - 8, 16, 16), Game.Content.Load<Texture2D>("Sprites/editor/CornerWidget"), textureID, "Scale"),
                new Widget(game, new Rectangle(collisionBox.X + collisionBox.Width - 8, collisionBox.Y + collisionBox.Height - 8, 16, 16), Game.Content.Load<Texture2D>("Sprites/editor/CornerWidget"), textureID, "Scale"),
                new Widget(game, new Rectangle(collisionBox.X + (collisionBox.Width/2) - 8, collisionBox.Y + (collisionBox.Height/2) - 8, 16, 16), Game.Content.Load<Texture2D>("Sprites/editor/CentreWidget"), textureID, "Move")
            };
        }

        public override void Update(GameTime gameTime, Rectangle windowPos, Camera2D cam)
        {
            _previousMoseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
            // Calculations
            if (!calcType.Equals(""))
            {
                if (_currentMouseState.LeftButton == ButtonState.Released)
                {
                    calcType = "";
                }
                else 
                {
                    if (EventType == "Move") { events[1]?.Invoke(this, new EventArgs()); }
                    else if (EventType == "Scale") { events[3]?.Invoke(this, new EventArgs()); }
                }
            }
            else
            {
                var mouseRectangle = new Rectangle(_currentMouseState.X + (int)cam.Pos.X, _currentMouseState.Y + (int)cam.Pos.Y, 10, 10);
                if (Selected)
                {                    
                    if (mouseRectangle.Intersects(CollisionBox))
                    {
                        if (_currentMouseState.LeftButton == ButtonState.Pressed)
                        {
                            foreach (var widg in widgets)
                            {
                                if (mouseRectangle.Intersects(widg.CollisionBox))
                                {
                                    // Calculations (+5 leeway to make selecting corner easier)
                                    /// Width
                                    if (mouseRectangle.X <= (CollisionBox.X+5)) calcType = "1";
                                    else if (mouseRectangle.X >= (CollisionBox.X + CollisionBox.Width)) calcType = "3";
                                    else calcType = "2";
                                    /// Height
                                    if (mouseRectangle.Y <= (CollisionBox.Y+5)) calcType += "a";
                                    else if (mouseRectangle.Y >= (CollisionBox.Y + CollisionBox.Height)) calcType += "c";
                                    else calcType += "b";
                                    // Begin the calculations
                                    EventType = widg.EventType;

                                    Console.WriteLine(calcType);
                                }
                            }
                        }
                        else if (_currentMouseState.RightButton == ButtonState.Pressed)
                        {
                            events[2]?.Invoke(this, new EventArgs());
                        }
                    }
                    else if (_currentMouseState.LeftButton == ButtonState.Pressed) events[0]?.Invoke(this, new EventArgs());
                }
                else
                {
                    if (mouseRectangle.Intersects(CollisionBox))
                    {
                        _isHovering = true;
                        if (_currentMouseState.LeftButton == ButtonState.Released && _previousMoseState.LeftButton == ButtonState.Pressed)
                        {
                            //if (!IsNew)
                                events[0]?.Invoke(this, new EventArgs());
                        }
                        if (_currentMouseState.RightButton == ButtonState.Released && _previousMoseState.RightButton == ButtonState.Pressed)
                        {
                            events[2]?.Invoke(this, new EventArgs());
                        }
                    }
                }
            }
        }

        public void WidgetUpdate()
        {
            widgets[0].CollisionBox = new Rectangle(CollisionBox.X - 8, CollisionBox.Y - 8, 16, 16);
            widgets[1].CollisionBox = new Rectangle(CollisionBox.X - 8 + CollisionBox.Width, CollisionBox.Y - 8, 16, 16);
            widgets[2].CollisionBox = new Rectangle(CollisionBox.X - 8, CollisionBox.Y + CollisionBox.Height - 8, 16, 16);
            widgets[3].CollisionBox = new Rectangle(CollisionBox.X + CollisionBox.Width - 8, CollisionBox.Y + CollisionBox.Height - 8, 16, 16);
            widgets[4].CollisionBox = new Rectangle(CollisionBox.X + (CollisionBox.Width / 2) - 8, CollisionBox.Y + (CollisionBox.Height / 2) - 8, 16, 16);
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
            // Get Dimensions
            int x = CollisionBox.X;
            int y = CollisionBox.Y;
            int W = CollisionBox.Width;
            int H = CollisionBox.Height;
            int deltaX = _currentMouseState.X - _previousMoseState.X;
            int deltaY = _currentMouseState.Y - _previousMoseState.Y;
            // Calculate New Dimensions
            if (calcType.Contains("1"))
            {
                x = x + deltaX;
                W = W - deltaX;
            }
            else if (calcType.Contains("2")) W = W + deltaX; 
            else H = H + deltaY;
            if (calcType.Contains("a"))
            {
                y = y + deltaY;
                H = H - deltaY;
            }
            else if (calcType.Contains("b")) H = H + deltaY; 
            else W = W + deltaX;
            // Fix for inverted image
            if (W <= 0 && calcType.Contains("1")) calcType = calcType.Replace('1', '2');
            else if (W <= 0 && calcType.Contains("2")) calcType = calcType.Replace('2', '1');
            if (H <= 0 && calcType.Contains("a")) calcType = calcType.Replace('a', 'b');
            else if (H <= 0 && calcType.Contains("b")) calcType = calcType.Replace('b', 'a');
            // Set New Dimensions
            Rectangle NewBox = new Rectangle(x, y, W, H);
            if (CollisionBox != NewBox)
            {
                CollisionBox = NewBox;
                WidgetUpdate();
            }
        }
    }
}
