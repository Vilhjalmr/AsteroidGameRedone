using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGameRedone.Models
{
    class Spaceship
    {
        public Texture2D Texture;
        public Texture2D TextureLaser;

        private int posX, posY, width, height;

        public Rectangle Position
        {
            get
            {
                return new Rectangle(posX, posY, width, height);
            }
        }

        public List<LaserShot> Lasershots { get; set; }



        // CONSTRUCTOR
        public Spaceship(int x, int y, int w, int h)
        {
            posX = x;
            posY = y;
            width = w;
            height = h;
            Lasershots = new List<LaserShot>();
        }

        /** METHODS **/

        public void Move(Direction direction, int xMax, int yMax)
        {
            switch (direction)
            {
                case Direction.Up:
                    if ((this.posY - 5) > 0)
                    {
                        posY -= 5;
                        break;
                    }
                    else
                    {
                        // Effet de tremblement?
                        break;
                    }

                case Direction.Down:
                    if ((this.posY + 5) + height < yMax)
                    {
                        posY += 5;
                        break;
                    }
                    else
                    {
                        break;
                    }

                case Direction.Left:
                    if ((this.posX - 5) > 0)
                    {
                        posX -= 5;
                        break;
                    }
                    else
                    {
                        break;
                    }

                case Direction.Right:
                    if ((this.posX + 5) + width < xMax)
                    {
                        posX += 5;
                        break;
                    }
                    else
                    {
                        break;
                    }
              }
        }

        public void Shoot()
        {
            LaserShot Shot = new LaserShot((this.posX + (this.width / 2) - (LaserShot.Texture.Bounds.Width/2)), this.posY);
            Lasershots.Add(Shot);
        }

        public void Explode()
        {

        }

        /** GAME LOGIC **/

        public void Update(KeyboardState state, GraphicsDeviceManager graphics)
        {
            if (state.IsKeyDown(Keys.Up))
            {
                Move(Direction.Up, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            }
            if (state.IsKeyDown(Keys.Down))
            {
                Move(Direction.Down, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            }
            if (state.IsKeyDown(Keys.Left))
            {
                Move(Direction.Left, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            }
            if (state.IsKeyDown(Keys.Right))
            {
                Move(Direction.Right, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            }
            if (state.IsKeyDown(Keys.Space))
            {
                Shoot();
            }
            foreach (LaserShot laser in Lasershots)
            {
                laser.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
            foreach (LaserShot laser in Lasershots)
            {
                spriteBatch.Draw(LaserShot.Texture, laser.Position, Color.White);
            }

        }

    }
}
