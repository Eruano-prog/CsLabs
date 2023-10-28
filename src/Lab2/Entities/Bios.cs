namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Bios
{
    public Bios(int type, int version)
    {
        Type = type;
        Version = version;
    }

    public int Type { get; set; }
    public int Version { get; set; }
}