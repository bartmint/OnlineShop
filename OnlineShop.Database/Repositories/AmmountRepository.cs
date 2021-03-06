﻿using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Repositories
{

    public class AmmountRepository : IAmmountRepository
    {
        public ApplicationDb _ctx;
        public AmmountRepository(ApplicationDb ctx)
        {
            _ctx = ctx;
        }

        public async Task DeleteAmmount(int id)
        {
            var ammount = _ctx.Ammounts.FirstOrDefault(p => p.ProductId == id);

            _ctx.Ammounts.Remove(ammount);
            await _ctx.SaveChangesAsync();
        }
        public async Task RemoveOne(int id)
        {
            var ammount = await _ctx.Ammounts.FirstOrDefaultAsync(p => p.ProductId == id);
            if (ammount.Quantity > 0)
            {
                ammount.Quantity--;
            }
            _ctx.Ammounts.Update(ammount);
            await _ctx.SaveChangesAsync();
        }
    }
}
