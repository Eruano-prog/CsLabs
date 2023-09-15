using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Abstract;
using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Entities;

public class CommonTrack : ITrack
{
    public int Dist { get; init; }

    PassTrackResult Pass()
    {
        
    }
}