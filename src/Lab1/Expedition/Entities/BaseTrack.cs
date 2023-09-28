using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Entities;

public abstract class BaseTrack
{
    public abstract BaseTrackResult Pass(BaseShip ship);
    public abstract void AddObstacle(BaseObstacle obstacle);
}