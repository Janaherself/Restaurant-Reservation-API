using RestaurantReservation.API.DTOs;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface ITableService
    {
        Task CreateTableAsync(Table table);
        Task<bool> DeleteTableAsync(int id);
        Task<PaginatedResult<TableReadDto>> GetAllTablesAsync(int pageNumber, int pageSize);
        Task<Table> GetTableByIdAsync(int id);
        Task UpdateTableAsync(Table table);
    }
}