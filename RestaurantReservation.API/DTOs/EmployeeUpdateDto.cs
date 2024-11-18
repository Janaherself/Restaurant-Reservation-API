namespace RestaurantReservation.API.DTOs
{
    public class EmployeeUpdateDto
    {
        public int RestaurantId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeePosition { get; set; }
    }
}
