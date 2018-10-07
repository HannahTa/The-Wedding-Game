using Microsoft.Xna.Framework;

namespace PlayAround
{
    public static class Collision
    {
        public static bool CheckCollision(Rectangle rect1, Rectangle rect2)
        {
            if (rect1.X < (rect2.X + rect2.Width) && (rect1.X + rect1.Width) > rect2.X &&
                rect1.Y < (rect2.Y + rect2.Height) && (rect1.Height + rect1.Y) > rect2.Y)
            {
                return true;
            }
            return false;
        }

    }
}
