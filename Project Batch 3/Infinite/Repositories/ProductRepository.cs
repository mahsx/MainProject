using System.Linq.Expressions;
using batch3.Data;
using batch3.Models;
using Microsoft.EntityFrameworkCore;

namespace batch3.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

    }
}