﻿using RestaurantReservation.API.Interfaces;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Services
{
    public class TableService(ITableRepository TableRepository) : ITableService
    {
        private readonly ITableRepository _tableRepository = TableRepository;

        public async Task<IEnumerable<Table>> GetAllTablesAsync()
        {
            return await _tableRepository.GetAllAsync();
        }

        public async Task<Table> GetTableByIdAsync(int id)
        {
            return await _tableRepository.GetByIdAsync(id);
        }

        public async Task CreateTableAsync(Table table)
        {
            // data validation goes here
            await _tableRepository.CreateAsync(table);
        }

        public async Task UpdateTableAsync(Table table)
        {
            // validation
            await _tableRepository.UpdateAsync(table);
        }

        public async Task<bool> DeleteTableAsync(int id)
        {
            // validation
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