using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGameRedone.Models
{
    class LaserShot
    {
        public static Texture2D Texture;

        public Rectangle Position
        {
            get
            {
                return new Rectangle(posX, posY, Texture.Bounds.Width, Texture.Bounds.Height);
            }
        }

        private int posX, posY; 

        public LaserShot(int x, int y)
        {
            posX = x;
            posY = y;
        }

        public void Move()
        {
            if (this.posY > 0 - Texture.Bounds.Height)
            {
                this.posY -= 15;
            }
            else
            {
                
            }
        }

        public void Update()
        {
            Move();
        }
    }
}
