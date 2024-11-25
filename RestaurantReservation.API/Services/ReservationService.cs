using AutoMapper;
using RestaurantReservation.API.DTOs;
using RestaurantReservation.API.RepositoriesInterfaces;
using RestaurantReservation.API.ServicesInterfaces;
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
                TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize)
            };
        }

        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            return await _reservationRepository.GetByIdAsync(id);
        }

        public async Task CreateReservationAsync(ReservationCreateDto reservationCreateDto)
        {
            var reservation = _mapper.Map<Reservation>(reservationCreateDto);
            await _reservationRepository.CreateAsync(reservation);
        }

        public async Task<bool> UpdateReservationAsync(int id, ReservationUpdateDto reservationUpdateDto)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null)
            {
                return false;
            }

            _mapper.Map(reservationUpdateDto, reservation);
            await _reservationRepository.UpdateAsync(reservation);
            return true;
        }

        public async Task<bool> DeleteReservationAsync(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null)
            {
                return false;
            }

            await _reservationRepository.DeleteAsync(reservation);
            return true;
        }

        public async Task<IEnumerable<ReservationReadDto>> GetReservationsByCustomerAsync(int customerId)
        {
            var reservations = await _reservationRepository.GetReservationsByCustomerAsync(customerId);
            if (!reservations.Any())
            {
                return null;
            }

            var reservationsList = _mapper.Map<IEnumerable<ReservationReadDto>>(reservations);
            return reservationsList;
        }

        public async Task<IEnumerable<ReservationView>> ListReservationViewAsync()
        {
            return await _reservationRepository.ListReservationViewAsync();
        }
    }
}