using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IPart
{
    bool CanBePlaced(ComputerConfiguration computer);
}