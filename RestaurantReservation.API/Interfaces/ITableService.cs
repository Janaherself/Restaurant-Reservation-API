using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface ITableService
    {
        Task CreateTableAsync(Table table);
        Task<bool> DeleteTableAsync(int id);
        Task<IEnumerable<Table>> GetAllTablesAsync();
        Task<Table> GetTableByIdAsync(int id);
        Task UpdateTableAsync(Table table);
    }
}