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
        var ships = new List<BaseShip>() { new ShipShuttle(), new ShipAvgur() };
        var results = ships.Select(ship => new Expedition.Entities.Expedition(new HighDensityTrack(10000), ship)).Select(exp => exp.Complete()).ToList();

        bool assert = (results[0] is ResultShipLost) & (results[1] is ResultShipLost);
        Assert.True(assert);
    }

    [Fact]
    public static void Test2()
    {
        var ships = new List<BaseShip>() { new ShipValkas(), new ShipValkas(true) };
        BaseTrack track = new HighDensityTrack(10000);
        track.AddObstacle(new ObstacleAntimaterFlare());
        var results = ships.Select(ship => new Expedition.Entities.Expedition(track, ship)).Select(exp => exp.Complete()).ToList();

        bool assert = (results[0] is ResultCrewDied) & (results[1] is ResultSuccess);
        Assert.True(assert);
    }

    [Fact]
    public static void Test3()
    {
        var ships = new List<BaseShip>() { new ShipValkas(), new ShipAvgur(), new ShipMeredian() };
        var track = new NitrinTrack(10000);
        track.AddObstacle(new ObstacleWhale());
        var results = ships.Select(ship => new Expedition.Entities.Expedition(track, ship)).Select(exp => exp.Complete()).ToList();

        bool assert = (results[0] is ResultShipDestroyed) & (results[1] is ResultSuccess) & (results[2] is ResultSuccess);
        Assert.True(assert);
    }

    [Fact]
    public static void Test4()
    {
        var ships = new List<BaseShip>() { new ShipShuttle(), new ShipMeredian() };
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
        var ships = new List<BaseShip>() { new ShipAvgur(), new ShipStella() };
        var results = ships.Select(ship => new Expedition.Entities.Expedition(new HighDensityTrack(7500), ship)).Select(exp => exp.Complete()).ToList();

        bool assert = (results[0] is ResultShipLost) & (results[1] is ResultSuccess);
        Assert.True(assert);
    }

    [Fact]
    public static void Test6()
    {
        var ships = new List<BaseShip>() { new ShipShuttle(), new ShipValkas() };
        var results = ships.Select(ship => new Expedition.Entities.Expedition(new NitrinTrack(7500), ship)).Select(exp => exp.Complete()).ToList();

        bool assert = (results[0] is ResultShipLost) & (results[1] is ResultSuccess);
        Assert.True(assert);
    }

    [Fact]
    public static void Test7()
    {
        var ships = new List<BaseShip>() { new ShipShuttle(), new ShipMeredian(), new ShipAvgur() };
        var tracks = new Collection<BaseTrack>() { new HighDensityTrack(4000), new CommonTrack(500) };
        var results = ships.Select(ship => new Expedition.Entities.Expedition(tracks, ship)).Select(exp => exp.Complete()).ToList();

        bool assert = (results[0] is ResultShipLost) & (results[1] is ResultShipLost) & (results[2] is ResultSuccess);
        Assert.True(assert);
    }
}