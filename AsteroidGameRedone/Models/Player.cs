namespace AsteroidGameRedone.Models
{
    public class Player
    {
        public Spaceship PlayersShip;

        public int Score;

        public Player (Spaceship ship)
        {
            PlayersShip = ship;
            Score = 0;
        }
    }
}