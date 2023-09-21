using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public class Meredian : AbsShip
{
    public Meredian(bool photo = false)
    {
        ImpulseEngine = new EngineE();
        Hull = new SecondHull();
        Deflector = new SecondDeflector(photo);
        AntiNitro = true;
    }
}