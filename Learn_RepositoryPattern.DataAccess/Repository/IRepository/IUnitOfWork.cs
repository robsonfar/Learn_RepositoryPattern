namespace Learn_RepositoryPattern.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IProductTypeRepository ProductTypeRepository { get; }

        void Save();
    }
}
