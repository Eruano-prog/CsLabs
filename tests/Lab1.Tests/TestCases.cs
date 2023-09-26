using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public static class TestCases
{
    [Fact]
    public static void Test1()
    {
        var ships = new List<AbsShip>() { new Shuttle(), new Avgur() };
        var results = ships.Select(ship => new Expedition.Entities.Expedition(new HighDensityTrack(10000), ship)).Select(exp => exp.Complete()).ToList();

        bool assert = (results[0] is ShipLost) & (results[1] is ShipLost);
        Assert.True(assert);
    }

    [Fact]
    public static void Test2()
    {
        var ships = new List<AbsShip>() { new Valkas(), new Valkas(true) };
        AbsTrack track = new HighDensityTrack(10000);
        track.AddObstacle(new AntimaterFlare());
        var results = ships.Select(ship => new Expedition.Entities.Expedition(track, ship)).Select(exp => exp.Complete()).ToList();

        bool assert = (results[0] is CrewDied) & (results[1] is Success);
        Assert.True(assert);
    }

    [Fact]
    public static void Test3()
    {
        var ships = new List<AbsShip>() { new Valkas(), new Avgur(), new Meredian() };
        var track = new NitrinTrack(10000);
        track.AddObstacle(new Whale());
        var results = ships.Select(ship => new Expedition.Entities.Expedition(track, ship)).Select(exp => exp.Complete()).ToList();

        bool assert = (results[0] is ShipDestroyed) & (results[1] is Success) & (results[2] is Success);
        Assert.True(assert);
    }

    [Fact]
    public static void Test4()
    {
        var ships = new List<AbsShip>() { new Shuttle(), new Meredian() };
        var results = ships.Select(ship => new Expedition.Entities.Expedition(new CommonTrack(200), ship)).Select(exp => exp.Complete()).ToList();

        int cheapest = results[1].FuelToPass;
        int minIndex = 1;
        for (int i = 0; i < results.Count; i++)
        {
            if (results[i].FuelToPass >= cheapest) continue;
            cheapest = results[i].FuelToPass;
            minIndex = i;
        }

        Assert.Equal(0, minIndex);
    }

    [Fact]
    public static void Test5()
    {
        var ships = new List<AbsShip>() { new Avgur(), new Stella() };
        var results = ships.Select(ship => new Expedition.Entities.Expedition(new HighDensityTrack(7500), ship)).Select(exp => exp.Complete()).ToList();

        bool assert = (results[0] is ShipLost) & (results[1] is Success);
        Assert.True(assert);
    }

    [Fact]
    public static void Test6()
    {
        var ships = new List<AbsShip>() { new Shuttle(), new Valkas() };
        var results = ships.Select(ship => new Expedition.Entities.Expedition(new NitrinTrack(7500), ship)).Select(exp => exp.Complete()).ToList();

        bool assert = (results[0] is ShipLost) & (results[1] is Success);
        Assert.True(assert);
    }

    [Fact]
    public static void Test7()
    {
        var ships = new List<AbsShip>() { new Shuttle(), new Meredian(), new Avgur() };
        var tracks = new Collection<AbsTrack>() { new HighDensityTrack(4000), new CommonTrack(500) };
        var results = ships.Select(ship => new Expedition.Entities.Expedition(tracks, ship)).Select(exp => exp.Complete()).ToList();

        bool assert = (results[0] is ShipLost) & (results[1] is ShipLost) & (results[2] is Success);
        Assert.True(assert);
    }
}