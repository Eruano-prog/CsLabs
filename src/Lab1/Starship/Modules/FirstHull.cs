namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public class FirstHull : AbsHull
{
    private int _durability = 5;

// public bool IsWorking { get; private set; }
    public override bool TakeDamage(int dmg)
    {
        _durability -= dmg;
        if (_durability <= 0) IsWorking = false;
        return _durability >= 0;
    }
}