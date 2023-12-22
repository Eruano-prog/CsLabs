using Lab5.Application.Models.Transactions;

namespace Lab5.Application.Abstractions.Repositories;

public interface IOrderRepository
{
    void AddOrder(Order transaction);
    IEnumerable<Order>? GetHistoryByUser(string username);
}