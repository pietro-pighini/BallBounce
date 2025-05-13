using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBounceLibrary.Models
{
    public class PowerUpGenerator(PlatformGenerator platforms):IGeneratorOfCoord
    {
        private const int WorldHeight = 2000; // Altezza logica totale del mondo
        private const int ScreenWidth = 360;  // Larghezza logica dello schermo
        private const int MinYDistance = 40;  // Distanza minima tra una piattaforma e l'altra
        private const int MaxYDistance = 100; // Distanza massima
        private const int PlatformWidth = 80; // Larghezza di ogni piattaforma
        private const int PowerUpWidth = 20; // Larghezza di ogni powerup
        private PlatformGenerator platforms;
        public List<Coordinates> Generate()
        {
            //il powerup viene generato sopra le piattaforme
            List<Coordinates> PowerUps = new List<Coordinates>();
            foreach(var platform in platforms.platforms)
            {
                PowerUps.Add(new Coordinates((platform.X + PlatformWidth / 2 - PowerUpWidth / 2) ,(platform.Y - 20)));//la x lo centra e la y é distante di 20 di altezza.
            }
            return PowerUps;
        }
    }
}