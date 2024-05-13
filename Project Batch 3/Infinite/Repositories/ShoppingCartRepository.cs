using System.Linq.Expressions;
using batch3.Data;
using batch3.Models;
using Microsoft.EntityFrameworkCore;

namespace batch3.Repositories
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly AppDbContext _context;
        public ShoppingCartRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

    }
}