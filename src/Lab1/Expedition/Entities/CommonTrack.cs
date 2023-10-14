using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Entities;

public class CommonTrack : BaseTrack
{
    private readonly int _dist;
    private readonly List<BaseObstacle> _obstacles;

    public CommonTrack(int dist)
    {
        _dist = dist;
        _obstacles = new List<BaseObstacle>();
    }

    public override void AddObstacle(BaseObstacle obstacle)
    {
        if (obstacle is ObstacleMeteor or ObstacleAsteroid)
        {
            _obstacles.Add(obstacle);
        }
        else
        {
            throw new InvalidDataException($"Only Meteors and Asteroids cat appear in {nameof(CommonTrack)}");
        }
    }

    public override BaseTrackResult Pass(BaseShip ship)
    {
        if (ship is null) throw new ArgumentNullException(nameof(ship));
        if (_obstacles.Select(obstacle => ship.Hit(obstacle.Damage)).Any(isAlive => !isAlive))
        {
            return new ResultShipDestroyed(" destroyed because of obstacle in common space");
        }

        BaseTrackResult res = ship.Fly(_dist);
        return res;
    }
}