using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Entities;

public class Expedition
{
    private readonly List<AbsTrack> _trackList = new List<AbsTrack>
    {
        Capacity = 0,
    };

    public void AddTrack(AbsTrack track)
    {
        _trackList.Add(track);
    }

    public PassTrackResult Complete(AbsShip ship)
    {
        int commonFuel = 0;
        int time = 0;
        foreach (PassTrackResult res in _trackList.Select(track => track.Pass(ship)))
        {
            if (res is not Success) return res;
            commonFuel += res.FuelToPass;
            time += res.TimeToPass;
        }

        return new Success { FuelToPass = commonFuel, TimeToPass = time };
    }
}