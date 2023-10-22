using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class Repository
{
    private static Repository? instance;
    private Dictionary<string, List<BasePart>> _database;

    private Repository()
    {
        _database = new Dictionary<string, List<BasePart>>();
    }

    public static Repository TakeInstance()
    {
        if (instance is null)
        {
            instance = new Repository();
        }

        return instance;
    }

    public void AddPart(BasePart part)
    {
        if (part is null) return;
        List<BasePart> array = _database[part.GetPart().ToString()];

        if (array.Any(current => current.Name == part.Name))
        {
            return;
        }

        array.Add(part);
    }

    public BasePart GetPart(Parts part, string name)
    {
        List<BasePart> array = _database[part.ToString()];

        foreach (BasePart? current in array.Where(current => current.Name == name))
        {
            return current;
        }

        throw new InvalidOperationException();
    }

    public void Init()
    {
        var gpus = new List<BasePart>
        {
            new GraphicCard("RX 5700XT", 8, 4, 1650, 200, 280, 114),
            new GraphicCard("RTX 3060Ti", 8, 4, 1410, 220, 247, 120),
        };
        _database.Add(Parts.GraphicCard.ToString(), gpus);

        var cpus = new List<BasePart>
        {
            new Cpu("i7-12700", "LGA1700", false, 190, 21, 120),
            new Cpu("Ryzen 5 7600", "AM5", true, 220, 21, 150),
        };
        _database.Add(Parts.CPU.ToString(), cpus);

        var coolers = new List<BasePart>
        {
            new CPUCooler("Intel Box", "LGA1700", 200),
            new CPUCooler("Bad AMD", "AM5", 210),
        };
        _database.Add(Parts.CPUCooler.ToString(), coolers);

        var dram = new List<BasePart>
        {
            new Dram("Samsung", "Y", 32, 3200, 4, 3, 100),
            new Dram("Kingston", "Y", 16, 3133, 4, 3, 80),
        };
        _database.Add(Parts.DRAM.ToString(), dram);

        var hdd = new List<BasePart>
        {
            new Hdd("Smart", 2, 6000, 30),
            new Hdd("Samsung", 5, 7200, 30),
        };
        _database.Add(Parts.HDD.ToString(), hdd);

        var motherboards = new List<BasePart>
        {
            new Motherboard("Asus", "LGA1700", 4, 6, 4, 1030, 4, new Bios(2, 22), false, 3200),
            new Motherboard("MSI", "AM5", 4, 6, 4, 1030, 4, new Bios(2, 25), false, 3200),
        };
        _database.Add(Parts.Motherboard.ToString(), motherboards);

        var cases = new List<BasePart>
        {
            new PcCase("Zalman", 10, 300, 150),
            new PcCase("HyperX", 10, 240, 150),
        };
        _database.Add(Parts.PCCase.ToString(), cases);

        var psus = new List<BasePart>
        {
            new Psu("Cougar", 600),
            new Psu("AirCool", 450),
        };
        _database.Add(Parts.PSU.ToString(), psus);

        var ssds = new List<BasePart>
        {
            new Ssd("Samsung", 2, 7000, 50, DriveConnection.Pci),
            new Ssd("Kingston", 1, 6500, 40, DriveConnection.Pci),
        };
        _database.Add(Parts.SSD.ToString(), ssds);

        var adapters = new List<BasePart>
        {
            new WiFiAdapter("Type1", 4, 20),
            new WiFiAdapter("Type2", 4, 15),
        };
        _database.Add(Parts.WiFiAdapter.ToString(), adapters);
    }
}