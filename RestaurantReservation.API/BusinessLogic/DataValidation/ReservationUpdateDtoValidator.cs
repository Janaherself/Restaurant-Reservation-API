using FluentValidation;
using RestaurantReservation.API.BusinessLogic.DTOs;

namespace RestaurantReservation.API.BusinessLogic.DataValidation
{
    public class ReservationUpdateDtoValidator : AbstractValidator<ReservationUpdateDto>
    {
        public ReservationUpdateDtoValidator()
        {
            RuleFor(x => x.RestaurantId)
                .GreaterThan(0).WithMessage("Restaurant ID must be greater than zero.");

            RuleFor(x => x.CustomerId)
                .GreaterThan(0).WithMessage("Customer ID must be greater than zero.");

            RuleFor(x => x.TableId)
                .GreaterThan(0).WithMessage("Table ID must be greater than zero.");

            RuleFor(x => x.ReservationDate)
                .GreaterThan(DateTime.Now).WithMessage("Reservation date must be in the future.");

            RuleFor(x => x.PartySize)
                .GreaterThan(0).WithMessage("Party size must be greater than zero.");
        }
    }
}
