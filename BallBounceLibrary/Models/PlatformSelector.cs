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
        Trap,
        Trampoline
    }
    public class PlatformSelector//questa classe genera una lista di enumerativi che indica il tipo di piattaforma ció sará utile nella classe Game
    //per scegliere che piattaforme mettere.
    {
        public List<PlatformType> PlatformTypes { get; private set; } = new List<PlatformType>();
        public PlatformGenerator Platforms;
        public TrampolineGenerator Trampolines;
        public TrapGenerator Traps;
        public PlatformSelector(PlatformGenerator platforms, TrampolineGenerator trampolines, TrapGenerator traps)
        {
            Platforms = platforms;
            Trampolines = trampolines;
            Traps = traps;
        }
        private void Generate()
        {
            
        }
    }
}
