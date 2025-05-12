using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBounceLibrary.Models
{
    internal class TrampolineGenerator:IGeneratorOfCoord
    {
        public Trampoline Trampoline
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
