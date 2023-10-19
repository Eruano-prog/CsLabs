using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class TestCases
{
     [Fact]
     public void Test1()
     {
          var repository = new Repository();
          repository.Init();

          ComputerConfiguration computer = new ComputerBuilder(repository)
               .WithGPU("RTX 3060Ti")
               .WithCPU("Ryzen 5 7600")
               .WithCooler("Intel Box")
               .WithDram("Samsung")
               .WithHDD("Samsung")
               .WithMotherboard("Asus")
               .WithCase("Zalman")
               .WithPSU("Cougar")
               .Build();

          Assert.True(computer is ComputerConfiguration);
     }
}