namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public class ThirdHull : AbsHull
{
    private int _durability = 100;

    public override bool TakeDamage(int dmg)
    {
        _durability -= dmg;
        if (_durability <= 0) IsWorking = false;
        return _durability >= 0;
    }
}