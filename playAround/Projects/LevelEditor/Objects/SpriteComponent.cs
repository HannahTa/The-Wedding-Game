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
    class SpriteComponent : GameComponent
    {
        public Texture2D Texture { get; set; }
        public Rectangle CollisionBox { get; set; }
        public Color SpriteColor { get; set; }
        public int TextureID { get; set; }
        public bool _isHovering;
        public bool Delete { get; set; }
        public bool Selected { get; set; }
        public bool IsHold { get; set; }
        public bool IsNew { get; set; }
        public int Sequence { get; set; }

        public MouseState _currentMouseState;
        public MouseState _previousMoseState;

        public SpriteComponent(Game game, Rectangle collisionBox, Texture2D texture, int textureID) : base(game)
        {
            Texture = texture;
            TextureID = textureID;
            CollisionBox = collisionBox;
            Delete = false;
            IsNew = true;
            IsHold = false;
            SpriteColor = Color.White;
        }

        public virtual void Update(GameTime gameTime, Rectangle windowPos, Camera2D cam)
        {
            _previousMoseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();

            Vector2 position = new Vector2(_currentMouseState.X + cam.Pos.X, _currentMouseState.Y + cam.Pos.Y);

            CollisionBox = new Rectangle((int)position.X, (int)position.Y, Texture.Width, Texture.Height);
        }

        public virtual void Draw(SpriteBatch sb)
        {
            if (!Delete)
                sb.Draw(Texture, CollisionBox, null, SpriteColor, 0, Vector2.Zero, SpriteEffects.None, 0);
        }

        public virtual int GetTextureID()
        {
            return TextureID;
        }
    }
}
