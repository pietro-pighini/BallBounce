using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBounceLibrary.Models
{
    public class PowerUpGenerator:IGeneratorOfCoord
    {
        private const int WorldHeight = 2000; // Altezza logica totale del mondo
        private const int ScreenWidth = 360;  // Larghezza logica dello schermo
        private const int MinYDistance = 40;  // Distanza minima tra una piattaforma e l'altra
        private const int MaxYDistance = 100; // Distanza massima
        private const int PlatformWidth = 80; // Larghezza di ogni piattaforma
        private const int PowerUpWidth = 20; // Larghezza di ogni powerup
        public List<Coordinates> AllPowerUps { get; private set; } = new List<Coordinates>();
        public List<Platforms> Platforms { get; private set; } = new List<Platforms>();
        public PowerUpGenerator(List<Platforms> platforms)
        {
            Platforms = platforms;
            AllPowerUps = Generate();
        }
        public List<Coordinates> Generate()
        {
            //il powerup viene generato sopra le piattaforme
            List<Coordinates> powerUps = new List<Coordinates>();
            Random random = new Random();
            foreach (var platform in Platforms)
            {
                if (random.Next(0, 100) < 30) // 30% probabilità di spawnare powerup
                {
                    double powerUpX = platform.CoordinatesOfPlatforms.X + PlatformWidth / 2 - PowerUpWidth / 2;
                    double powerUpY = platform.CoordinatesOfPlatforms.Y - 0.020;
                    powerUps.Add(new Coordinates(powerUpX,powerUpY));
                }
            }
            return powerUps;
        }
    }
}