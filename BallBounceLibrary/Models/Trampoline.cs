using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBounceLibrary.Models
{
    public class Trampoline
    {
        public Trampoline(Coordinates start) 
        {
            Start = start;
        }
        public Coordinates Start { get; private set; }

        public Game Game
        {
            get => default;
            set
            {
            }
        }
    }
}
