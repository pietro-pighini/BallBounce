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
        public void Jump()//sarà compito dello xaml.cs controllare la frequenza di controllo della verifica delle coincidenze
        //delle coordinate
        {
            Player.Jump();
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
            int penultima = Platforms.AllPlatforms.Count() - 2;//la metto qui per non calcolarla mille volte inutilmente
            // Controlla se il giocatore ha colpito una piattaforma
            foreach (var platform in Platforms.AllPlatforms)
            {
                if (Player.IsOnPlatform(platform))
                {
                    Player.PositionOfBall.X= platform.CoordinatesOfPlatforms.X;
                    Player.PositionOfBall.Y = platform.CoordinatesOfPlatforms.Y-0.09; //- Player.Radius; // Posiziona il giocatore sopra la piattaforma
                    Player.IsFalling = false; // Ferma il movimento verticale
                    if (Platforms.AllPlatforms.Last() == platform || Platforms.AllPlatforms[penultima] == platform)//se é nell'ultima o nella penultima piattaforma
                    {
                        Player.IsOnLastPlatform = true;
                    }
                    else
                    {
                        Player.IsOnLastPlatform = false;
                    }
                    checkTypeOfPlatform(platform);
                    break;
                }
            }
        }
        private void checkTypeOfPlatform(Platforms platform)
        {
            if (platform.TypeOfPlatform == PlatformType.Normal)
            {
                Player.IsOnNormal = true;
                Player.IsOnTrap = false;
                Player.IsOnTrampoline = false;
                JumpHeigh = Ball.JumpNormal;
            }
            else if (platform.TypeOfPlatform == PlatformType.Trampoline)
            {
                Player.IsOnTrap = false;
                Player.IsOnNormal = false;
                Player.IsOnTrampoline = true;
                JumpHeigh = Ball.JumpBoost; // Aumenta l'altezza del salto
            }
            else if (platform.TypeOfPlatform == PlatformType.Trap)
            {
                Player.IsOnTrap = true;
                Player.IsOnNormal = false;
                Player.IsOnTrampoline = false;
                JumpHeigh = Ball.JumpPenalty; // Diminuisci l'altezza del salto
            }
        }

    }
}
