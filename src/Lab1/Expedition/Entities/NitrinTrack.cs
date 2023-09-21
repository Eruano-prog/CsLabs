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

    public override void AddObstacle(AbsObstacle obj)
    {
        if (obj is not Whale)
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

        if (!ship.IsOk())
        {
            var pass = new ShipDestroyed() { Message = $"{nameof(ship)} Crushed because of whales" };
            return pass;
        }

        if (!ship.FlyThroughNitro())
        {
            return new ShipLost() { Message = $"{nameof(ship)} lost because it can`t pass through Nitrin track" };
        }

        PassTrackResult res = ship.Fly(_dist);
        return res;
    }
}