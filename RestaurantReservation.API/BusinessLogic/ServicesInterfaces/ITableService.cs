using RestaurantReservation.API.BusinessLogic.DTOs;

namespace RestaurantReservation.API.BusinessLogic.ServicesInterfaces
{
    public interface ITableService
    {
        Task CreateTableAsync(TableCreateDto tableCreateDto);
        Task<bool> DeleteTableAsync(int id);
        Task<PaginatedResult<TableReadDto>> GetAllTablesAsync(int pageNumber, int pageSize);
        Task<TableReadDto> GetTableByIdAsync(int id);
        Task<bool> UpdateTableAsync(int id, TableUpdateDto tableUpdateDto);
    }
}