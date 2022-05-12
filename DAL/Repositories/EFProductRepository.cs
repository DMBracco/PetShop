using BLL.Entities;
using BLL.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ShopContext _context;

        public EFProductRepository(ShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Product> GetFullList()
        {
            var list = _context.Products.Include(s => s.ProductType).Include(s => s.Manufacturer).Include(s => s.SupplyForProducts);

            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
