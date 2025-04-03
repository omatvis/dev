using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared;

[Flags]
public enum WondersOfTheAncientWorld: byte
{
    GreatPyramidOfGiza = 0b000000001,
    HangingGardensOfBabylon = 0b00000010,
    StatueOfZeusAtOlympia = 0b00000100,
    TempleOfArtemisAtEphesus = 0b00001000,
    MausoleumAtHalicarnassus = 0b00010000,
    ColossusOfRhodes = 0b00100000,
    LighthouseOfAlexandria = 0b01000000
}
