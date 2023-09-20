using System.Diagnostics;
using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Entities;

public class HighDensityTrack : AbsTrack
{
    private int _dist;

    public HighDensityTrack(int dist) => _dist = dist;

    public override PassTrackResult Pass(AbsShip ship)
    {
        Debug.Assert(ship != null, nameof(ship) + " != null");
        PassTrackResult res = ship.Warp(_dist);
        return res;
    }
}