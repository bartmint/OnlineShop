using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Models;
using OnlineShop.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Infrastructure.Repositories
{
    public class OrderManagerRepository
    {
        private readonly ApplicationDb _ctx;
        public OrderManagerRepository(ApplicationDb ctx)
        {
            _ctx = ctx;
        }
        //znalezc zamowienie
        public OrderDetail GetOrderById(string id)
        {
        } 
    }
}
