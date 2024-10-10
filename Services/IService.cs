namespace clinic_management_system.Services
{
    public interface IService<TDto> where TDto : class
    {
        Task<IEnumerable<TDto>> FetchAllAsync();
        Task<TDto> FetchByIdAsync(object id);
        Task AddAsync(TDto dto);
        Task UpdateAsync(TDto dto);
        Task DeleteAsync(object id);
    }
}
