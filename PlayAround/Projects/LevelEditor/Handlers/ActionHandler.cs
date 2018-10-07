using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor
{
    public class ActionHandler : GameComponent
    {
        public MouseState CurrentMouseState { get; private set; }
        public MouseState PreviousMouseState { get; private set; }
        public KeyboardState CurrentKeyboardState { get; private set; }
        public KeyboardState PreviousKeyboardState { get; private set; }
        public bool HeldDown { get; private set; }
        public bool HeldRelease { get; private set; }

        public ActionHandler(Game game) : base(game)
        {
            CurrentMouseState = new MouseState();
            PreviousMouseState = new MouseState();
            CurrentKeyboardState = new KeyboardState();
            PreviousKeyboardState = new KeyboardState();
        }

        public bool CheckMouse(Rectangle block, Camera2D cam)
        {
            if (CurrentMouseState.Position.X + cam.Pos.X > block.X &&
                CurrentMouseState.Position.X + cam.Pos.X < block.X + block.Width &&
                CurrentMouseState.Position.Y + cam.Pos.Y > block.Y &&
                CurrentMouseState.Position.Y + cam.Pos.Y < block.Y + block.Height)
                return true;
            else
                return false;
        }

        public override void Update(GameTime gameTime)
        {
            PreviousMouseState = CurrentMouseState;
            PreviousKeyboardState = CurrentKeyboardState;
            CurrentMouseState = Mouse.GetState();
            CurrentKeyboardState = Keyboard.GetState();
            HeldRelease = !HeldDown;
            HeldDown = CurrentMouseState.LeftButton == ButtonState.Pressed && PreviousMouseState.LeftButton == ButtonState.Pressed;
            base.Update(gameTime);
        }
    }
}
