using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDb _ctx;
        private readonly ShoppingCartRepository _shoppingCart;

        public OrderRepository(ApplicationDb ctx, ShoppingCartRepository shoppingCart)
        {
            _ctx = ctx;
            _shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _ctx.Orders.AddAsync(order);

            var shoppingCartItems = _shoppingCart.shoppingCartItems;

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Order = order,//blad wystepowal bo encje powinienem caly obiekt przekazac i automatycznie bo Id sie oznaczylo, a nie przekazywac samo id
                    Amount = item.Quantity,
                    ProductId = item.Product.Id,

                    Price = item.Product.Value
                };
                 _ctx.OrderDetails.AddAsync(orderDetail);
            }
             _ctx.SaveChangesAsync();
        }
    }
}
