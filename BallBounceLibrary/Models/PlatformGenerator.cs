using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBounceLibrary.Models
{
    public class PlatformGenerator:IGeneratorOfCoord
    {
        private const int WorldHeight = 2000; // Altezza logica totale del mondo
        private const int ScreenWidth = 360;  // Larghezza logica dello schermo
        private const int MinYDistance = 40;  // Distanza minima tra una piattaforma e l'altra
        private const int MaxYDistance = 100; // Distanza massima
        private const int PlatformWidth = 80; // Larghezza di ogni piattaforma
        public List<Coordinates> platforms = new List<Coordinates>();
        public List<Coordinates> Generate()
        {
            
            //aggiungi la piattaforma iniziale in centro in basso
            platforms.Add(new Coordinates(ScreenWidth / 2 - PlatformWidth / 2, WorldHeight - 20));
            int currentY = 0;
            Random random = new Random();
            while (currentY < WorldHeight)
            {
                int y = random.Next(MinYDistance,MaxYDistance);
                currentY += y;
                int x = random.Next(20, ScreenWidth - PlatformWidth - 20); // → Random tra 20 e 260 e 80 = piattaforma 360 é la larghezza e primo 20 il margine dal bordo

                platforms.Add(new Coordinates(x, currentY));
            }
            return platforms;
        }
    }
}
