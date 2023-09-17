using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public abstract class AbsShip
{
    private AbsEngine impulseEngine;
    private AbsWarpEngine? warpEngine;
}