using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LevelEditor
{
    class Camera2D : GameComponent
    {
        protected float _zoom; // Camera Zoom
        public Matrix _transform; // Matrix Transform
        public Vector2 _pos; // Camera Position
        protected float _rotation; // Camera Rotation

        public Camera2D(Game game) : base(game)
        {
            _zoom = 1.0f;
            _rotation = 0.0f;
            _pos = Vector2.Zero;
        }

        // Sets and gets zoom
        public float Zoom
        {
            get { return _zoom; }
            set { _zoom = value; if (_zoom < 0.1f) _zoom = 0.1f; } // Negative zoom will flip image
        }

        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        // Auxiliary function to move the camera
        public void Move(Vector2 amount)
        {
            _pos += amount;
        }
        // Get set position
        public Vector2 Pos
        {
            get { return _pos; }
            set { _pos = value; }
        }

        public Matrix get_transformation(GraphicsDevice graphicsDevice)
        {
            _transform =       // Thanks to o KB o for this solution
              Matrix.CreateTranslation(new Vector3(-_pos.X, -_pos.Y, 0)) *
                                         Matrix.CreateRotationZ(Rotation) *
                                         Matrix.CreateScale(_zoom);
            return _transform;
        }

        public override void Update(GameTime gameTime)
        {
            Mousescroll();
        }

        public void Mousescroll()
        {
            MouseState mouseState = Mouse.GetState();
            if (mouseState.Position.X > Game.GraphicsDevice.Viewport.X + Game.GraphicsDevice.Viewport.Width)
            {
                _pos.X += 5f;
            }
            if (mouseState.Position.Y > Game.GraphicsDevice.Viewport.Y + Game.GraphicsDevice.Viewport.Height)
            {
                _pos.Y += 5f;
            }
            if (mouseState.Position.X < Game.GraphicsDevice.Viewport.X)
            {
                _pos.X -= 5f;
            }
            if (mouseState.Position.Y < Game.GraphicsDevice.Viewport.Y)
            {
                _pos.Y -= 5f;
            }
        }
    }
}
