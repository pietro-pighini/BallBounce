using System;
using System.Collections.Generic;

namespace BallBounceLibrary.Models
{
    public class PlatformGenerator
    {
        public PlatformGenerator()
        {
            AllPlatforms = Generate();
        }

        public List<Platforms> AllPlatforms { get; private set; } = new List<Platforms>();
        private readonly Random _random = new();

        public List<Platforms> Generate()
        {
            Random rand = new Random();
            List<Platforms> platforms = new List<Platforms>();

            double startY = 0.85;// Inizia sopra la piattaforma iniziale (che sta a 0.999)
            int numLevels = 8;
            double stepY = startY / (numLevels - 1); // Spaziatura uniforme

            for (int i = 0; i < numLevels; i++)
            {
                double y = startY - (i * stepY);
                if (y <= 0.05) break; // evita di andare fuori schermo

                List<Platforms> levelPlatforms = new List<Platforms>();

                if (i % 2 == 0)
                {
                    // Piattaforma singola centrata
                    double x = rand.NextDouble() * 0.1 + 0.45;
                    PlatformType type = PlatformType.Normal;
                    levelPlatforms.Add(new Platforms(new Coordinates(x, y), type));
                }
                else
                {
                    // Due piattaforme agli estremi
                    double[] xPositions = { 0.001, 0.999 };
                    bool hasNormal = false;

                    for (int j = 0; j < 2; j++)
                    {
                        PlatformType type = (PlatformType)rand.Next(0, 3);
                        if (!hasNormal && j == 1) type = PlatformType.Normal;
                        if (type == PlatformType.Normal) hasNormal = true;

                        levelPlatforms.Add(new Platforms(new Coordinates(xPositions[j], y), type));
                    }
                }

                platforms.AddRange(levelPlatforms);
            }

            return platforms;
        }

        private double RandomX()
        {
            return 0.1 + _random.NextDouble() * 0.8;
        }
    }
}
