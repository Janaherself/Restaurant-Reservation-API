namespace RestaurantReservation.API.BusinessLogic.DTOs
{
    public class TableReadDto
    {
        public int TableId { get; set; }
        public int? RestaurantId { get; set; }
        public int Capacity { get; set; }
    }
}
