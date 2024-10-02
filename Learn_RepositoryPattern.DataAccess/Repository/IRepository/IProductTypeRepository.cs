using Learn_RepositoryPattern.Model;

namespace Learn_RepositoryPattern.DataAccess.Repository.IRepository
{
    public interface IProductTypeRepository : IRepository<ProductType>
    {
        void Update(ProductType entity);
    }
}
