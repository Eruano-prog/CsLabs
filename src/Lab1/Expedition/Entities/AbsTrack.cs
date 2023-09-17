using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Entities;

public abstract class AbsTrack
{
    public int Dist { get; init; }
    public abstract PassTrackResult Pass(AbsShip ship);
}