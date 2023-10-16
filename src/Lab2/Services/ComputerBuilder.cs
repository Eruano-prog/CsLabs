using System.Threading;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerBuilder
{
    private ComputerConfiguration _computer;

    public ComputerBuilder()
    {
        this._computer = new ComputerConfiguration();
    }

    public void Reset()
    {
        _computer = new ComputerConfiguration();
    }

    public void AddCPU()
    {
        _computer.Cpu = new CPU()
    }
}