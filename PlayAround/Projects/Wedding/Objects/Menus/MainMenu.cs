using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace PlayAround
{
    class MainMenu
    {
        private readonly int TextureId = 0; // For Background
        private List<Button> buttons = new List<Button>();

        public MainMenu()
        {
            buttons.Add(new Button(0, 100, 100)); // New Game 
            buttons.Add(new Button(1, 100, 150)); // Load Game 
            buttons.Add(new Button(2, 100, 200)); // Options
            buttons.Add(new Button(3, 100, 250)); // Exit Game 
        }

        public int Update()
        {
            MouseState pos = Mouse.GetState();
            for(int i = 0; i < buttons.Count; i++)
            {
                if (i == 1 && !File.Exists("Content/JSONs/Player.json")) buttons[i].YFrame = 1; // Do Nothing
                else if (Collision.CheckCollision(buttons[i].source, new Rectangle(pos.X, pos.Y, 1, 1)))
                {
                    if (pos.LeftButton == ButtonState.Pressed) return (i+1);
                    else buttons[i].YFrame = 1;
                }
                else buttons[i].YFrame = 0;
            }
            return 0;
        }

        public void Draw(SpriteBatch sb)
        {
            foreach(Button b in buttons)
            {
                b.Draw(sb);
            }
        }
    }
}
