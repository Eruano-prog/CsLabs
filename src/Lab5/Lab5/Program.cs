using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Users;
using Lab5.Application.Users.Abstractions.Repositories;
using Lab5.Infrastructure;
using Lab5.Presentation.Console;
using Microsoft.Extensions.DependencyInjection;

var collection = new ServiceCollection();

collection.AddScoped<IUserService, UserService>();
collection.AddScoped<IAdminService, AdminService>();

string connectionString = "Host=localhost:5432;" +
                          "Username=postgres;" +
                          "Password=fedor2004;" +
                          "Database=Lab5";

collection.AddScoped<IUserRepository>(sp => new UserRepository(connectionString));
collection.AddScoped<IAccountRepository>(sp => new AccountRepository(connectionString));
collection.AddScoped<IOrderRepository>(sp => new OrderRepository(connectionString));

collection.AddScoped<ScenarioRunner>();

ServiceProvider provider = collection.BuildServiceProvider();

using IServiceScope scope = provider.CreateScope();

ScenarioRunner scenarioRunner = scope.ServiceProvider.GetRequiredService<ScenarioRunner>();

scenarioRunner.Run();