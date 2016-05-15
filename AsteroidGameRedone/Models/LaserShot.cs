﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGameRedone.Models
{
    public class LaserShot : Weapon
    { 
        public LaserShot(int x, int y, Texture2D _texture)
        {
            posX = x;
            posY = y;
            Texture = _texture;
        }

        public override void Move()
        {
            if (this.posY > 0 - Texture.Bounds.Height)
            {
                this.posY -= 15;
            }
            else
            {
                
            }
        }

        public override void Update()
        {
            Move();
        }
    }
}
