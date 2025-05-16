using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBounceLibrary.Models
{

    public class PlatformGenerator//si occupa di generare i tipi di piattaforma e le loro coordinate
    {
        public PlatformGenerator()
        {
            AllPlatforms = Generate();
        }

        public List<Platforms> AllPlatforms { get; private set; } = new List<Platforms>();
        private readonly Random _random = new();

        public List<Platforms> Generate()
        {
            List<Platforms> platforms = new();
            double[] yLevels = { 0.8, 0.7, 0.6, 0.5, 0.4, 0.3, 0.2, 0.1 };

            foreach (double y in yLevels)
            {
                int platformCount = _random.Next(1, 3); // 1 o 2 piattaforme
                List<Platforms> platformsAtLevel = new();

                // Prima piattaforma è sempre Normal
                platformsAtLevel.Add(new Platforms(
                    new Coordinates(RandomX(), y),
                    PlatformType.Normal));

                // Se ne vogliamo una seconda, può essere di tipo casuale
                if (platformCount == 2)
                {
                    PlatformType randomType = (PlatformType)_random.Next(0, Enum.GetNames(typeof(PlatformType)).Length);

                    // Se per caso è di nuovo Normal, va benissimo
                    platformsAtLevel.Add(new Platforms(
                        new Coordinates(RandomX(), y),
                        randomType));
                }

                platforms.AddRange(platformsAtLevel);
            }

            return platforms;
        }

        private double RandomX()
        {
            // X va da 0.0 a 1.0 (valore relativo in AbsoluteLayout)
            return _random.NextDouble(); // 0.0 <= x < 1.0
        }
    }
}
