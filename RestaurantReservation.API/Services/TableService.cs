using AutoMapper;
using RestaurantReservation.API.DTOs;
using RestaurantReservation.API.Interfaces;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Services
{
    public class TableService(ITableRepository TableRepository, IMapper mapper) : ITableService
    {
        private readonly ITableRepository _tableRepository = TableRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PaginatedResult<TableReadDto>> GetAllTablesAsync(int pageNumber, int pageSize)
        {
            var totalRecords = await _tableRepository.CountAsync();
            var tables = await _tableRepository.GetAllAsync(pageNumber, pageSize);

            var tablesDtos = _mapper.Map<List<TableReadDto>>(tables);

            return new PaginatedResult<TableReadDto>
            {
                Items = tablesDtos,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize)
            };
        }

        public async Task<Table> GetTableByIdAsync(int id)
        {
            return await _tableRepository.GetByIdAsync(id);
        }

        public async Task CreateTableAsync(Table table)
        {
            await _tableRepository.CreateAsync(table);
        }

        public async Task UpdateTableAsync(Table table)
        {
            await _tableRepository.UpdateAsync(table);
        }

        public async Task<bool> DeleteTableAsync(int id)
        {
            var table = await _tableRepository.GetByIdAsync(id);
            if (table == null)
            {
                return false;
            }

            await _tableRepository.DeleteAsync(table);
            return true;
        }
    }
}