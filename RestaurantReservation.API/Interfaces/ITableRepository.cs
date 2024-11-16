using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface ITableRepository
    {
        Task CreateAsync(Table table);
        Task DeleteAsync(int id);
        Task<IEnumerable<Table>> GetAllAsync();
        Task<Table> GetByIdAsync(int id);
        Task UpdateAsync(Table table);
    }
}