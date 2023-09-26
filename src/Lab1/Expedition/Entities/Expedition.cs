using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Entities;

public class Expedition
{
    private readonly List<AbsTrack> _track;
    private readonly AbsShip _ship;

    public Expedition(AbsShip ship)
    {
        _ship = ship;
        _track = new List<AbsTrack>();
    }

    public Expedition(AbsTrack track, AbsShip ship)
        : this(ship)
    {
        _track = new List<AbsTrack>() { track };
    }

    public Expedition(Collection<AbsTrack> tracks, AbsShip ship)
        : this(ship)
    {
        if (tracks == null) return;
        foreach (AbsTrack track in tracks)
        {
            _track.Add(track);
        }
    }

    public void AddTrack(AbsTrack track)
    {
        _track.Add(track);
    }

    public PassTrackResult Complete()
    {
        int fuel = 0;
        int time = 0;
        foreach (AbsTrack track in _track)
        {
            PassTrackResult res = track.Pass(_ship);
            if (res is not Success) return res;
            fuel += res.FuelToPass;
            time += res.TimeToPass;
        }

        return new Success { FuelToPass = fuel, TimeToPass = time };
    }
}