using Learn_RepositoryPattern.DataAccess.Data;
using Learn_RepositoryPattern.DataAccess.Repository.IRepository;
using Learn_RepositoryPattern.Model;

using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace Learn_RepositoryPattern.DataAccess.Repository
{
    public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository
    {
        private ApplicationDbContext _context;


        public ProductTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(ProductType entity)
        {
            _context.ProductType.Update(entity);
        }
    }
}
