using System.Diagnostics;
using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Entities;

public class NitrinTrack : AbsTrack
{
    private readonly int _dist;

    public NitrinTrack(int dist) => _dist = dist;
    public override PassTrackResult Pass(AbsShip ship)
    {
        Debug.Assert(ship != null, nameof(ship) + " != null");
        PassTrackResult res = ship.Fly(_dist);
        return res;
    }
}