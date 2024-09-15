using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;


namespace Game1
{
      /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D boxtexture1,boxtexture2, vpravo, vlevo, vpravobeg1, vpravobeg2, vlevobeg1, vlevobeg2, prised;
        List<Box> boxs;
        Player player;
        Menu menu1;
        List<Laser> Lasers = new List<Laser>();
        KeyboardState pastkey;
        Victory victory;
        Texture2D healbar;
        Vector2 positionheal;
        Rectangle Rectangleheal;
        SpriteFont font;
        SpriteFont font1;

        int stor1, stor2;
        bool d = false;
        bool Win = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            IsMouseVisible = true;
            this.Window.Title = "Mass Effect: Arena";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            prised = Content.Load<Texture2D>("приседание");
            vpravo = Content.Load<Texture2D>("стойкавправо");
            vlevo = Content.Load<Texture2D>("стойкавлево");
            vpravobeg1 = Content.Load<Texture2D>("бегвправо1");
            vpravobeg2 = Content.Load<Texture2D>("бегвправо2");
            vlevobeg1 = Content.Load<Texture2D>("бегвлево1");
            vlevobeg2 = Content.Load<Texture2D>("бегвлево2");
            boxtexture1 = Content.Load<Texture2D>("пол");
            boxtexture2 = Content.Load<Texture2D>("коробка1");
            player = new Player(vpravo, new Vector2(80, 500));
            menu1 = new Menu(Content.Load<Texture2D>("menu"), new Rectangle(0, 0, 1280, 720));
            healbar = Content.Load<Texture2D>("heal-poison");
            positionheal = new Vector2(0, 0);
            Rectangleheal = new Rectangle(0, 0, healbar.Width, healbar.Height);
            victory = new Victory(Content.Load<Texture2D>("Победа"), new Rectangle(0, 0, 1280, 720));
            //font = Content.Load<SpriteFont>("SpriteFont1");
            //font1 = Content.Load<SpriteFont>("SpriteFont2");
            CreateMaps();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        /// 

        void CreateMaps()
        {
            boxs = new List<Box>();

            int x = 0, y = 0;
            int[,] map;
            map = new int[,]
            {{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, 
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, 
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, 
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, 
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0}, 
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0}, 
            {0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0}, 
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, 
            {0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0}, 
            {0,0,0,0,0,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0}, 
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,1,1,1,1,1,1,1,1,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {2,0,0,0,0,0,0,0,0,2,2,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1}};

           /* Random rand = new Random();

            map = new int[40, 40];

            for (int k = 15; k < map.GetLength(0); k++)
            {
                for (int l = 0; l < map.GetLength(1); l++)
                {
                    map[k, l] = rand.Next(2);
                }
            }*/

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Rectangle rect = new Rectangle(x, y,40,40);     //место, где находится блок
                    int a = map[i, j];                              //какой блок

                    if (a == 1)
                    {
                        Box box = new Box(boxtexture1, rect);
                        boxs.Add(box);                              //запоминаем созданный объект
                    }

