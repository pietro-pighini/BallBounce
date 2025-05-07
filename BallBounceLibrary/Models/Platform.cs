using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBounceLibrary.Models
{
    public class Platfrm
    {
        public Platfrm(Coordinates start,Coordinates end)
        {
            Start = start;
            End = end;
        }
        public Coordinates Start { get; private set; }
        public Coordinates End { get; private set; }

        public Game Game
        {
            get => default;
            set
            {
            }
        }
    }
}
