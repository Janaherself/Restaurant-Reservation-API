using AutoMapper;
using RestaurantReservation.API.DTOs;
using RestaurantReservation.API.Interfaces;
using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.Services
{
    public class ReservationService(IReservationRepository ReservationRepository, IMapper mapper) : IReservationService
    {
        private readonly IReservationRepository _reservationRepository = ReservationRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PaginatedResult<ReservationReadDto>> GetAllReservationsAsync(int pageNumber, int pageSize)
        {
            var totalRecords = await _reservationRepository.CountAsync();
            var reservations = await _reservationRepository.GetAllAsync(pageNumber, pageSize);

            var reservationDtos = _mapper.Map<List<ReservationReadDto>>(reservations);

            return new PaginatedResult<ReservationReadDto>
            {
                Items = reservationDtos,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalRecords / pageSize)
            };
        }

        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            return await _reservationRepository.GetByIdAsync(id);
        }

        public async Task CreateReservationAsync(Reservation reservation)
        {
            // data validation goes here
            await _reservationRepository.CreateAsync(reservation);
        }

        public async Task UpdateReservationAsync(Reservation reservation)
        {
            // validation
            await _reservationRepository.UpdateAsync(reservation);
        }

        public async Task<bool> DeleteReservationAsync(int id)
        {
            // validation
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null)
            {
                return false;
            }

            await _reservationRepository.DeleteAsync(reservation);
            return true;
        }

        public async Task<IEnumerable<Reservation>>? GetReservationsByCustomerAsync(int customerId)
        {
            var reservations = await _reservationRepository.GetReservationsByCustomerAsync(customerId);
            if (!reservations.Any())
            {
                return null;
            }
            return reservations;
        }

        public async Task<IEnumerable<ReservationView>> ListReservationViewAsync()
        {
            return await _reservationRepository.ListReservationViewAsync();
        }
    }
}