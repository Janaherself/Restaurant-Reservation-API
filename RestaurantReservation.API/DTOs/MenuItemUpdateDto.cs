namespace RestaurantReservation.API.DTOs
{
    public class MenuItemUpdateDto
    {
        public int RestaurantId { get; set; }
        public string MenuName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
