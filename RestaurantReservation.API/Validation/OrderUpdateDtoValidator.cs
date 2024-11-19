using FluentValidation;
using RestaurantReservation.API.DTOs;

namespace RestaurantReservation.API.Validation
{
    public class OrderUpdateDtoValidator : AbstractValidator<OrderUpdateDto>
    {
        public OrderUpdateDtoValidator()
        {
            RuleFor(x => x.ReservationId)
                .GreaterThan(0).WithMessage("Reservation ID must be greater than zero.");

            RuleFor(x => x.EmployeeId)
                .GreaterThan(0).WithMessage("Employee ID must be greater than zero.");

            RuleFor(x => x.OrderDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Order date must be now or in the past.");

            RuleFor(x => x.TotalAmount)
                .GreaterThan(0).WithMessage("Total Amount must be greater than zero.");
        }
    }
}
