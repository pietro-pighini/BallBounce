using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBounceLibrary.Models
{
    public enum PlatformType
    {
        Normal,
        Trampoline,
        Trap
    }
    public class Platforms
    {
        public Coordinates CoordinatesOfPlatforms { get; private set; }
        public PlatformType TypeOfPlatform { get; private set; }
        public Platforms(Coordinates coordinatesOfPlatforms, PlatformType typeOfPlatform) 
        {
            CoordinatesOfPlatforms = coordinatesOfPlatforms;
            TypeOfPlatform = typeOfPlatform;
        }

    }
}
