﻿namespace RestaurantReservation.API.BusinessLogic.DTOs
{
    public class EmployeeReadDto
    {
        public int EmployeeId { get; set; }
        public int? RestaurantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
    }
}
