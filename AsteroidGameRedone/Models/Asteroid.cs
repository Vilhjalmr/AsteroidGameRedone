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

        public void Update()
        {

        }

        public void Draw()
        {

        }
    }
}
