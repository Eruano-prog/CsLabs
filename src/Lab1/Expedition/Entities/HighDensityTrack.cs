using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Entities;

public class HighDensityTrack : AbsTrack
{
    private readonly List<AbsObstacle> _obstacles;
    private readonly int _dist;

    public HighDensityTrack(int dist)
    {
        _dist = dist;
        _obstacles = new List<AbsObstacle>();
    }

    public void AddObstacle(AbsObstacle obj)
    {
        if (obj is not AntimaterFlare)
        {
            throw new InvalidDataException($"Only Antimater Flares can appear in {nameof(HighDensityTrack)}");
        }

        _obstacles.Add(obj);
    }

    public override PassTrackResult Pass(AbsShip ship)
    {
        Debug.Assert(ship != null, nameof(ship) + " != null");
        for (int i = 0; i < _obstacles.Count; i++)
        {
            if (ship.RejectFlare())
            {
                return new CrewDied
                {
                    Message = "Could not reject antimater flare",
                };
            }
        }

        PassTrackResult res = ship.Warp(_dist);
        return res;
    }
}