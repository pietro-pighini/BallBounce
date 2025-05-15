using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBounceLibrary.Models
{

    public class PlatformGenerator//si occupa di generare i tipi di piattaforma e le loro coordinate
    {
        private const int WorldHeight = 2000; // Altezza logica totale del mondo
        private const int ScreenWidth = 360;  // Larghezza logica dello schermo
        private const int MinYDistance = 40;  // Distanza minima tra una piattaforma e l'altra
        private const int MaxYDistance = 100; // Distanza massima
        private const int PlatformWidth = 80; // Larghezza di ogni piattaforma
        public PlatformGenerator()
        {
            AllPlatforms = Generate();
        }

        public List<Platforms> AllPlatforms { get; private set; } = new List<Platforms>();
        public List<Platforms> Generate()
        {
            List<Platforms> platforms = new List<Platforms>();
            int currentY = 0;
            Random random = new Random();

            while (currentY < WorldHeight)
            {
                int yOffset = random.Next(MinYDistance, MaxYDistance);
                currentY += yOffset;

                int x = random.Next(20, ScreenWidth - PlatformWidth - 20);

                PlatformType type;

                int chance = random.Next(0, 100);
                if (chance < 10) // 10% trappola
                    type = PlatformType.Trap;
                else if (chance < 20) // 10% trampolino
                    type = PlatformType.Trampoline;
                else
                    type = PlatformType.Normal;

                platforms.Add(new Platforms(new Coordinates(x, currentY), type));
            }
            return platforms;

        }
    }
}
