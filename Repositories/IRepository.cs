namespace clinic_management_system.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> FindAllAsync();
        Task<T> FindByIdAsync(object id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
