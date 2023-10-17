using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerBuilder
{
    private ComputerConfiguration _computer;
    private Repository _datebase;

    public ComputerBuilder(Repository datebase)
    {
        _datebase = datebase;
        this._computer = new ComputerConfiguration();
    }

    public void Reset()
    {
        _computer = new ComputerConfiguration();
    }

    public void WithCPU(string name)
    {
        var cpu = (Cpu)_datebase.GetPart(Parts.CPU, name);
        if (cpu.CanBePlaced(_computer))
        {
            _computer.Cpu = cpu;
            _computer.CurPower += cpu.Power;
        }
        else
        {
            return;
        }
    }

    public void WithCooler(string name)
    {
        var cooler = (CPUCooler)_datebase.GetPart(Parts.CPUCooler, name);
        if (cooler.CanBePlaced(_computer))
        {
            _computer.Cooler = cooler;
        }
        else
        {
            return;
        }
    }

    public void WithDram(string name)
    {
        var ram = (Dram)_datebase.GetPart(Parts.DRAM, name);
        if (ram.CanBePlaced(_computer))
        {
            _computer.Dram = ram;
            _computer.CurPower += ram.Power;
        }
        else
        {
            return;
        }
    }

    public void WithGPU(string name)
    {
        var gpu = (GraphicCard)_datebase.GetPart(Parts.GraphicCard, name);
        if (gpu.CanBePlaced(_computer))
        {
            _computer.GraphicCard = gpu;
            _computer.CurPci++;
        }
        else
        {
            return;
        }
    }

    public void WithHDD(string name)
    {
        var hdd = (Hdd)_datebase.GetPart(Parts.HDD, name);
        if (hdd.CanBePlaced(_computer))
        {
            _computer.Hdd = hdd;

            _computer.CurPower += hdd.Power;
            _computer.CurSata++;
        }
        else
        {
            return;
        }
    }

    public void WithMotherboard(string name)
    {
        var motherboard = (Motherboard)_datebase.GetPart(Parts.Motherboard, name);
        if (motherboard.CanBePlaced(_computer))
        {
            _computer.Motherboard = motherboard;
        }
        else
        {
            return;
        }
    }

    public void WithCase(string name)
    {
        var pcCase = (PcCase)_datebase.GetPart(Parts.PCCase, name);
        if (pcCase.CanBePlaced(_computer))
        {
            _computer.PcCase = pcCase;
        }
        else
        {
            return;
        }
    }

    public void WithPSU(string name)
    {
        var psu = (Psu)_datebase.GetPart(Parts.PSU, name);
        if (psu.CanBePlaced(_computer))
        {
            _computer.Psu = psu;
        }
        else
        {
            return;
        }
    }

    public void WithSSD(string name)
    {
        var ssd = (Ssd)_datebase.GetPart(Parts.SSD, name);
        if (ssd.CanBePlaced(_computer))
        {
            _computer.Ssd = ssd;
        }
        else
        {
            return;
        }
    }

    public void WithWiFi(string name)
    {
        var wifi = (WiFiAdapter)_datebase.GetPart(Parts.WiFiAdapter, name);
        if (wifi.CanBePlaced(_computer))
        {
            _computer.WiFiAdapter = wifi;
        }
        else
        {
            return;
        }
    }
}