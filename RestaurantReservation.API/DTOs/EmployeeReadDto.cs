namespace RestaurantReservation.API.DTOs
{
    public class EmployeeReadDto
    {
        public int EmployeeId { get; set; }
        public int? RestaurantId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeePosition { get; set; }
    }
}
