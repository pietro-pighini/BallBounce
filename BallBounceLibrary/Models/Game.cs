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
        public bool IsJumping { get; private set; }
        public bool HasTakenPowerUp { get; private set; }
        public void Jump(double Gravity)//sarà compito dello xaml.cs controllare la frequenza di controllo della verifica delle coincidenze
        //delle coordinate
        {
            Player.Jump(Gravity);
            // Controlla se il giocatore ha colpito una piattaforma
            foreach (var platform in Platforms.AllPlatforms)
            {
                if (Player.IsOnPlatform(platform))
                {
                    Player.PositionOfBall.Y = platform.CoordinatesOfPlatforms.Y; //- Player.Radius; // Posiziona il giocatore sopra la piattaforma
                    IsJumping = false; // Ferma il movimento verticale
                    break;
                }
            }
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
        
    }
}
