namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public class ThirdDeflector : AbsDeflector
{
    public ThirdDeflector(bool photon)
    {
        if (photon) PhotonCount = 3;
        else PhotonCount = 0;
        Durability = 200;
    }
}