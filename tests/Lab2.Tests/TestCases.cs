using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class TestCases
{
     [Fact]
     public void CorrectConfigCase()
     {
          var repository = RepositoryContext.TakeInstance();

          System.Exception? ex = Record.Exception(() =>
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
               });

          Assert.Null(ex);
     }

     [Fact]
     public void NotEnoughPowerCase()
     {
          var repository = RepositoryContext.TakeInstance();

          Assert.Throws<NotEnoughPowerException>(() =>
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
          });
     }

     [Fact]
     public void NotEnoughTdpCase()
     {
          var repository = RepositoryContext.TakeInstance();

          Assert.Throws<NotEnoughTdpException>(() =>
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
          });
     }

     [Fact]
     public void WrongComponentsCase()
     {
          var repository = RepositoryContext.TakeInstance();

          FailedToPlaceExeption ex = Assert.Throws<FailedToPlaceExeption>(() =>
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
          });

          Xunit.Assert.Equal("Socket doesn`t match", ex.InnerException?.Message);
     }
}