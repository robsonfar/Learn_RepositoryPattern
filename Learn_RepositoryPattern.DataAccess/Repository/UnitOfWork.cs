using Learn_RepositoryPattern.DataAccess.Data;
using Learn_RepositoryPattern.DataAccess.Repository.IRepository;

namespace Learn_RepositoryPattern.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

        public IProductTypeRepository ProductTypeRepository { get; private set; }


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            ProductTypeRepository = new ProductTypeRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
