namespace RestaurantReservation.API.BusinessLogic.DTOs
{
    public class RestaurantCreateDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string OpeningHours { get; set; }
    }
}
