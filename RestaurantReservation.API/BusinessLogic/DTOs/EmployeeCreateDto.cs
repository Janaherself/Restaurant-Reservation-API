namespace RestaurantReservation.API.BusinessLogic.DTOs
{
    public class EmployeeCreateDto
    {
        public int RestaurantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
    }
}
