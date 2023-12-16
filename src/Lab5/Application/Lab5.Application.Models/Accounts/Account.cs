namespace Lab5.Application.Users.Models.Accounts;

public class Account
{
    public Account(int id, string host, long balance)
    {
        Id = id;
        Host = host;
        Balance = balance;
    }

    public int Id { get; private set; }
    public string Host { get; private set; }
    public long Balance { get; set; }
}