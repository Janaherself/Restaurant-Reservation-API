﻿namespace RestaurantReservation.API.BusinessLogic.DTOs
{
    public class ReservationUpdateDto
    {
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public int TableId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int PartySize { get; set; }
    }
}