                    else if (a == 2)
                    {
                        Box box = new Box(boxtexture2, rect);
                        boxs.Add(box);
                    }
                    x +=40;
                }
                x = 0;
                y += 40;
            }
            
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            UpdateLaser();

            if (Keyboard.GetState().IsKeyDown(Keys.E) && pastkey.IsKeyUp(Keys.E))
            {
                Shooting();
            }

           // pastkey = Keyboard.GetState();                  //уже нажатые кнопки

            if (player.Right == true)
            {
                if (stor1 > 40) stor1 = 1;
                if ((stor1 >= 0) & (stor1 < 10)) player.PlayerTexture = vpravobeg2;         //анимации
                if ((stor1 >= 10) & (stor1 < 20)) player.PlayerTexture = vpravo;
                if ((stor1 >= 20) & (stor1 < 30)) player.PlayerTexture = vpravobeg1;
                if ((stor1 >= 30) & (stor1 < 40)) player.PlayerTexture = vpravo;
                stor1++;
            } else if (player.PlayerTexture == vpravobeg1 || player.PlayerTexture == vpravobeg2) player.PlayerTexture = vpravo;

            if (player.Left == true)
            {
                if (stor2 > 40) stor2 = 1;
                if ((stor2 >= 0) & (stor2 < 10)) player.PlayerTexture = vlevobeg2;
                if ((stor2 >= 10) & (stor2 < 20)) player.PlayerTexture = vlevo;
                if ((stor2 >= 20) & (stor2 < 30)) player.PlayerTexture = vlevobeg1;
                if ((stor2 >= 30) & (stor2 < 40)) player.PlayerTexture = vlevo;
                stor2 ++;
            } else if (player.PlayerTexture == vlevobeg1 || player.PlayerTexture == vlevobeg2) player.PlayerTexture = vlevo;

            if (player.Prisel && !player.PlayerJumped)
            {
                player.PlayerTexture = prised;
                player.PlayerVelocity.X = 0f;
                player.PlayerVelocity.Y = 0f;
            }
            else if (player.PlayerTexture == prised) player.PlayerTexture = vpravo;         //анимации
            
            foreach (Box box in boxs) 
            {
                if (player.PlayerRectangle.Bottom >= box.BoxRectangle.Top - 5 && player.PlayerRectangle.Bottom <= box.BoxRectangle.Top+5 &&     //стоит на блоке
                    player.PlayerRectangle.Right >= box.BoxRectangle.Left+5 && player.PlayerRectangle.Left <= box.BoxRectangle.Right-5)
                {
                    player.PlayerVelocity.Y = 0f;
                    player.PlayerJumped = false;
                    player.PlayerRectangle.Y = box.BoxRectangle.Top-player.PlayerRectangle.Height;
                }

                if (player.PlayerRectangle.Right > box.BoxRectangle.Left && player.PlayerRectangle.Right < box.BoxRectangle.Left+10 &&        //игрок слева от блока
                    player.PlayerRectangle.Bottom > box.BoxRectangle.Top+5 && player.PlayerRectangle.Bottom < box.BoxRectangle.Bottom+5)
                {
                    player.PlayerPosition.X = box.BoxRectangle.Left - player.PlayerRectangle.Width;
                }

                if (player.PlayerRectangle.Left < box.BoxRectangle.Right && player.PlayerRectangle.Left > box.BoxRectangle.Right-10 &&        //игрок справа от блока
                   player.PlayerRectangle.Bottom > box.BoxRectangle.Top+5 && player.PlayerRectangle.Bottom < box.BoxRectangle.Bottom+5)
                {
                    player.PlayerPosition.X = box.BoxRectangle.Right;
                }
            }

            

            base.Update(gameTime);
        }


        public void UpdateLaser()                                                                                               //движение лазера, проверка условий
        {
            foreach (Laser onelaser in Lasers)
            {
                onelaser.LaserPosition += onelaser.LaserVelocity;
                float onelaserright = onelaser.LaserPosition.X+onelaser.LaserTexture.Width;
                float onelaserbottom = onelaser.LaserPosition.Y+onelaser.LaserTexture.Height;

                foreach (Box box in boxs.ToArray())
                {
                    if (onelaserright > box.BoxRectangle.Left && onelaserright < box.BoxRectangle.Left + 10 &&                                  //условие чтобы лазер исчезал когда попадает в блок
                        onelaserbottom > box.BoxRectangle.Top + 5 && onelaserbottom < box.BoxRectangle.Bottom + 5)
                    { onelaser.isVisible = false; boxs.Remove(box); }
                    if (onelaser.LaserPosition.X < box.BoxRectangle.Right && onelaser.LaserPosition.X > box.BoxRectangle.Right - 10 &&
                        onelaserbottom > box.BoxRectangle.Top + 5 && onelaserbottom < box.BoxRectangle.Bottom + 5)
                    { onelaser.isVisible = false; boxs.Remove(box); }
                    
                }
                if (onelaser.LaserPosition.X > graphics.PreferredBackBufferWidth || onelaser.LaserPosition.X < 0)
                onelaser.isVisible = false;
            }

            for (int i = 0; i < Lasers.Count; i++)
            {
                if (!Lasers[i].isVisible)
                {
                    Lasers.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Shooting()                                                                                                          //стрельба
        {
            Laser newLaser = new Laser(Content.Load<Texture2D>("laser"));
            if (player.PlayerTexture == vpravobeg1 || player.PlayerTexture == vpravo || player.PlayerTexture == vpravobeg2)
            {
                newLaser.LaserVelocity = new Vector2(5, 0);
                newLaser.LaserPosition.X = player.PlayerPosition.X + 35;
                newLaser.LaserPosition.Y = player.PlayerPosition.Y + 15;
                newLaser.isVisible = true;
                Lasers.Add(newLaser);
            }

            if (player.PlayerTexture == vlevobeg1 || player.PlayerTexture == vlevo || player.PlayerTexture == vlevobeg2)
            {
                newLaser.LaserVelocity = new Vector2(-5, 0);
                newLaser.LaserPosition.X = player.PlayerPosition.X - 35;
                newLaser.LaserPosition.Y = player.PlayerPosition.Y + 15;
                newLaser.isVisible = true;
                Lasers.Add(newLaser);
            }
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            if (Keyboard.GetState().IsKeyDown(Keys.F1))
            {
                d = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                d = false;
            }

            if (d == true)
            {
                foreach (Box box in boxs)
                {
                    box.Draw(spriteBatch);
                }
                player.Draw(spriteBatch);
                spriteBatch.Draw(healbar, positionheal, Rectangleheal, Color.White);
                //spriteBatch.DrawString(font, "Sheppard", new Vector2(260, -2), Color.White);
                if (Rectangleheal.Width == 0)
                {
                    Win = true;
                    Rectangleheal.Width = 250;
                }
                foreach (Laser bullet in Lasers)
                {
                    bullet.Draw(spriteBatch);
                }
            }
            else
            {
                menu1.Draw(spriteBatch);
                player.PlayerPosition.X = 80;
                player.PlayerPosition.Y = 500;

            }

            if (Win == true || player.PlayerPosition.Y >= 720)
            {
                victory.Draw(spriteBatch);
                //spriteBatch.DrawString(font1, "You win", new Vector2(640, 350), Color.Black);
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    d = false;
                    Rectangleheal.Width = 250;
                    Win = false;
                }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
