using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Entities;

public class Expedition
{
    private readonly AbsTrack _track;
    private readonly AbsShip _ship;

    public Expedition(AbsTrack track, AbsShip ship)
    {
        _track = track;
        _ship = ship;
    }

    public void AddObstacle(AbsObstacle obj)
    {
        _track?.AddObstacle(obj);
    }

    public PassTrackResult Complete()
    {
        int fuel = 0;
        int time = 0;
        PassTrackResult res = _track.Pass(_ship);
        if (res is not Success) return res;
        fuel += res.FuelToPass;
        time += res.TimeToPass;

        return new Success { FuelToPass = fuel, TimeToPass = time };
    }
}