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
        /*
        public void Jump(double Gravity)
        {
            try
            {
               Player.Jump(Gravity);
                // Controlla se il giocatore ha colpito una piattaforma
                foreach (var platform in Platforms.AllPlatforms)
                {
                    if (Player.IsOnPlatform(platform))
                    {
                        Player.Y = platform.CoordinatesOfPlatforms.Y - Player.Radius; // Posiziona il giocatore sopra la piattaforma
                        Player.VelocityY = 0; // Ferma il movimento verticale
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
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during jump: {ex.Message}");
            }
        }
        */
    }
}
