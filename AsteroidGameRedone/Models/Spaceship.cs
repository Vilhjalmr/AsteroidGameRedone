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
    public class Spaceship
    {
        public Texture2D ShipTexture;
        public Texture2D LaserTexture, MissileTexture;

        private Int32 posX, posY, width, height;

        private ContentManager Content;

        private Boolean MissileFired = false;

        public Rectangle Position
        {
            get
            {
                return new Rectangle(posX, posY, width, height);
            }
        }

        public List<Weapon> Shots { get; set; }

        // CONSTRUCTOR
        public Spaceship(int x, int y, int _width, int _height, ContentManager _content)
        {
            posX = x;
            posY = y;
            width = _width;
            height = _height;
            Shots = new List<Weapon>();
            ShipTexture = _content.Load<Texture2D>("player1");
            LaserTexture = _content.Load<Texture2D>("lase");
            MissileTexture= _content.Load<Texture2D>("missile");
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
                        posX -= 3;
                        break;
                    }
                    else
                    {
                        break;
                    }

                case Direction.Right:
                    if ((this.posX + 5) + width < xMax)
                    {
                        posX += 3;
                        break;
                    }
                    else
                    {
                        break;
                    }
              }
        }

        public void ShootLaser()
        {
            LaserShot LeftLS= new LaserShot((this.posX + (this.width / 2) - (this.width / 3 ) - (LaserTexture.Bounds.Width/2)), this.posY-(this.height/3), LaserTexture);
            LaserShot RightLS = new LaserShot((this.posX + (this.width / 2) + (this.width / 3 ) - (LaserTexture.Bounds.Width/2)), this.posY - (this.height / 3), LaserTexture);
            Shots.Add(LeftLS);
            Shots.Add(RightLS);
        }

        public void ShootMissile()
        {
            Missile Missile = new Missile((this.posX + (this.width / 2) - (MissileTexture.Bounds.Width / 2)), this.posY, MissileTexture);
            Shots.Add(Missile);
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
                ShootLaser();
            }
            if (state.IsKeyDown(Keys.LeftControl) && !MissileFired)
            {
                ShootMissile();
                MissileFired = true;
            }
            if (state.IsKeyUp(Keys.LeftControl))
            {
                MissileFired = false;
            }
            foreach (Weapon weapon in Shots)
            {
                weapon.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ShipTexture, Position, Color.White);
            foreach (Weapon weapon in Shots)
            {
                spriteBatch.Draw(weapon.Texture, weapon.Position, Color.White);
            }

        }

    }
}
