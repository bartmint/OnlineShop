using OnlineShop.Domain.Models;

namespace OnlineShop.Domain.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
