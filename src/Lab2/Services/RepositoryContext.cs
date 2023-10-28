using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class RepositoryContext
{
    private static RepositoryContext? _instance;

    private RepositoryContext()
    {
        CpuRepository = new Repository<Cpu>();
        CoolerRepository = new Repository<CpuCooler>();
        DramRepository = new Repository<Dram>();
        GpuRepository = new Repository<GraphicCard>();
        HddRepository = new Repository<Hdd>();
        MotherboardRepository = new Repository<Motherboard>();
        CaseRepository = new Repository<PcCase>();
        PsuRepository = new Repository<Psu>();
        SsdRepository = new Repository<Ssd>();
        WifiAdapterRepository = new Repository<WiFiAdapter>();
    }

    public Repository<Cpu> CpuRepository { get; }
    public Repository<CpuCooler> CoolerRepository { get; }
    public Repository<Dram> DramRepository { get; }
    public Repository<GraphicCard> GpuRepository { get; }
    public Repository<Hdd> HddRepository { get; }
    public Repository<Motherboard> MotherboardRepository { get; }
    public Repository<PcCase> CaseRepository { get; }
    public Repository<Psu> PsuRepository { get; }
    public Repository<Ssd> SsdRepository { get; }
    public Repository<WiFiAdapter> WifiAdapterRepository { get; }

    public static RepositoryContext TakeInstance()
    {
        if (_instance is null)
        {
            _instance = new RepositoryContext();
            RepositorySeeder.FillRepositories(_instance);
            return _instance;
        }

        return _instance;
    }
}