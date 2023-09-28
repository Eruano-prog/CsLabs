using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public class Meredian : BaseShip
{
    public Meredian(bool photo = false)
    {
        ImpulseEngine = new EngineE();
        Hull = new SecondHull();
        Deflector = new SecondDeflector(photo);
        AntiNitro = true;
    }
}