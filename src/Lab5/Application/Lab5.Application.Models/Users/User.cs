namespace Lab5.Application.Users.Models.Users;

public record User(long Id, string Name, UserRole Role, string Password);