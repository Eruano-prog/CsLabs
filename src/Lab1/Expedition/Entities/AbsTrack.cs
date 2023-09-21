using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Entities;

public abstract class AbsTrack
{
    public abstract PassTrackResult Pass(AbsShip ship);
    public abstract void AddObstacle(AbsObstacle obj);
}