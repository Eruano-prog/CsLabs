using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Entities;

public class Expedition
{
    private readonly List<BaseTrack> _track;
    private readonly BaseShip _ship;

    public Expedition(BaseShip ship)
    {
        _ship = ship;
        _track = new List<BaseTrack>();
    }

    public Expedition(BaseTrack track, BaseShip ship)
        : this(ship)
    {
        _track = new List<BaseTrack>() { track };
    }

    public Expedition(Collection<BaseTrack> tracks, BaseShip ship)
        : this(ship)
    {
        if (tracks == null) return;
        foreach (BaseTrack track in tracks)
        {
            _track.Add(track);
        }
    }

    public void AddTrack(BaseTrack track)
    {
        _track.Add(track);
    }

    public BaseTrackResult Complete()
    {
        int fuel = 0;
        int time = 0;
        foreach (BaseTrack track in _track)
        {
            BaseTrackResult res = track.Pass(_ship);
            if (res is not ResultSuccess) return res;
            fuel += res.FuelToPass;
            time += res.TimeToPass;
        }

        return new ResultSuccess { FuelToPass = fuel, TimeToPass = time };
    }
}