﻿using AutoMapper;
using RestaurantReservation.API.BusinessLogic.DTOs;
using RestaurantReservation.API.BusinessLogic.ServicesInterfaces;
using RestaurantReservation.API.DataAccess.RepositoriesInterfaces;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.BusinessLogic.Services
{
    public class TableService(ITableRepository _tableRepository, IMapper _mapper) : ITableService
    {
        public async Task<PaginatedResult<TableReadDto>> GetAllTablesAsync(int pageNumber, int pageSize)
        {
            var totalRecords = await _tableRepository.CountAsync();
            var tables = await _tableRepository.GetAllAsync(pageNumber, pageSize);

            var tablesDtos = _mapper.Map<IEnumerable<TableReadDto>>(tables);

            return new PaginatedResult<TableReadDto>
            {
                Items = tablesDtos,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize)
            };
        }

        public async Task<TableReadDto> GetTableByIdAsync(int id)
        {
            return _mapper.Map<TableReadDto>(await _tableRepository.GetByIdAsync(id));
        }

        public async Task CreateTableAsync(TableCreateDto tableCreateDto)
        {
            var table = _mapper.Map<Table>(tableCreateDto);
            await _tableRepository.CreateAsync(table);
        }

        public async Task<bool> UpdateTableAsync(int id, TableUpdateDto tableUpdateDto)
        {
            var table = await _tableRepository.GetByIdAsync(id);
            if (table == null)
            {
                return false;
            }

            _mapper.Map(tableUpdateDto, table);
            await _tableRepository.UpdateAsync(table);
            return true;
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