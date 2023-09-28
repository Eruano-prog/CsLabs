using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public class Stella : BaseShip
{
    public Stella(bool photo = false)
    {
        ImpulseEngine = new EngineC();
        WarpEngine = new OmegaWarpEngine();
        Hull = new FirstHull();
        Deflector = new FirstDeflector(photo);
    }
}