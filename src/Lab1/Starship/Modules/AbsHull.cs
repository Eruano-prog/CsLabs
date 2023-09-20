namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public abstract class AbsHull
{
    public bool IsWorking { get; protected set; }

    public abstract bool TakeDamage(int dmg);
}