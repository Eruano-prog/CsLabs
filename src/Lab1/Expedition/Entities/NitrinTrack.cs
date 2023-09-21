using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Entities;

public class NitrinTrack : AbsTrack
{
    private readonly List<AbsObstacle> _obstacles;
    private readonly int _dist;

    public NitrinTrack(int dist)
    {
        _dist = dist;
        _obstacles = new List<AbsObstacle>();
    }

    public void AddObstacle(AbsObstacle obj)
    {
        if (obj is Whale)
        {
            throw new InvalidDataException($"Only Whales can appear in {nameof(HighDensityTrack)}");
        }

        _obstacles.Add(obj);
    }

    public override PassTrackResult Pass(AbsShip ship)
    {
        Debug.Assert(ship != null, nameof(ship) + " != null");
        if (!ship.AntiNitro)
        {
            foreach (AbsObstacle obstacle in _obstacles)
            {
                ship.Hit(obstacle.Damage);
            }
        }

        PassTrackResult res = ship.Fly(_dist);
        return res;
    }
}