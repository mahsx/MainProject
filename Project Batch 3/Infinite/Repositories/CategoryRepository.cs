using System.Linq.Expressions;
using batch3.Data;
using batch3.Models;
using Microsoft.EntityFrameworkCore;

namespace batch3.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

    }
}