using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Abstract;

public abstract class AbsTrack
{
    public int Dist { get; init; }
    PassTrackResult virtual Pass(AbsShip ship);
}