using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface ITableRepository
    {
        Task CreateAsync(Table table);
        Task DeleteAsync(Table table);
        Task<IEnumerable<Table>> GetAllAsync(int pageNumber, int pageSize);
        Task<Table> GetByIdAsync(int id);
        Task UpdateAsync(Table table);
        Task<int> CountAsync();
    }
}