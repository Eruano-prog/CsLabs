using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public class Shuttle : AbsShip
{
    private AbsEngine impulseEngine;
    private AbsWarpEngine? warpEngine;

    public Shuttle()
    {
        impulseEngine = new EngineC();
    }

    public PassTrackResult Pass(AbsTrack)
    {
        
    }
}