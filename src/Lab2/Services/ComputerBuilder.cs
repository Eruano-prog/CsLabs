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

    public ComputerConfiguration Build()
    {
        if (_computer.CurPower > _computer.Psu?.Power)
        {
            throw new NotEnoughPowerException($"Computer needs {_computer.CurPower} but it has only {_computer.Psu?.Power}");
        }

        if (_computer.CurPci > _computer.Motherboard?.PciCount)
        {
            throw new NotEnoughSlotsException("Not enough PCI slots");
        }

        if (_computer.CurSata > _computer.Motherboard?.SataCount)
        {
            throw new NotEnoughSlotsException("Not enough Sata slots");
        }

        if (!_computer.IsValid())
        {
            throw new ComputerNotReadyException();
        }

        return _computer;
    }

    public ComputerBuilder WithCPU(string name)
    {
        var cpu = (Cpu)_datebase.GetPart(Parts.CPU, name);
        if (cpu.CanBePlaced(_computer))
        {
            _computer.Cpu = cpu;
            _computer.CurPower += cpu.Power;
        }

        return this;
    }

    public ComputerBuilder WithCooler(string name)
    {
        var cooler = (CPUCooler)_datebase.GetPart(Parts.CPUCooler, name);
        if (cooler.CanBePlaced(_computer))
        {
            _computer.Cooler = cooler;
        }

        return this;
    }

    public ComputerBuilder WithDram(string name)
    {
        var ram = (Dram)_datebase.GetPart(Parts.DRAM, name);
        if (ram.CanBePlaced(_computer))
        {
            _computer.Dram = ram;
            _computer.CurPower += ram.Power;
        }

        return this;
    }

    public ComputerBuilder WithGPU(string name)
    {
        var gpu = (GraphicCard)_datebase.GetPart(Parts.GraphicCard, name);
        if (gpu.CanBePlaced(_computer))
        {
            _computer.GraphicCard = gpu;
            _computer.CurPci++;
        }

        return this;
    }

    public ComputerBuilder WithHDD(string name)
    {
        var hdd = (Hdd)_datebase.GetPart(Parts.HDD, name);
        if (hdd.CanBePlaced(_computer))
        {
            _computer.Hdd = hdd;

            _computer.CurPower += hdd.Power;
            _computer.CurSata++;
        }

        return this;
    }

    public ComputerBuilder WithMotherboard(string name)
    {
        var motherboard = (Motherboard)_datebase.GetPart(Parts.Motherboard, name);
        if (motherboard.CanBePlaced(_computer))
        {
            _computer.Motherboard = motherboard;
        }

        return this;
    }

    public ComputerBuilder WithCase(string name)
    {
        var pcCase = (PcCase)_datebase.GetPart(Parts.PCCase, name);
        if (pcCase.CanBePlaced(_computer))
        {
            _computer.PcCase = pcCase;
        }

        return this;
    }

    public ComputerBuilder WithPSU(string name)
    {
        var psu = (Psu)_datebase.GetPart(Parts.PSU, name);
        if (psu.CanBePlaced(_computer))
        {
            _computer.Psu = psu;
        }

        return this;
    }

    public ComputerBuilder WithSSD(string name)
    {
        var ssd = (Ssd)_datebase.GetPart(Parts.SSD, name);
        if (ssd.CanBePlaced(_computer))
        {
            _computer.Ssd = ssd;
        }

        return this;
    }

    public ComputerBuilder WithWiFi(string name)
    {
        var wifi = (WiFiAdapter)_datebase.GetPart(Parts.WiFiAdapter, name);
        if (wifi.CanBePlaced(_computer))
        {
            _computer.WiFiAdapter = wifi;
        }

        return this;
    }
}