using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class TestCases
{
     [Fact]
     public void Test1()
     {
          var repository = Repository.TakeInstance();
          repository.Init();

          try
          {
               ComputerConfiguration computer = new ComputerBuilder(repository)
                    .WithGPU("RTX 3060Ti")
                    .WithCPU("i7-12700")
                    .WithCooler("Intel Box")
                    .WithDram("Samsung")
                    .WithHDD("Samsung")
                    .WithMotherboard("Asus")
                    .WithCase("Zalman")
                    .WithPSU("Cougar")
                    .Build();
          }
          catch (ComputerNotReadyException e)
          {
               Assert.Fail(e.Message);
          }
          catch (NotEnoughPowerException e)
          {
               Assert.Fail(e.Message);
          }
          catch (NotEnoughSlotsException e)
          {
               Assert.Fail(e.Message);
          }

          Assert.True(true);
     }
}