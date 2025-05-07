using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBounceLibrary.Models
{
    public class Trap
    {
        public Trap(int start) 
        { 
            Start = start;
        }
        public int Start { get; private set; }

        public Game Game
        {
            get => default;
            set
            {
            }
        }
    }
}
