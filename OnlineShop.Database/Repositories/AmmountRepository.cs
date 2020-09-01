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

        public  Task<int> DeleteProduct(int id)
        {
            var ammount = _ctx.Ammmounts.Where(i => i.ProductId == id).FirstOrDefault();
            _ctx.Ammmounts.Remove(ammount);
            return  _ctx.SaveChangesAsync();
        }
    }
}
