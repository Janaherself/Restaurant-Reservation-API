﻿namespace RestaurantReservation.API.BusinessLogic.DTOs
{
    public class OrderItemCreateDto
    {
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
    }
}
