namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public class FirstDeflector : BaseDeflector
{
    public FirstDeflector(bool photon)
    {
        if (photon) PhotonCount = 3;
        else PhotonCount = 0;
        Durability = 10;
    }
}