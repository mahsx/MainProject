using System.Linq.Expressions;
using batch3.Data;
using batch3.Models;
using Microsoft.EntityFrameworkCore;

namespace batch3.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly AppDbContext _context;
        public CompanyRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

    }
}