using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.Entities;

public class EngineE : IEngine
{
    public EngineE()
    {
        Consumption = 400;
    }

    public int Consumption { get; init; }

    public int TimeToReach(int dist)
    {
        double acceleration = Math.Log(dist);
        int time = (int)Math.Sqrt((2 * dist) / acceleration);
        return time;
    }
}