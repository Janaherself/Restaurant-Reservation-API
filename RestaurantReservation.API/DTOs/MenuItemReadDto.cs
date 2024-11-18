namespace RestaurantReservation.API.DTOs
{
    public class MenuItemReadDto
    {
        public int MenuItemId { get; set; }
        public int? RestaurantId { get; set; }
        public string MenuItemName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
