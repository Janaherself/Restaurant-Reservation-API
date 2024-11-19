﻿namespace RestaurantReservation.API.DTOs
{
    public class OrderReadDto
    {
        public int OrderId { get; set; }
        public int? ReservationId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}