namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public abstract class AbsDeflector
{
    protected AbsDeflector(bool photon)
    {
        if (photon) PhotonCount = 3;
        else PhotonCount = 0;
    }

    protected AbsDeflector()
    {
        PhotonCount = 0;
    }

    public bool IsWorking { get; private set; } = true;
    public int PhotonCount { get; protected set; }
    public int Durability { get; protected set; }

    public virtual bool TakeDamage(int dmg)
    {
        Durability -= dmg;
        if (Durability <= 0) IsWorking = false;
        return Durability >= 0;
    }

    public bool Flare()
    {
        if (PhotonCount <= 0) return false;
        PhotonCount -= 1;
        return true;
    }
}