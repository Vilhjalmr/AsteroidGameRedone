using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGameRedone.Models
{
    public class Level
    {
        public Texture2D Background;

        public Player Player1;

        public List<Asteroid> Asteroids;

        public Level (Texture2D bg, Player P1, List<Asteroid> listAst)
        {
            Background = bg;
            Player1 = P1;
            Asteroids = listAst;
        }
    }
}
