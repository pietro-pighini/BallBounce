using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBounceLibrary.Models
{
    public class Ball
    {
        public Ball(Coordinates positionOfBall,String Name)
        {
            PositionOfBall = positionOfBall;
        }
        public Coordinates PositionOfBall {get;private set; }
        internal Effect? CurrentEffect {get;set;}

        public Game Game
        {
            get => default;
            set
            {
            }
        }
    }
}
