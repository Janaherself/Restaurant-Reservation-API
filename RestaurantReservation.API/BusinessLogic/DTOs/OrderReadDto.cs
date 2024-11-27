using RestaurantReservation.Db.DataModels;

namespace RestaurantReservation.API.BusinessLogic.DTOs
{
    public class OrderReadDto
    {
        public int OrderId { get; set; }
        public int? ReservationId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public IEnumerable<MenuItemReadDto> MenuItems { get; set; }
    }
}
