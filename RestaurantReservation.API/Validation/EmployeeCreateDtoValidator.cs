using FluentValidation;
using RestaurantReservation.API.DTOs;

namespace RestaurantReservation.API.Validation
{
    public class EmployeeCreateDtoValidator : AbstractValidator<EmployeeCreateDto>
    {
        public EmployeeCreateDtoValidator()
        {
            RuleFor(x => x.RestaurantId)
                .NotEmpty().WithMessage("Restaurant ID is required.")
                .GreaterThan(0).WithMessage("Restaurant ID must be greater than zero.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

            RuleFor(x => x.Position)
                .NotEmpty().WithMessage("Position is required.")
                .MaximumLength(50).WithMessage("Position cannot exceed 50 characters.");
        }
    }

}
