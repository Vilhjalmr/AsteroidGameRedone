﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace AsteroidGameRedone.Models
{
    public class HUD
    {
        private SpriteFont font;
        private int score = 0;

        

        public HUD(ContentManager _content)
        {
            font = _content.Load<SpriteFont>("Score");
        }

        public void Update(int val)
        {
            // valeur dépend du type d'ennemi
            score += val;
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            spriteBatch.DrawString(font, "Score: " + score, new Vector2(50, graphics.PreferredBackBufferHeight - 50), Color.White);
        }
    }
}
