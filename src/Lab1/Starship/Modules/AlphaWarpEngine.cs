namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public class AlphaWarpEngine : AbsWarpEngine
{
    private readonly int _maxDist;

    public AlphaWarpEngine()
    {
        _maxDist = 5000;
    }

    public override int? Consumption(int dist)
    {
        if (dist > _maxDist)
        {
            return null;
        }

        return dist;
    }
}