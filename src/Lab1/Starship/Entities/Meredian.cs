using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public class Meredian : AbsShip
{
    private AbsEngine _impulseEngine;
    private AbsWarpEngine? warpEngine;

    public Meredian()
    {
        _impulseEngine = new EngineE();
    }
}