namespace ForecAPI.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
