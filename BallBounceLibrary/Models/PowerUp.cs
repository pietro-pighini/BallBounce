using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBounceLibrary.Models
{
    public enum PowerUpEffect
    {
        COLOR_CHANGE,LOWER_JUMP,INVULNERABILITY
    }
    public class PowerUp
    {
        public PowerUp(Coordinates coordOfPowerUp)
        {
            CoordOfPowerUp = coordOfPowerUp;
        }
        public Coordinates CoordOfPowerUp { get; private set; }

        public Game Game
        {
            get => default;
            set
            {
            }
        }
    }
}
