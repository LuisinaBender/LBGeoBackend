namespace LBGeoBackend.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        public Task<List<T>?> GetAllAsync(string? filtro);
        public Task<T?> GetByIdAsync(int id);
        public Task<T?> AddAsync(T? entity);
        public Task UpdateAsync(T? entity);
        public Task DeleteAsync(int id);
    }
}
