using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBounceLibrary.Models
{
    internal class PoweUpGenerator:IGeneratorOfCoord
    {
        public PowerUp PowerUp
        {
            get => default;
            set
            {
            }
        }

        public List<Coordinates> Generate()
        {
            throw new NotImplementedException();
        }
    }
}
