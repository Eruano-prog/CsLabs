namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public abstract class BaseHull
{
    public bool IsWorking { get; private set; } = true;
    protected int Durability { get; set; }

    public virtual bool TakeDamage(int dmg)
    {
        Durability -= dmg;
        if (Durability <= 0) IsWorking = false;
        return Durability >= 0;
    }
}