using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBounceLibrary.Models
{
    public class Coordinates
    {
        public Coordinates(float x, float y)
        {
            //no controlli, tutte accettabili
        }
        public float X { get;  set; }
        public float Y { get;  set; }
    }
}
