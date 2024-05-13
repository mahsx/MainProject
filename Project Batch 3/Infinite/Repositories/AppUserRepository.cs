using System.Linq.Expressions;
using batch3.Data;
using batch3.Models;
using Microsoft.EntityFrameworkCore;

namespace batch3.Repositories
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        private readonly AppDbContext _context;
        public AppUserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

    }
}