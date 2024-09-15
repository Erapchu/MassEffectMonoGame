using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class Box
    {
        public Texture2D Texture;
        public Rectangle BoxRectangle;

        public Box(Texture2D texture, Rectangle position)
        {
            Texture = texture;
            BoxRectangle = position;
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(Texture, BoxRectangle, Color.White);
        }
    }
}
