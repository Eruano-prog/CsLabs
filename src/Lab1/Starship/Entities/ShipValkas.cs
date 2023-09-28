using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public class ShipValkas : BaseShip
{
    public ShipValkas(bool photo = false)
    : base()
    {
        ImpulseEngine = new EngineE();
        WarpEngine = new GammaWarpEngine();
        Hull = new SecondHull();
        Deflector = new FirstDeflector(photo);
    }
}