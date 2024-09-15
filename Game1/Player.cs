using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class Player
    {
        public Texture2D PlayerTexture;
        public Vector2 PlayerPosition;
        public Vector2 PlayerVelocity;
        public bool PlayerJumped, Right, Left, Prisel;
        public Rectangle PlayerRectangle;

        public Player(Texture2D newTexture, Vector2 newPosition)
        {
            PlayerPosition = newPosition;
            PlayerTexture = newTexture;
            PlayerJumped = true;
        }

        public void Update(GameTime gametime)
        {
            PlayerPosition += PlayerVelocity;
            PlayerRectangle = new Rectangle((int)PlayerPosition.X, (int)PlayerPosition.Y, PlayerTexture.Width, PlayerTexture.Height);

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                PlayerVelocity.X = 3.5f;
                Right = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                PlayerVelocity.X = -3.5f;
                Left = true;
            }
            else
            {
                PlayerVelocity.X = 0;
                Right = false;
                Left = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S)) Prisel = true;
            else Prisel = false;


            if (Keyboard.GetState().IsKeyDown(Keys.W) && PlayerJumped == false)
            {
                PlayerPosition.Y -= 10f;
                PlayerVelocity.Y = -10f;
                PlayerJumped = true;
            }

            if (PlayerPosition.X <= 0) PlayerPosition.X = 0;        //граница слева

            if (PlayerPosition.X + PlayerTexture.Width >= 1280) PlayerPosition.X = 1280 - PlayerTexture.Width;      //граница справа

            if (PlayerVelocity.Y > 0) PlayerJumped = true;          //если уже падает, то в полете прыгнуть не может

            if (PlayerVelocity.Y <= 10) PlayerVelocity.Y += 0.40f;  //условие, чтобы не падал с бесконечным ускорением

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PlayerTexture, PlayerRectangle, Color.White);
        }
    }
}
