﻿namespace RestaurantReservation.API.DTOs
{
    public class RestaurantUpdateDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string OpeningHours { get; set; }
    }
}