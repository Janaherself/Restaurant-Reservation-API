using FluentValidation;
using RestaurantReservation.API.BusinessLogic.DTOs;

namespace RestaurantReservation.API.BusinessLogic.DataValidation
{
    public class ReservationCreateDtoValidator : AbstractValidator<ReservationCreateDto>
    {
        public ReservationCreateDtoValidator()
        {
            RuleFor(x => x.RestaurantId)
                .NotEmpty().WithMessage("Restaurant ID is required.")
                .GreaterThan(0).WithMessage("Restaurant ID must be greater than zero.");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer ID is required.")
                .GreaterThan(0).WithMessage("Customer ID must be greater than zero.");

            RuleFor(x => x.TableId)
                .NotEmpty().WithMessage("Table ID is required.")
                .GreaterThan(0).WithMessage("Table ID must be greater than zero.");

            RuleFor(x => x.ReservationDate)
                .NotEmpty().WithMessage("Reservation date is required.")
                .GreaterThan(DateTime.Now).WithMessage("Reservation date must be in the future.");

            RuleFor(x => x.PartySize)
                .NotEmpty().WithMessage("Party size is required.")
                .GreaterThan(0).WithMessage("Party size must be in the future.");
        }
    }

}
