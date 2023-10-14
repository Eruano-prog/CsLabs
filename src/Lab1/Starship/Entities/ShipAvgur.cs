using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public class ShipAvgur : BaseShip
{
    public ShipAvgur()
    {
        ImpulseEngine = new EngineE();
        WarpEngine = new AlphaWarpEngine();
        Hull = new ThirdHull();
        Deflector = new ThirdDeflector(false);
    }
}