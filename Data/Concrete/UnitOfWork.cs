using Data.Abstract;
using Data.Concrete.EntityFramework.Context;
using Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private EfProductRepository _productRepository;
        private EfCategoryRepository _categoryRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
           
        }

        public IProductRepository Product => _productRepository ?? new EfProductRepository(_context);

        public ICategoryRepository Category => _categoryRepository ?? new EfCategoryRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
