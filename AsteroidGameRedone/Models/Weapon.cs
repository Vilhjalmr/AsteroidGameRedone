using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGameRedone.Models
{
    abstract public class Weapon 
    {
        public Texture2D Texture;

        public Rectangle Position
        {
            get
            {
                return new Rectangle(posX, posY, Texture.Bounds.Width, Texture.Bounds.Height);
            }
        }

        protected int posX, posY;

        public Weapon()
        {
            
        }

        abstract public void Move();
        // Cas de la mine? Pas de move?


        abstract public void Update();
    }
}
