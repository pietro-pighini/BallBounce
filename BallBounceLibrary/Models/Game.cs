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
        public List<Trampoline> Trampoline { get; private set; }
        public List<Platfrm> Platform { get; private set; }
        public List<PowerUp> PowerUps { get; private set; }
        public List<Trap> Traps { get; private set; }
        public Game(Ball player, List<Trampoline> trampolines, List<Platfrm>platforms, List<PowerUp> powerUps, List<Trap> traps)
        {
            Player = player;
            Trampoline = trampolines;
            Platform = platforms;
            PowerUps = powerUps;
            Traps = traps;
        }


    }
}
