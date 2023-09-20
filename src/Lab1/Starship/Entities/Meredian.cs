using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public class Meredian : AbsShip
{
    private AbsEngine _impulseEngine;

    public Meredian()
    {
        _impulseEngine = new EngineE();
    }
}