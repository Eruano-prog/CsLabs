using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerBuilder
{
    private ComputerConfiguration _computer;
    private RepositoryContext _database;

    public ComputerBuilder(RepositoryContext database)
    {
        _database = database;
        this._computer = new ComputerConfiguration();
    }

    public ComputerBuilder(RepositoryContext database, ComputerConfiguration computer)
    {
        _database = database;
        this._computer = computer;
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

        Parts? check = _computer.IsValid();
        if (check is not null)
        {
            throw new ComputerNotReadyException($"Missing {check}");
        }

        if (_computer.Cooler?.Tdp < _computer.Cpu?.Tdp)
        {
            throw new NotEnoughTdpException("Cooler tdp less than cpu`s");
        }

        return _computer;
    }

    public ComputerBuilder WithCPU(string name)
    {
        Cpu cpu = _database.CpuRepository.GetPart(name);

        try
        {
            if (cpu.CanBePlaced(_computer))
            {
                _computer.Cpu = cpu;
                _computer.CurPower += cpu.Power;
            }

            return this;
        }
        catch (Exception e)
        {
            throw new FailedToPlaceExeption("Failed to place CPU", e);
        }
    }

    public ComputerBuilder WithCooler(string name)
    {
        CpuCooler cooler = _database.CoolerRepository.GetPart(name);

        try
        {
            if (cooler.CanBePlaced(_computer))
            {
                _computer.Cooler = cooler;
            }

            return this;
        }
        catch (FailedToPlaceExeption e)
        {
            throw new FailedToPlaceExeption("Failed to place Cooler", e);
        }
    }

    public ComputerBuilder WithDram(string name)
    {
        Dram ram = _database.DramRepository.GetPart(name);

        try
        {
            if (ram.CanBePlaced(_computer))
            {
                _computer.Dram = ram;
                _computer.CurPower += ram.Power;
            }

            return this;
        }
        catch (FailedToPlaceExeption e)
        {
            throw new FailedToPlaceExeption("Dram doesn`t fit pc", e);
        }
    }

    public ComputerBuilder WithGPU(string name)
    {
        GraphicCard gpu = _database.GpuRepository.GetPart(name);
        try
        {
            if (gpu.CanBePlaced(_computer))
            {
                _computer.GraphicCard = gpu;
                _computer.CurPci++;
                _computer.CurPower += gpu.Power;
            }

            return this;
        }
        catch (FailedToPlaceExeption e)
        {
            throw new FailedToPlaceExeption("Failed to place GPU", e);
        }
    }

    public ComputerBuilder WithHDD(string name)
    {
        Hdd hdd = _database.HddRepository.GetPart(name);

        try
        {
            if (hdd.CanBePlaced(_computer))
            {
                _computer.Hdd = hdd;

                _computer.CurPower += hdd.Power;
                _computer.CurSata++;
            }

            return this;
        }
        catch (FailedToPlaceExeption e)
        {
            throw new FailedToPlaceExeption("HDD ddoesn`t fit", e);
        }
    }

    public ComputerBuilder WithMotherboard(string name)
    {
        Motherboard motherboard = _database.MotherboardRepository.GetPart(name);
        try
        {
            if (motherboard.CanBePlaced(_computer))
            {
                _computer.Motherboard = motherboard;
            }

            return this;
        }
        catch (Exception e)
        {
            throw new FailedToPlaceExeption("Motherboard can`t be placed here", e);
        }
    }

    public ComputerBuilder WithCase(string name)
    {
        PcCase pcCase = _database.CaseRepository.GetPart(name);
        if (pcCase.CanBePlaced(_computer))
        {
            _computer.PcCase = pcCase;
        }

        return this;
    }

    public ComputerBuilder WithPSU(string name)
    {
        Psu psu = _database.PsuRepository.GetPart(name);
        if (psu.CanBePlaced(_computer))
        {
            _computer.Psu = psu;
        }

        return this;
    }

    public ComputerBuilder WithSSD(string name)
    {
        Ssd ssd = _database.SsdRepository.GetPart(name);
        if (ssd.CanBePlaced(_computer))
        {
            _computer.Ssd = ssd;
        }

        return this;
    }

    public ComputerBuilder WithWiFi(string name)
    {
        WiFiAdapter wifi = _database.WifiAdapterRepository.GetPart(name);
        if (wifi.CanBePlaced(_computer))
        {
            _computer.WiFiAdapter = wifi;
        }

        return this;
    }
}