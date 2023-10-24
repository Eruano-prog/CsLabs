using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class RepositoryContext
{
    private static RepositoryContext? _instance;

    private RepositoryContext()
    {
        CpuRepository = new Repository<Cpu>();
        CoolerRepository = new Repository<CPUCooler>();
        DramRepository = new Repository<Dram>();
        GpuRepository = new Repository<GraphicCard>();
        HddRepository = new Repository<Hdd>();
        MotherboardRepository = new Repository<Motherboard>();
        CaseRepository = new Repository<PcCase>();
        PsuRepository = new Repository<Psu>();
        SsdRepository = new Repository<Ssd>();
        WifiAdapterRepository = new Repository<WiFiAdapter>();

        FillRepositories();
    }

    public Repository<Cpu> CpuRepository { get; }
    public Repository<CPUCooler> CoolerRepository { get; }
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
            return _instance;
        }

        return _instance;
    }

    private void FillRepositories()
    {
        var cpus = new Collection<Cpu>
        {
            new Cpu("i7-12700", "LGA1700", false, 190, 21, 120),
            new Cpu("Ryzen 5 7600", "AM5", true, 220, 21, 150),
        };
        CpuRepository.Init(cpus);

        var coolers = new Collection<CPUCooler>
        {
            new CPUCooler("Intel i7-12700 Box", "LGA1700", 200),
            new CPUCooler("Intel i5-8600 Box", "LGA1700", 150),
            new CPUCooler("Bad AMD", "AM5", 210),
        };
        CoolerRepository.Init(coolers);

        var dram = new Collection<Dram>
        {
            new Dram("Samsung", "Y", 32, 3200, 4, 3, 100),
            new Dram("Kingston", "Y", 16, 3133, 4, 3, 80),
        };
        DramRepository.Init(dram);

        var gpus = new Collection<GraphicCard>
        {
            new GraphicCard("RX 5700XT", 8, 4, 1650, 200, 280, 114),
            new GraphicCard("RTX 3060Ti", 8, 4, 1410, 220, 247, 120),
        };
        GpuRepository.Init(gpus);

        var hdd = new Collection<Hdd>
        {
            new Hdd("Smart", 2, 6000, 30),
            new Hdd("Samsung", 5, 7200, 30),
        };
        HddRepository.Init(hdd);

        var motherboards = new Collection<Motherboard>
        {
            new Motherboard("Asus", "LGA1700", 4, 6, 4, 1030, 4, new Bios(2, 22), false, 3200),
            new Motherboard("MSI", "AM5", 4, 6, 4, 1030, 4, new Bios(2, 25), false, 3200),
        };
        MotherboardRepository.Init(motherboards);

        var cases = new Collection<PcCase>
        {
            new PcCase("Zalman", 10, 300, 150),
            new PcCase("HyperX", 10, 240, 150),
        };
        CaseRepository.Init(cases);

        var psus = new Collection<Psu>
        {
            new Psu("Cougar", 600),
            new Psu("AirCool", 450),
        };
        PsuRepository.Init(psus);

        var ssds = new Collection<Ssd>
        {
            new Ssd("Samsung", 2, 7000, 50, DriveConnection.Pci),
            new Ssd("Kingston", 1, 6500, 40, DriveConnection.Pci),
        };
        SsdRepository.Init(ssds);

        var adapters = new Collection<WiFiAdapter>
        {
            new WiFiAdapter("Type1", 4, 20),
            new WiFiAdapter("Type2", 4, 15),
        };
        WifiAdapterRepository.Init(adapters);
    }
}