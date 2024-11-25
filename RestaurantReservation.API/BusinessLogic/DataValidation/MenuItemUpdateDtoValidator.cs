using FluentValidation;
using RestaurantReservation.API.BusinessLogic.DTOs;

namespace RestaurantReservation.API.BusinessLogic.DataValidation
{
    public class MenuItemUpdateDtoValidator : AbstractValidator<MenuItemUpdateDto>
    {
        public MenuItemUpdateDtoValidator()
        {
            RuleFor(x => x.RestaurantId)
                .GreaterThan(0).WithMessage("Restaurant ID must be greater than zero.");

            RuleFor(x => x.Name)
                .MaximumLength(100).WithMessage("Menu item name cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Menu item description cannot exceed 500 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");
        }
    }
}
