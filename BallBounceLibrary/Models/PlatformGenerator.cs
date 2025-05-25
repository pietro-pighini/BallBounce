using System;
using System.Collections.Generic;

namespace BallBounceLibrary.Models
{
    public class PlatformGenerator
    {
        public PlatformGenerator()
        {
            //devo crearne 10 in totale, 4 volte singola e 3 volte doppia
            for (int i = 0; i < _maxPlatforms; i++)
            {
                if (i % 2 == 0) // Genera piattaforme singole
                {
                    Generate(true,(_yLevel));
                }
                else // Genera piattaforme doppie
                {
                    Generate(false,(_yLevel));
                }
                _yLevel -= 0.2; // Abbassa il livello Y per la prossima piattaforma
            }
        }
        private readonly int _maxPlatforms = 5; // Numero massimo di piattaforme da generare
        private double _yLevel = 0.855; // Livello Y iniziale per la generazione delle piattaforme
        public List<Platforms> AllPlatforms { get; private set; } = new List<Platforms>();
        private readonly Random _random = new();

        public void Generate(bool isOne,double yLevel)
        {
            Random rand = new Random();
            List<Platforms> platforms = new List<Platforms>();

            double startY = 0.85;// Inizia sopra la piattaforma iniziale (che sta a 0.999)
            int numLevels = 8;
            List<Platforms> levelPlatforms = new List<Platforms>();
            platforms.AddRange(levelPlatforms);
            if (isOne)
            {
                //devo generare una sola piattaforma, a livello y
                //la x deve essere 0.5
                Coordinates coordinates = new Coordinates(0.5, yLevel);
                PlatformType type = (PlatformType)_random.Next(0, 3); // Genera un tipo di piattaforma casuale compresa la trappola
                Platforms platform = new Platforms(coordinates, type);
                AllPlatforms.Add(platform);
            }
            else
            {
                //due piattaforme
                //la prima piattaforma deve essere a 0.1, la seconda a 0.9
                Coordinates coordinates1 = new Coordinates(0.1, yLevel);
                PlatformType type1 = (PlatformType)_random.Next(0, 3); // Genera un tipo di piattaforma casuale
                Platforms platform1 = new Platforms(coordinates1, type1);
                AllPlatforms.Add(platform1);
                Coordinates coordinates2 = new Coordinates(0.9, yLevel);
                PlatformType type2 = (PlatformType)_random.Next(0, 3); // Genera un tipo di piattaforma casuale
                Platforms platform2 = new Platforms(coordinates2, type2);
                AllPlatforms.Add(platform2);
            }

        }
    }
}
