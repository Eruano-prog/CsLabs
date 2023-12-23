namespace Lab5.Application.Models.Transactions;

public class Order
{
    public Order(int accountId, long amount, string username, OrderType type)
    {
        AccountId = accountId;
        Amount = amount;
        Username = username;
        Type = type;
    }

    public int AccountId { get; private set; }
    public long Amount { get; private set; }
    public string Username { get; private set; }
    public OrderType Type { get; private set; }
}