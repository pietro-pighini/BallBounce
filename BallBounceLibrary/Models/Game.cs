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
        public List<TrampolineGenerator> Trampolines { get; private set; }
        public List<PlatformGenerator> Platforms { get; private set; }
        public List<PowerUpGenerator> PowerUps { get; private set; }
        public List<TrapGenerator> Traps { get; private set; }


        public Game(Ball player, List<TrampolineGenerator> trampolines, List<PlatformGenerator>platforms, List<PowerUpGenerator> powerUps, List<TrapGenerator> traps)
        {
            Player = player;
            Trampolines = trampolines;
            Platforms = platforms;
            PowerUps = powerUps;
            Traps = traps;
        }

    }
}
