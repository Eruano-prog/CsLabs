using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public class Shuttle : AbsShip
{
    public Shuttle()
    {
        ImpulseEngine = new EngineC();
        Hull = new FirstHull();
    }
}