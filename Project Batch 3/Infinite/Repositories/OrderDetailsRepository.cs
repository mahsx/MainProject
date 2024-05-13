using System.Linq.Expressions;
using batch3.Data;
using batch3.Models;
using Microsoft.EntityFrameworkCore;

namespace batch3.Repositories
{
    public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
    {
        private readonly AppDbContext _context;
        public OrderDetailsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

    }
}