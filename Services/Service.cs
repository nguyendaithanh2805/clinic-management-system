
using clinic_management_system.Repositories;
using System.Collections.Generic;

namespace clinic_management_system.Services
{
    public abstract class Service<T, TDto> : IService<TDto> where TDto : class where T : class
    {
        private readonly IRepository<T> _repository;
        private readonly ILogger<Service<T, TDto>> _logger;

        protected Service(IRepository<T> repository, ILogger<Service<T, TDto>> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task AddAsync(TDto dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            _logger.LogInformation($"Saved {typeof(T).Name} successfully!");
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await _repository.FindByIdAsync(id);
            if (entity is null) throw new KeyNotFoundException($"{typeof(T).Name} with '{id}' not found.");
            await _repository.DeleteAsync(entity);
            _logger.LogInformation($"Deleted {typeof(T).Name} successfully!");
        }

        public async Task<IEnumerable<TDto>> FetchAllAsync()
        {
            var entities = await _repository.FindAllAsync();
            return MapToDto(entities);
        }

        public async Task<TDto> FetchByIdAsync(object id)
        {
            var entity = await _repository.FindByIdAsync(id);
            if (entity is null) throw new KeyNotFoundException($"{typeof(T).Name} with '{id}' not found.");
            return MapToDto(entity);
        }

        public async Task UpdateAsync(object id, TDto dto)
        {
            var existingEntity = await _repository.FindByIdAsync(id);
            if (existingEntity is null) throw new KeyNotFoundException($"{typeof(T).Name} with ID '{id}' not found.");
            existingEntity = UpdateEntityWithDto(existingEntity, dto);
            await _repository.UpdateAsync(existingEntity);
            _logger.LogInformation($"updated {typeof(T).Name} successfully!");
        }

        protected abstract T MapToEntity(TDto dto);
        protected abstract TDto MapToDto(T entity);
        protected abstract IEnumerable<TDto> MapToDto(IEnumerable<T> entities);
        protected abstract T UpdateEntityWithDto(T existingEntity, TDto dto);
    }
}
