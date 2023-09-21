using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Entities;

public class CommonTrack : AbsTrack
{
    private readonly int _dist;
    private readonly List<AbsObstacle> _obstacles;

    public CommonTrack(int dist)
    {
        _dist = dist;
        _obstacles = new List<AbsObstacle>();
    }

    public override void AddObstacle(AbsObstacle obj)
    {
        if (obj is Meteor or Asteroid)
        {
            _obstacles.Add(obj);
        }
        else
        {
            throw new InvalidDataException($"Only Meteors and Asteroids cat appear in {nameof(CommonTrack)}");
        }
    }

    public override PassTrackResult Pass(AbsShip ship)
    {
        if (ship == null) throw new ArgumentNullException(nameof(ship));
        if (_obstacles.Select(obstacle => ship.Hit(obstacle.Damage)).Any(isAlive => !isAlive))
        {
            return new ShipDestroyed { Message = nameof(ship) + " destroyed because of obstacle in common space" };
        }

        PassTrackResult res = ship.Fly(_dist);
        return res;
    }
}