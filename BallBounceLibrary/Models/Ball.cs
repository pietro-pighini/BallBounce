using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BallBounceLibrary.Models
{
    public enum BoostMaxHeigh
    {
        JumpBoost = -280,
        Normal= -140,
        Penalty = +10
    }
    public enum Effect
    {
        Normal,
        JumpBoost
    }
    public class Ball
    {
        public Ball(Coordinates positionOfBall, String Name)
        {
            PositionOfBall = positionOfBall;
        }
        public const int BOOST_UNITY = 12;
        public Coordinates PositionOfBall { get; private set; }
        public Effect? CurrentEffect { get; set; }
        public void Move(int direction)
        {
            if (direction != 1 && direction != -1) { throw new ArgumentOutOfRangeException("invalid direction"); }
            //-1 sinistra 1 destra
            if (direction == 1)
            {
                PositionOfBall.X += 5;
            }
            else//-1 va a sinistra
            {
                PositionOfBall.Y -= 5;
            }

        }
        public void Jump(double Gravity)//nello xaml.cs va controlato il boost
        {
            PositionOfBall.Y -= BOOST_UNITY;
            //@TODO nel metodo del GamePAge.xaml.cs dove fai il salto aggiungi un for che richiama jump finoa a quando non satura la gravitá che aumenta di 0.5 ogni volta, partendo da 0.5
        }
        public void GoDown(float pixels) 
        {
            PositionOfBall.Y += pixels;
            if (PositionOfBall.Y > 2000) // Supponiamo che 2000 sia l'altezza massima
            {
                PositionOfBall.Y = 2000; // Limita la Y alla massima altezza
            }
        }
    }
}
