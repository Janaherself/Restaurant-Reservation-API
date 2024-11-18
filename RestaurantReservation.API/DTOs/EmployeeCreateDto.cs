namespace RestaurantReservation.API.DTOs
{
    public class EmployeeCreateDto
    {
        public int EmployeeRestaurantId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeePosition { get; set; }
    }
}
