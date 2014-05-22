using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;
using System.Threading;

namespace Snake
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public class Apple
        {
            public int x = 0;
            public int y = 0;
        }

        public class Snake
        {
            public int x = 0;
            public int y = 0;

        }
        public class Menu
        {
            public int x = 220;
            public int y = 100;

        }
        public class Enter
        { 
            
            public void first()
            {
                b = true;
                navigate = 0;
                snake[0].x = 320;
                snake[1].x = 320 - 32;
                snake[2].x = 320 - 32 - 32;
                snake[0].y = snake[1].y = snake[2].y = 320;
                length = 3;
                speed = 400;
            }
            public void second()
            {
                
                h = !h;
  
            }
        }
        
        class Fille
        {
            public void save(string record)
            {
                //string record = File.ReadAllText("record.txt"); 
                File.WriteAllText("record.txt", record);
            }
        }
        GraphicsDeviceManager graphics;
        int record = Int32.Parse(File.ReadAllText("record.txt"));
        Texture2D rectangle;
        SpriteFont font;
        SpriteFont font2;
        SpriteFont Font3;
        SpriteFont fonth;
        SpriteBatch spriteBatch;
        Texture2D body;
        Texture2D head;
        Texture2D xvist;
        Texture2D a;
        Texture2D w;
        Texture2D s;
        Texture2D d;
        Texture2D ent;
        Texture2D esc;
        Texture2D apple;
        Texture2D prob;
        Texture2D n;
        Texture2D p;
        Texture2D v;
        Texture2D L;
        Texture2D wall;
        Texture2D wallv;
        public static bool b = false;
        public static bool c = true;
        public static bool h = true;
        public static bool apl = true;
        Apple apples = new Apple();
        public static int length = 3;
        public static int navigate = 0;
        Random rnd = new Random();
        public static Snake[] snake = new Snake[100];
        Menu  menu = new Menu();
        Enter enter = new Enter();
        KeyboardState oldstate;
        public static int speed;
        Fille obj= new Fille();

        
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            
                
                for (int i = 0; i < 100; i++)
                {
                    snake[i] = new Snake();
                }
                snake[0].x = 320;
                snake[1].x = 320 - 32;
                snake[2].x = 320 - 32 - 32;
                snake[0].y = snake[1].y = snake[2].y = 320;
                for (; ; )
                {
                    apples.x = rnd.Next(0, 648);
                    apples.y = rnd.Next(0, 488);
                    if ((apples.x % 32 == 0) && (apples.y % 32 == 0))
                    {
                        break;
                    }
                }


               
                base.Initialize();
            
        }

       
        protected override void LoadContent()
        {
            fonth = Content.Load<SpriteFont>("Content/fonth");
            font2 = Content.Load<SpriteFont>("Content/font2");
            font = Content.Load<SpriteFont>("Content/font");
            Font3 = Content.Load<SpriteFont>("Content/Font3");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            head = Content.Load<Texture2D>("Content/head");
            body = Content.Load<Texture2D>("Content/body");
            xvist = Content.Load<Texture2D>("Content/xvist");
            apple = Content.Load<Texture2D>("Content/apple");
            rectangle = Content.Load<Texture2D>("Content/rectangle");
            s = Content.Load<Texture2D>("Content/s");
            d = Content.Load<Texture2D>("Content/d");
            a = Content.Load<Texture2D>("Content/a");
            w = Content.Load<Texture2D>("Content/w");
            ent = Content.Load<Texture2D>("Content/ent");
            esc = Content.Load<Texture2D>("Content/esc");
            prob = Content.Load<Texture2D>("Content/prob");
            n = Content.Load<Texture2D>("Content/n");
            p = Content.Load<Texture2D>("Content/p");
            v = Content.Load<Texture2D>("Content/v");
            L = Content.Load<Texture2D>("Content/L");
            wall= Content.Load<Texture2D>("Content/wall");
            wallv = Content.Load<Texture2D>("Content/wallv");
        }

       
        protected override void UnloadContent()
        {
            
        }

        
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && oldstate.IsKeyUp(Keys.Space))
            {
                c = !c;
                oldstate = Keyboard.GetState();
            }
            if (c)
            {
                if (b)
                {
                 
                    
                    UpdateKey();
                
                    if ((snake[0].x == apples.x) && (snake[0].y == apples.y))
                    {
                        length++;
                        snake[length - 1].x = snake[length - 2].x;
                        snake[length - 1].y = snake[length - 2].y;
                        for (; ; )
                        {
                            apples.x = rnd.Next(0, 608);
                            apples.y = rnd.Next(0, 448);
                            if ((apples.x % 32 == 0) && (apples.y % 32 == 0))
                            {
                                apl = true;
                                for (int i = 0; i < length; i++)
                                {
                                    if ((apples.x == snake[i].x) && (apples.y == snake[i].y))
                                    {
                                        apl = false;
                                    }
                                }



                                if (((apples.x == 320) && (apples.y == 256)) || ((apples.x == 352) && (apples.y == 256)) || ((apples.x == 544) && (apples.y == 416)) || ((apples.x == 544) && (apples.y == 448)) || ((apples.x == 96) && (apples.y == 256)) || ((apples.x == 96) && (apples.y == 224)))
                                { }
                                else
                                {
                                    if (apl)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (length > 18)
                        speed = 200;
                    if (gameTime.TotalGameTime.Milliseconds % speed == 0)
                    {
                        for (int i = length - 1; i > 0; i--)
                        {
                            snake[i].x = snake[i - 1].x;
                            snake[i].y = snake[i - 1].y;

                        }


                        switch (navigate)
                        {
                            case 0:

                                snake[0].x += 32;
                                break;

                            case 1:

                                snake[0].x -= 32;
                                break;

                            case 2:

                                snake[0].y += 32;
                                break;

                            case 3:

                                snake[0].y -= 32;
                                break;

                        }
                    }
                    for (int i = 1; i < length; i++)
                    {
                        if ((snake[0].x == snake[i].x) && (snake[0].y == snake[i].y)) b = false;
                        

                    }
                   
                    if ((snake[0].x < 800) && (snake[0].y <= 470) && (snake[0].x >= 0) && (snake[0].y >= 0)) { }
                    else
                        b = false;
                }
                else
                {

                    if (gameTime.TotalGameTime.Milliseconds % 100 == 0)
                        UpdateKey();
                }
               
   
            }
            oldstate = Keyboard.GetState();
            base.Update(gameTime);
        }
        public void UpdateKey()
        {
            KeyboardState key = Keyboard.GetState();
           if (!(navigate==2)) if (key.IsKeyDown(Keys.W))
            {
                navigate = 3;
            }
        
        if (!(navigate==3)) if (key.IsKeyDown(Keys.S))
            {
                navigate = 2;
            }
        if (!(navigate==0)) if (key.IsKeyDown(Keys.A))
            {
                navigate = 1;
            }
          if (!(navigate==1))if (key.IsKeyDown(Keys.D))
            {
                navigate = 0;
            }
          
          if (!b)
          {
              if (key.IsKeyDown(Keys.Up))
              {
                  if (menu.y != 100)
                  {
                      menu.y = menu.y - 60;
                  }
              }
              if (key.IsKeyDown(Keys.Down))
              {
                  if (menu.y != 220)
                  {
                      menu.y = menu.y + 60;
                  }
              }
              if (key.IsKeyDown(Keys.Enter))
              {
                  if (menu.y == 100)
                  {
                      enter.first();
                  }
                  if (menu.y == 220)
                  {
                      this.Exit();
                  }
              }
              
                  if (key.IsKeyDown(Keys.Enter))
                  {

                      if (menu.y == 160)
                      {
                         enter.second();
                      }
                  }
          }
                      if (key.IsKeyDown(Keys.Escape))
                          {
                                b = false;
                                h = true;

                          }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.MediumPurple);
            spriteBatch.Begin();
            if (!c)
            {
                spriteBatch.DrawString(Font3, "Pause", new Vector2(300, 150), Color.Black);
            }
            
  
            if (b)
            {
                
                for (int i = 0; i < length; i++)
                {
                    if (i == 0)
                        spriteBatch.Draw(head, new Vector2(snake[i].x, snake[i].y), Color.White);

                    else
                        if ((i > 0) && (i < length - 1))
                            spriteBatch.Draw(body, new Vector2(snake[i].x, snake[i].y), Color.White);
                        else
                            spriteBatch.Draw(xvist, new Vector2(snake[i].x, snake[i].y), Color.White);
                    spriteBatch.Draw(apple, new Vector2(apples.x, apples.y), Color.White);
                }
                if (length <=9)
                {
                    
                       spriteBatch.DrawString(font, "Level 1", new Vector2(600, 20), Color.Yellow);
                     
                }
                else
                    if ((length >=10)&& (length <19))
                    {
                        //snake[length].x = 320;
                        //snake[length].y = 320; 
                        spriteBatch.DrawString(font, "Level 2", new Vector2(600, 20), Color.Yellow);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Level 3", new Vector2(600, 20), Color.Yellow);
                    }
                if (length>=10)
                {
                    apl = true;
                    for (int i = 1; i < length; i++)
                    {
                        if (((snake[i].x == 320) && (snake[i].y == 256)) || ((snake[i].x == 352) && (snake[i].y == 256)) || ((snake[i].x == 544) && (snake[i].y == 416)) || ((snake[i].x == 544) && (snake[i].y == 448)) || ((snake[i].x == 96) && (snake[i].y == 256)) || ((snake[i].x == 96) && (snake[i].y == 224)))
                        {
                            apl = false;
                        }
                    }
                    if (apl)
                    {
                        spriteBatch.Draw(wall, new Vector2(320, 256), Color.White);
                        spriteBatch.Draw(wallv, new Vector2(544, 416), Color.White);
                        spriteBatch.Draw(wallv, new Vector2(96, 224), Color.White);
                    }
                        if (((snake[0].x == 320) && (snake[0].y == 256)) || ((snake[0].x == 352) && (snake[0].y == 256)) || ((snake[0].x == 544) && (snake[0].y == 416)) || ((snake[0].x == 544) && (snake[0].y == 448)) || ((snake[0].x == 96) && (snake[0].y == 256)) || ((snake[0].x == 96) && (snake[0].y == 224)))
                        {
                            b = false;
                        }
                    
                }
                
             }
            else if (h)
            {
                spriteBatch.Draw(rectangle, new Vector2(200, menu.y), Color.White);
                spriteBatch.DrawString(font2, "New game", new Vector2(300, 100), Color.Black);
               // spriteBatch.DrawString(font2, "Save record ", new Vector2(268, 160), Color.Black);
                spriteBatch.DrawString(font2, "Help ", new Vector2(340, 160), Color.Black);
                spriteBatch.DrawString(font2, "Exit", new Vector2(340, 220), Color.Black);
                
            }
            if (h)
            {
                if (length - 3 > record)
                {

                    obj.save((length - 3).ToString());
                }
                record = Int32.Parse(File.ReadAllText("record.txt"));
                spriteBatch.DrawString(font, "Score:", new Vector2(10, 10), Color.Aquamarine);
                spriteBatch.DrawString(font, (length - 3).ToString(), new Vector2(120, 10), Color.Aquamarine);
                spriteBatch.DrawString(font, "Record:", new Vector2(160, 10), Color.Aquamarine);
                spriteBatch.DrawString(font, record.ToString(), new Vector2(280, 10), Color.Aquamarine);
            }
            else
            {
                spriteBatch.Draw(a, new Vector2(15, 120), Color.White);
                spriteBatch.DrawString(fonth, "- Snake left", new Vector2(65, 120), Color.Blue);
                spriteBatch.Draw(w, new Vector2(90, 65), Color.White);
                spriteBatch.DrawString(fonth, "- Snake up", new Vector2(140, 65), Color.Blue);
                spriteBatch.Draw(s, new Vector2(100, 200), Color.White);
                spriteBatch.DrawString(fonth, "- Snake down ", new Vector2(150, 200), Color.Blue);
                spriteBatch.Draw(d, new Vector2(240, 120), Color.White);
                spriteBatch.DrawString(fonth, "- Snake right ", new Vector2(290, 120), Color.Blue);
                spriteBatch.Draw(prob, new Vector2(150, 420), Color.White);
                spriteBatch.DrawString(fonth, " - Pause ", new Vector2(360, 420), Color.Blue);
                spriteBatch.Draw(esc, new Vector2(10, 10), Color.White);
                spriteBatch.DrawString(fonth, "-  Back", new Vector2(60, 10), Color.Blue);
                spriteBatch.Draw(ent, new Vector2(450, 170), Color.White);
                spriteBatch.DrawString(fonth, "- Enter ", new Vector2(570, 190), Color.Blue);
                spriteBatch.Draw(v, new Vector2(520, 320), Color.White);
                spriteBatch.DrawString(fonth, " - Menu's up ", new Vector2(565, 320), Color.Blue);
                spriteBatch.Draw(n, new Vector2(520, 390), Color.White);
                spriteBatch.DrawString(fonth, " - Menu's down ", new Vector2(570, 390), Color.Blue);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
        
    }
}
