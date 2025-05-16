using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBounceLibrary.Models
{
    public class Game //guarda insieme agli altri la logica di implementazione della generazione dei vari items
    {
        public Ball Player { get; private set; }
        public PlatformGenerator Platforms { get; private set; }
        public PowerUpGenerator PowerUps { get; private set; }


        public Game(Ball player, PlatformGenerator platforms, PowerUpGenerator powerUps)
        {
            Player = player;
            Platforms = platforms;
            PowerUps = powerUps;
        }
        
        public bool HasTakenPowerUp { get; private set; }
        public void Move(int direction)
        {
            Player.Move(direction);
            // Controlla se il giocatore ha colpito una piattaforma
            foreach (var platform in Platforms.AllPlatforms)
            {
                if (Player.IsOnPlatform(platform))
                {
                    Player.PositionOfBall.Y = platform.CoordinatesOfPlatforms.Y; //- Player.Radius; // Posiziona il giocatore sopra la piattaforma
                    Player.IsJumping = false; // Ferma il movimento verticale
                    break;
                }
            }
        }
        public double JumpHeigh { get; set; } = Ball.JumpNormal;
        public void Jump(double Gravity)//sarà compito dello xaml.cs controllare la frequenza di controllo della verifica delle coincidenze
        //delle coordinate
        {
            Player.Jump(Gravity);
            if (JumpHeigh <= 0)
            {
                Player.IsJumping = false; // Ferma il movimento verticale
            }
            JumpHeigh -= Ball.BOOST_UNITY;

            // non controllo se il giocatore ha colpito una piattaforma pk in salita sono tutti non collidable
            // Controlla se il giocatore ha colpito un power-up
            foreach (var powerUp in PowerUps.AllPowerUps)
            {
                if (Player.IsOnPowerUp(powerUp))
                {
                    // Gestisci l'acquisizione del power-up
                    PowerUps.AllPowerUps.Remove(powerUp);
                    HasTakenPowerUp = true;
                    break;
                }
            }

        }
        public void GoDown()//sarà compito dello xaml.cs controllare la frequenza di controllo della verifica delle coincidenze
        //delle coordinate
        {
            Player.GoDown();

            // Controlla se il giocatore ha colpito una piattaforma
            foreach (var platform in Platforms.AllPlatforms)
            {
                if (Player.IsOnPlatform(platform))
                {
                    Player.PositionOfBall.Y = platform.CoordinatesOfPlatforms.Y+0.099; //- Player.Radius; // Posiziona il giocatore sopra la piattaforma
                    Player.IsFalling = false; // Ferma il movimento verticale
                    break;
                }
            }
        }

    }
}
