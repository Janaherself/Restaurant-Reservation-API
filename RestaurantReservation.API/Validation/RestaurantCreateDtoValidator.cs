using FluentValidation;
using RestaurantReservation.API.DTOs;

namespace RestaurantReservation.API.Validation
{
    public class RestaurantCreateDtoValidator : AbstractValidator<RestaurantCreateDto>
    {
        public RestaurantCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Restaurant name is required.")
                .MaximumLength(100).WithMessage("Restaurant name cannot exceed 100 characters.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(200).WithMessage("Address cannot exceed 200 characters.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format.");

            RuleFor(x => x.OpeningHours)
                .NotEmpty().WithMessage("Opening hours is required.");
        }
    }

}
