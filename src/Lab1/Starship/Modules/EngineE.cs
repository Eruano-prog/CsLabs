using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public class EngineE : BaseEngine
{
    public EngineE()
    {
        Consumption = 400;
        CanPassNitro = true;
    }

    public override int TimeToPass(int dist)
    {
        double acceleration = Math.Log(dist);
        int time = (int)Math.Sqrt((2 * dist) / acceleration);
        return time;
    }
}