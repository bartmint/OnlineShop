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
            var ammount = _ctx.Ammounts.FirstOrDefault(p => p.ProductId == id);
            _ctx.Ammounts.Remove(ammount);
            return  _ctx.SaveChangesAsync();
        }
    }
}
