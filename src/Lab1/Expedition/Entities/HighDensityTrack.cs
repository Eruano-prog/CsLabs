using System.Collections.Generic;
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

    public override void AddObstacle(BaseObstacle obstacle)
    {
        if (obstacle is not ObstacleAntimaterFlare)
        {
            throw new InvalidDataException($"Only Antimater Flares can appear in {nameof(HighDensityTrack)}");
        }

        _obstacles.Add(obstacle);
    }

    public override BaseTrackResult Pass(BaseShip ship)
    {
        if (ship is null)
        {
            throw new InvalidDataException($"{nameof(ship)} can`t be null");
        }

        for (int i = 0; i < _obstacles.Count; i++)
        {
            if (ship.RejectFlare())
            {
                return new ResultCrewDied("Could not reject antimater flare");
            }
        }

        BaseTrackResult res = ship.Warp(_dist);
        return res;
    }
}