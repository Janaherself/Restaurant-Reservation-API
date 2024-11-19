using FluentValidation;
using RestaurantReservation.API.DTOs;

namespace RestaurantReservation.API.Validation
{
    public class RestaurantUpdateDtoValidator : AbstractValidator<RestaurantUpdateDto>
    {
        public RestaurantUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(100).WithMessage("Restaurant name cannot exceed 100 characters.");

            RuleFor(x => x.Address)
                .MaximumLength(200).WithMessage("Address cannot exceed 200 characters.");

            RuleFor(x => x.PhoneNumber)
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format.");
        }
    }
}
