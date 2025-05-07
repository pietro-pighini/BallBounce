using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBounceLibrary.Models
{
    public class Coordinates
    {
        public Coordinates(int x, int y)
        {
            //no controlli, tutte accettabili
        }
        public int X { get; private set; }
        public int Y { get; private set; }

        internal PlatformGenerator PlatformGenerator
        {
            get => default;
            set
            {
            }
        }

        internal TrampolineGenerator TrampolineGenerator
        {
            get => default;
            set
            {
            }
        }

        internal PoweUpGenerator PoweUpGenerator
        {
            get => default;
            set
            {
            }
        }

        public TrapGenerator TrapGenerator
        {
            get => default;
            set
            {
            }
        }
    }
}
