using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBounceLibrary.Models
{
    public class TrapGenerator:IGeneratorOfCoord
    {
        public Trap Trap
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
