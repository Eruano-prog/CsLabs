namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public class SecondDeflector : AbsDeflector
{
    public SecondDeflector(bool photon)
    {
        if (photon) PhotonCount = 3;
        else PhotonCount = 0;
        Durability = 50;
    }
}