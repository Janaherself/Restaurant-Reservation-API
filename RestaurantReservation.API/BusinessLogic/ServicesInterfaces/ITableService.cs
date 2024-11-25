using RestaurantReservation.API.BusinessLogic.DTOs;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.BusinessLogic.ServicesInterfaces
{
    public interface ITableService
    {
        Task CreateTableAsync(TableCreateDto tableCreateDto);
        Task<bool> DeleteTableAsync(int id);
        Task<PaginatedResult<TableReadDto>> GetAllTablesAsync(int pageNumber, int pageSize);
        Task<Table> GetTableByIdAsync(int id);
        Task<bool> UpdateTableAsync(int id, TableUpdateDto tableUpdateDto);
    }
}