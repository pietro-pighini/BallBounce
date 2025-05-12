using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BallBounceLibrary.Models
{
    enum BoostMaxHeigh
    {
        JumpBoost = -280,
        Normal= -140,
        Penalty = +10
    }
    public class Ball
    {
        public Ball(Coordinates positionOfBall,String Name)
        {
            PositionOfBall = positionOfBall;
        }
        public const int BOOST_UNITY = 12;
        public Coordinates PositionOfBall {get;private set; }
        internal Effect? CurrentEffect {get;set;}
        
        public Game Game
        {
            get => default;
            set
            {
            }
        }
        public void Move(int direction)
        {
            if (direction != 1 && direction != -1) { throw new ArgumentOutOfRangeException("invalid direction"); }
            //-1 sinistra 1 destra
            if (direction == 1)
            {
                PositionOfBall.X += 5 ;
            }
            else
            {
                PositionOfBall.Y -= 5 ;
            }
            
        }
        public void Jump(bool? boost,double Gravity)
        {
            if (boost == null)//jump normale
            {
                PositionOfBall.Y -= BOOST_UNITY;
            }
        }
        //@TODO nel metodo del GamePAge.xaml.cs dove fai il salto aggiungi un for che richiama jump finoa a quando non satura la gravitá che aumenta di 0.5 ogni volta, partendo da 0.5
    }
}
