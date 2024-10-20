namespace clinic_management_system.Services
{
    public abstract class AbstractClass<T, TDto> where T : class
    {
        protected abstract T MapDtoToEntity(TDto dto);
        protected abstract TDto MapEntityToDto(T entity);
    }
}
