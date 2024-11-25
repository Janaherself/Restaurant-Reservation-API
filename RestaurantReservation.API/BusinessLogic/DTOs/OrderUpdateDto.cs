namespace RestaurantReservation.API.BusinessLogic.DTOs
{
    public class OrderUpdateDto
    {
        public int ReservationId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
