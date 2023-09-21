using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public class Valkas : AbsShip
{
    public Valkas(bool photo = false)
    : base()
    {
        ImpulseEngine = new EngineE();
        WarpEngine = new GammaWarpEngine();
        Hull = new SecondHull();
        Deflector = new FirstDeflector(photo);
    }
}