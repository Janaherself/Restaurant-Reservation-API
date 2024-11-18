namespace RestaurantReservation.API.DTOs
{
    public class RestaurantReadDto
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public string RestaurantPhoneNumber { get; set; }
        public string OpeningHours { get; set; }
    }
}
