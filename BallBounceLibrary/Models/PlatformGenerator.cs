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
            Random rand = new Random();
            List<Platforms> platforms = new List<Platforms>();

            double startY = 0.8;
            double stepY = 0.1;
            int numLevels = 8;

            for (int i = 0; i < numLevels; i++)
            {
                double y = startY - (i * stepY);
                List<Platforms> levelPlatforms = new List<Platforms>();
                if (i % 2 == 0)
                {
                    // Livello con UNA piattaforma al centro (X tra 0.45 e 0.55)
                    double x = rand.NextDouble() * 0.1 + 0.45;
                    PlatformType type = PlatformType.Normal; // sempre normal
                    levelPlatforms.Add(new Platforms(new Coordinates(x, y), type));
                }
                else
                {
                    // Livello con DUE piattaforme agli estremi (X = 0.1 e 0.9)
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
            // Genera X tra 0.1 e 0.9 per evitare piattaforme troppo ai margini
            return 0.1 + _random.NextDouble() * 0.8;
        }

    }
}
