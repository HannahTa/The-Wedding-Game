using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LevelEditor.Objects
{
    class Widget : SpriteComponent
    {

        private Dictionary<int, Texture2D> widgetTextures;
        public string EventType;

        public Widget(Game game, Rectangle collisionBox, Texture2D texture, int textureID, string eventType) : base(game, collisionBox, texture, textureID)
        {
            this.EventType = eventType;
        }
    }
}
