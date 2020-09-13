using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Repositories
{
    public class CheckoutRepository : ICheckoutRepository
    {
        private readonly ApplicationDb _ctx;
        public CheckoutRepository(ApplicationDb ctx)
        {
            _ctx = ctx;
        }
        public async Task CreateOrder(Order order, List<ShoppingCartItem> shoppingCartItems)
        {
            order.OrderPlaced = DateTime.Now;
            _ctx.Orders.Add(order);

            var mainShoppingCartItems = shoppingCartItems;

            foreach (var item in mainShoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Order = order,
                    Amount = item.Quantity,
                    ProductId = item.Product.Id,

                    Price = item.Product.Value
                };
               await _ctx.OrderDetails.AddAsync(orderDetail);
            }
           await _ctx.SaveChangesAsync();
        }
    }
}
