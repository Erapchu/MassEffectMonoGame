using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class Victory
    {
        Texture2D winFON;
        Rectangle winposition;
        public Victory(Texture2D texture, Rectangle position)
        {
            winFON = texture;
            winposition = position;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(winFON, winposition, Color.White);
        }
    }
}
