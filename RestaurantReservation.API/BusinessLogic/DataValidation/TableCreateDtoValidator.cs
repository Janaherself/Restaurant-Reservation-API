using FluentValidation;
using RestaurantReservation.API.BusinessLogic.DTOs;

namespace RestaurantReservation.API.BusinessLogic.DataValidation
{
    public class TableCreateDtoValidator : AbstractValidator<TableCreateDto>
    {
        public TableCreateDtoValidator()
        {
            RuleFor(x => x.RestaurantId)
                 .NotEmpty().WithMessage("Restaurant ID is required.")
                 .GreaterThan(0).WithMessage("Restaurant ID must be greater than zero.");

            RuleFor(x => x.Capacity)
                .NotEmpty().WithMessage("Restaurant ID is required.")
                .GreaterThan(0).WithMessage("Table capacity must be greater than zero.");
        }
    }

}
