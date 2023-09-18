namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public sealed class EngineC : AbsEngine
{
    private readonly int _speed;

    public EngineC(bool antiNitro)
    {
        _speed = 200;
        Consumption = 10;
        AntiNitro = antiNitro;
    }

    public int Consumption { get; init; }
    public bool AntiNitro { get; init; }

    public override int FuelToPass(int dist)
    {
        return (dist / _speed) * Consumption;
    }
}