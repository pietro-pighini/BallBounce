using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BallBounceLibrary.Models
{
    public enum Effect
    {
        Normal,
        JumpBoost
    }
    
    public class Ball
    {
        // DATO CHE NON SI POSSONO FARE ENUMERATIVI DOUBLE
        public static readonly double JumpBoost = 0.37;
        public static readonly double JumpPenalty = 0.06;
        public static readonly double JumpNormal = 0.16;
        // DATO CHE NON SI POSSONO FARE ENUMERATIVI DOUBLE
        //VOLEVO FARLI COSTANTI MA NON SI PUÓ FARE WTF
        public Ball() { }
        public Ball(Coordinates positionOfBall, String name)
        {
            PositionOfBall = positionOfBall;
            if (string.IsNullOrEmpty(name)) { name = "user"; }
            Username = name;
        }
        public const double BOOST_UNITY = 0.05;
        public Coordinates PositionOfBall { get; set; }
        public Effect? CurrentEffect { get; set; }
        public void Move(int direction)
        {
            if (direction != 1 && direction != -1) { throw new ArgumentOutOfRangeException("invalid direction"); }
            //-1 sinistra 1 destra
            if (direction == 1)
            {
                PositionOfBall.X += 0.1;
            }
            else//-1 va a sinistra
            {
                PositionOfBall.X -= 0.1;
            }
        }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public string Username { get; set; }
        public bool IsFalling { get; set; }
        public bool IsJumping { get; set; }
        public bool IsOnTrampoline { get; set; }
        public bool IsOnTrap { get; set; }
        public bool IsOnNormal { get; set; }
        public bool IsOnLastPlatform { get; set; }
        public void Jump()//nello xaml.cs va controllato il boost
        {
            PositionOfBall.Y -= BOOST_UNITY;
            IsJumping = true;
            IsFalling = false;
            //@TODO nel metodo del GamePage.xaml.cs dove fai il salto aggiungi un for che richiama jump fino a quando non satura la gravitá che aumenta di 0.5 ogni volta, partendo da 0.5
        }
        public void GoDown()
        {
            PositionOfBall.Y += BOOST_UNITY;
        }
        public bool IsOnPlatform(Platforms platform)
        {
            bool result;
            double dx = Math.Abs(PositionOfBall.X - platform.CoordinatesOfPlatforms.X);
            double dy = Math.Abs(PositionOfBall.Y - platform.CoordinatesOfPlatforms.Y);  
            if(dx <= 0.3 && dy <= 0.1)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public bool IsOnPowerUp(Coordinates powerup)
        {
            //da aggiustare la condizione
            if ((PositionOfBall.X <= powerup.X + 0.08) && (PositionOfBall.X >= powerup.X + 0.08) && (PositionOfBall.Y <= powerup.Y + 0.08) && (PositionOfBall.Y >= powerup.Y + 0.08))
            {
                return true;
            }
            return false;
        }
    }
}
