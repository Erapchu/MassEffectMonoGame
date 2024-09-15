using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class Laser
    {
        public Texture2D LaserTexture;
        public Vector2 LaserPosition;
        public Vector2 LaserVelocity;
        public Vector2 LaserOriginalPosition;
        public bool isVisible;

        public Laser(Texture2D laserTexture)
        {
            LaserTexture = laserTexture;
            isVisible = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(LaserTexture, LaserPosition, null, Color.White, 0f, LaserOriginalPosition, 1f, SpriteEffects.None, 0);
        }
    }
}
