using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public class EngineE : AbsEngine
{
    public EngineE()
    {
        Consumption = 400;
    }

    public int Consumption { get; init; }

    public override int TimeToPass(int dist)
    {
        double acceleration = Math.Log(dist);
        int time = (int)Math.Sqrt((2 * dist) / acceleration);
        return time;
    }
}