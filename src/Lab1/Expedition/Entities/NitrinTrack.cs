using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Entities;

public class NitrinTrack : BaseTrack
{
    private readonly List<BaseObstacle> _obstacles;
    private readonly int _dist;

    public NitrinTrack(int dist)
    {
        _dist = dist;
        _obstacles = new List<BaseObstacle>();
    }

    public override void AddObstacle(BaseObstacle obj)
    {
        if (obj is not ObstacleWhale)
        {
            throw new InvalidDataException($"Only Whales can appear in {nameof(HighDensityTrack)}");
        }

        _obstacles.Add(obj);
    }

    public override BaseTrackResult Pass(BaseShip ship)
    {
        Debug.Assert(ship != null, nameof(ship) + " != null");
        if (!ship.AntiNitro)
        {
            foreach (BaseObstacle obstacle in _obstacles)
            {
                ship.Hit(obstacle.Damage);
            }
        }

        if (!ship.IsOk())
        {
            var pass = new ResultShipDestroyed() { Message = $"{nameof(ship)} Crushed because of whales" };
            return pass;
        }

        if (!ship.FlyThroughNitro())
        {
            return new ResultShipLost() { Message = $"{nameof(ship)} lost because it can`t pass through Nitrin track" };
        }

        BaseTrackResult res = ship.Fly(_dist);
        return res;
    }
}