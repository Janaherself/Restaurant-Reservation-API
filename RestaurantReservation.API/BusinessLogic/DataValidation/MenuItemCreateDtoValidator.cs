using FluentValidation;
using RestaurantReservation.API.BusinessLogic.DTOs;

namespace RestaurantReservation.API.BusinessLogic.DataValidation
{
    public class MenuItemCreateDtoValidator : AbstractValidator<MenuItemCreateDto>
    {
        public MenuItemCreateDtoValidator()
        {
            RuleFor(x => x.RestaurantId)
                .NotEmpty().WithMessage("Restaurant ID is required.")
                .GreaterThan(0).WithMessage("Restaurant ID must be greater than zero.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Menu item name is required.")
                .MaximumLength(100).WithMessage("Menu item name cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Menu item description cannot exceed 500 characters.");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price is required.")
                .GreaterThan(0).WithMessage("Price must be greater than zero.");
        }
    }

}
