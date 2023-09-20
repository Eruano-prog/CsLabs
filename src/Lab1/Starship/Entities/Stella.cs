using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public class Stella : AbsShip
{
    private AbsEngine _impulseEngine;
    private AbsWarpEngine? _warpEngine;

    public Stella()
    {
        _impulseEngine = new EngineC();
        _warpEngine = new OmegaWarpEngine();
    }
}