namespace RestaurantReservation.API.BusinessLogic.DTOs
{
    public class MenuItemCreateDto
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
