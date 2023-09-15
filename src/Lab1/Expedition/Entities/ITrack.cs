using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Abstract;

public interface ITrack
{
    public int Dist { get; init; }
    PassTrackResult Pass(sh);
}