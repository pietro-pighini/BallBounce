using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBounceLibrary.Models
{
    public interface IGeneratorOfCoord
    {

        public Coordinates Generate();
    }
}
