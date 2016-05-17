using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGameRedone.Models
{
    public class Asteroid
    {
        public static Texture2D Texture;
        /* Fait par oli
        private Game1 game;

        public Game1 Game
        {
            get { return game; }
            set { game = value; }
        }
        */
        public Rectangle Position
        {
            get
            {
                return new Rectangle(posX, posY, width, height);
            }
        }

        private int posX, posY, width, height;

        private int hitPoints;

        public Asteroid(int x, int y, int w, int h, int hp)
        {
            // Oli this.game = game;
            posX = x;
            posY = y;
            width = w;
            height = h;
            hitPoints = hp;
        }

        public void Move(Random rnd)
        {
            posY += rnd.Next(0, 5);
        }

        public void Explode()
        {

        }

        public void Update(Random rnd, Spaceship ship)
        {
            Move(rnd);
            foreach (Weapon weapon in ship.Shots)
            {
                if (this.Position.Intersects(weapon.Position))
                {
                    // Remove shot, destroy asteroid, increment score by asteroid's value
                    Explode();
                }
            }
            
        }

        public void Draw()
        {

        }
    }
}
