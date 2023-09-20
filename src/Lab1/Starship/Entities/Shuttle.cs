using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public class Shuttle : AbsShip
{
    private AbsEngine _impulseEngine;

    public Shuttle()
    {
        _impulseEngine = new EngineC();
    }
}