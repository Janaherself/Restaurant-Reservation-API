using RestaurantReservation.API.BusinessLogic.DTOs;

namespace RestaurantReservation.API.BusinessLogic.ServicesInterfaces
{
    public interface IReservationService
    {
        Task CreateReservationAsync(ReservationCreateDto reservationCreateDto);
        Task<bool> DeleteReservationAsync(int id);
        Task<PaginatedResult<ReservationReadDto>> GetAllReservationsAsync(int pageNumber, int pageSize);
        Task<ReservationReadDto> GetReservationByIdAsync(int id);
        Task<bool> UpdateReservationAsync(int id, ReservationUpdateDto reservationUpdateDto);
        Task<IEnumerable<ReservationReadDto>?> GetReservationsByCustomerAsync(int customerId);
    }
}