namespace Lab5.Application.Users.Models.Users;

public class User
{
    public User(int id, string name, UserRole role, string password)
    {
        Id = id;
        Name = name;
        Role = role;
        Password = password;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public UserRole Role { get; private set; }
    public string Password { get; private set; }
}