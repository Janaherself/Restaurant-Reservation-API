using FluentValidation;
using RestaurantReservation.API.DTOs;

namespace RestaurantReservation.API.Validation
{
    public class OrderCreateDtoValidator : AbstractValidator<OrderCreateDto>
    {
        public OrderCreateDtoValidator()
        {
            RuleFor(x => x.ReservationId)
                .NotEmpty().WithMessage("Reservation ID is required.")
                .GreaterThan(0).WithMessage("Reservation ID must be greater than zero.");

            RuleFor(x => x.EmployeeId)
                .NotEmpty().WithMessage("Employee ID is required.")
                .GreaterThan(0).WithMessage("Employee ID must be greater than zero.");

            RuleFor(x => x.OrderDate)
                .NotEmpty().WithMessage("Order date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Order date must be now or in the past.");

            RuleFor(x => x.TotalAmount)
                .NotEmpty().WithMessage("Total Amount is required.")
                .GreaterThan(0).WithMessage("Total Amount must be greater than zero.");
        }
    }

}
