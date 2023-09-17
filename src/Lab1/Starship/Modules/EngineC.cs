namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public sealed class EngineC : AbsEngine
{
    private readonly int _speed;

    public EngineC()
    {
        _speed = 200;
        Consumption = 10;
    }

    public int Consumption { get; }

    public override int FuelToPass(int dist)
    {
        return (dist / _speed) * Consumption;
    }
}