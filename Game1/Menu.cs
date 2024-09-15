using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class Menu
    {
        Texture2D FON;
        Rectangle menuposition;
        public Menu(Texture2D texture, Rectangle position)
        {
            FON = texture;
            menuposition = position;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(FON, menuposition, Color.White);
        }
    }
}
