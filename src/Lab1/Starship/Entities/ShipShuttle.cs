using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public class ShipShuttle : BaseShip
{
    public ShipShuttle()
    {
        ImpulseEngine = new EngineC();
        Hull = new FirstHull();
    }
}