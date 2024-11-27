namespace RestaurantReservation.API.BusinessLogic.DTOs
{
    public class OrderItemReadDto
    {
        public int OrderItemId { get; set; }
        public int? MenuItemId { get; set; }
        public int Quantity { get; set; }
    }
}
