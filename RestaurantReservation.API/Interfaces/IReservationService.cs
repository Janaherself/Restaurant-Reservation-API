﻿using RestaurantReservation.API.DTOs;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Interfaces
{
    public interface IReservationService
    {
        Task CreateReservationAsync(ReservationCreateDto reservationCreateDto);
        Task<bool> DeleteReservationAsync(int id);
        Task<PaginatedResult<ReservationReadDto>> GetAllReservationsAsync(int pageNumber, int pageSize);
        Task<Reservation> GetReservationByIdAsync(int id);
        Task<bool> UpdateReservationAsync(int id, ReservationUpdateDto reservationUpdateDto);
        Task<IEnumerable<ReservationReadDto>> GetReservationsByCustomerAsync(int customerId);
        Task<IEnumerable<ReservationView>> ListReservationViewAsync();
    }
}