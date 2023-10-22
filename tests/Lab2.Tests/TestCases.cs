using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class TestCases
{
     [Fact]
     public void CorrectConfigCase()
     {
          var repository = Repository.TakeInstance();

          try
          {
               ComputerConfiguration computer = new ComputerBuilder(repository)
                    .WithGPU("RTX 3060Ti")
                    .WithCPU("i7-12700")
                    .WithCooler("Intel i7-12700 Box")
                    .WithDram("Samsung")
                    .WithHDD("Samsung")
                    .WithMotherboard("Asus")
                    .WithCase("Zalman")
                    .WithPSU("Cougar")
                    .Build();
          }
          catch (FailedToPlaceExeption e)
          {
               Assert.Fail($"Operation failed ({e.Message}) because: {e.InnerException?.Message}");
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
          catch (NotEnoughTdpException e)
          {
               Assert.Fail(e.Message);
          }

          Assert.True(true);
     }

     [Fact]
     public void NotEnoughPowerCase()
     {
          var repository = Repository.TakeInstance();

          try
          {
               ComputerConfiguration computer = new ComputerBuilder(repository)
                    .WithGPU("RTX 3060Ti")
                    .WithCPU("i7-12700")
                    .WithCooler("Intel i7-12700 Box")
                    .WithDram("Samsung")
                    .WithHDD("Samsung")
                    .WithMotherboard("Asus")
                    .WithCase("Zalman")
                    .WithPSU("AirCool")
                    .Build();
          }
          catch (FailedToPlaceExeption e)
          {
               Assert.Fail($"Operation failed ({e.Message}) because: {e.InnerException?.Message}");
          }
          catch (ComputerNotReadyException e)
          {
               Assert.Fail(e.Message);
          }
          catch (NotEnoughPowerException e)
          {
               Assert.True(true, $"{e.Message}");
          }
          catch (NotEnoughSlotsException e)
          {
               Assert.Fail(e.Message);
          }
          catch (NotEnoughTdpException e)
          {
               Assert.Fail(e.Message);
          }
     }

     [Fact]
     public void NotEnoughTdpCase()
     {
          var repository = Repository.TakeInstance();
          try
          {
               ComputerConfiguration computer = new ComputerBuilder(repository)
                    .WithGPU("RTX 3060Ti")
                    .WithCPU("i7-12700")
                    .WithCooler("Intel i5-8600 Box")
                    .WithDram("Samsung")
                    .WithHDD("Samsung")
                    .WithMotherboard("Asus")
                    .WithCase("Zalman")
                    .WithPSU("Cougar")
                    .Build();
          }
          catch (FailedToPlaceExeption e)
          {
               Assert.Fail($"Operation failed ({e.Message}) because: {e.InnerException?.Message}");
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
          catch (NotEnoughTdpException e)
          {
               Assert.True(true, $"{e.Message}");
          }
     }

     [Fact]
     public void WrongComponentsCase()
     {
          var repository = Repository.TakeInstance();

          try
          {
               ComputerConfiguration computer = new ComputerBuilder(repository)
                    .WithGPU("RTX 3060Ti")
                    .WithCPU("Ryzen 5 7600")
                    .WithCooler("Intel i5-8600 Box")
                    .WithDram("Samsung")
                    .WithHDD("Samsung")
                    .WithMotherboard("Asus")
                    .WithCase("Zalman")
                    .WithPSU("Cougar")
                    .Build();
          }
          catch (FailedToPlaceExeption e)
          {
               Assert.True(true, $"Operation failed ({e.Message}) because: {e.InnerException?.Message}");
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
          catch (NotEnoughTdpException e)
          {
               Assert.Fail(e.Message);
          }
     }
}