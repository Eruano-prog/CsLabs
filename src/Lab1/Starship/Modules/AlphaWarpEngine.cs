namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public class AlphaWarpEngine : BaseWarpEngine
{
    private readonly int _maxDistance;
    public AlphaWarpEngine()
    {
        _maxDistance = 5000;
    }

    public override int? TimeToWarp(int distance)
    {
        if (distance > _maxDistance)
        {
            return null;
        }

        return distance;
    }
}