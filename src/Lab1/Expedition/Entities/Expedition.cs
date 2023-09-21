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

    public PassTrackResult Complete()
    {
        int commonFuel = 0;
        int time = 0;
        PassTrackResult res = _track.Pass(_ship);
        if (res is not Success) return res;
        commonFuel += res.FuelToPass;
        time += res.TimeToPass;

        return new Success { FuelToPass = commonFuel, TimeToPass = time };
    }
}