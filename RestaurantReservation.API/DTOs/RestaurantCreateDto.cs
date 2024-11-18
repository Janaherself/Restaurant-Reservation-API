namespace RestaurantReservation.API.DTOs
{
    public class RestaurantCreateDto
    {
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public string RestaurantPhoneNumber { get; set; }
        public string OpeningHours { get; set; }
    }
}
