using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PlayAround
{
    public class Sample
    {
        // Standard
        private int id;
        private int x;
        private int y;
        private int width;
        private int height;
        private Texture2D txt;
        // Calculated
        private Rectangle destBall;
        private Rectangle sourceBall;

        public Sample(int id, int x, int y, int w, int h, int textureID)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.width = w;
            this.height = h;

            //this.txt = SpriteLoader.sampleTexture;
            this.txt = SpriteLoader.GetTexture(textureID);
            destBall = new Rectangle(x, y, width, height);
            sourceBall = new Rectangle((width*1), 0, width, height);
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(txt, destBall, sourceBall, Color.White);
        }
    }
}
