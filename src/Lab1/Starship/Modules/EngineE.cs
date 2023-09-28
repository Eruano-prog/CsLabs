using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public class EngineE : BaseEngine
{
    public EngineE()
    {
        Consumption = 400;
        CanPassNitro = true;
    }

    public override int TimeToPass(int distance)
    {
        double acceleration = Math.Log(distance);
        int time = (int)Math.Sqrt((2 * distance) / acceleration);
        return time;
    }
}