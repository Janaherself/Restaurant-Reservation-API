using FluentValidation;
using RestaurantReservation.API.BusinessLogic.DTOs;

namespace RestaurantReservation.API.BusinessLogic.DataValidation
{
    public class OrderItemUpdateDtoValidator : AbstractValidator<OrderItemUpdateDto>
    {
        public OrderItemUpdateDtoValidator()
        {
            RuleFor(x => x.MenuItemId)
                .GreaterThan(0).WithMessage("Menu Item ID must be greater than zero.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
        }
    }
}
