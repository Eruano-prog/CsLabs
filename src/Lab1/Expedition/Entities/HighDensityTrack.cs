using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Entities;

public class HighDensityTrack : BaseTrack
{
    private readonly List<BaseObstacle> _obstacles;
    private readonly int _dist;

    public HighDensityTrack(int dist)
    {
        _dist = dist;
        _obstacles = new List<BaseObstacle>();
    }

    public override void AddObstacle(BaseObstacle obj)
    {
        if (obj is not AntimaterFlare)
        {
            throw new InvalidDataException($"Only Antimater Flares can appear in {nameof(HighDensityTrack)}");
        }

        _obstacles.Add(obj);
    }

    public override BaseTrackResult Pass(BaseShip ship)
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

        BaseTrackResult res = ship.Warp(_dist);
        return res;
    }
}