using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public class ShipStella : BaseShip
{
    public ShipStella(bool photo = false)
    {
        ImpulseEngine = new EngineC();
        WarpEngine = new OmegaWarpEngine();
        Hull = new FirstHull();
        Deflector = new FirstDeflector(photo);
    }
}