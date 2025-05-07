using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBounceLibrary.Models
{
    internal class PlatformGenerator:IGeneratorOfCoord
    {
        public Platfrm Platfrm
        {
            get => default;
            set
            {
            }
        }

        public Coordinates Generate()
        {
            throw new NotImplementedException();
        }
    }
}
