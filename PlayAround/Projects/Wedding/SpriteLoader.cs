using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PlayAround
{
    public static class SpriteLoader
    {
        private static Dictionary<int, Texture2D> textures = new Dictionary<int, Texture2D>();

        public static void LoadTextures(ContentManager cnt)
        {
            Texture[] jsonTextures = JsonConvert.DeserializeObject<Texture[]>(File.ReadAllText("../../../../JSONs/Texture.json"));
            foreach (Texture tex in jsonTextures)
            {
                textures.Add(tex.Id, cnt.Load<Texture2D>(tex.ImageName));
            }  
        }

        public static Texture2D GetTexture(int id)
        {
            return textures[id];
        }
    }
}