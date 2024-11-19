using FluentValidation;
using RestaurantReservation.API.DTOs;

namespace RestaurantReservation.API.Validation
{
    public class TableUpdateDtoValidator : AbstractValidator<TableUpdateDto>
    {
        public TableUpdateDtoValidator()
        {
            RuleFor(x => x.RestaurantId)
                 .GreaterThan(0).WithMessage("Restaurant ID must be greater than zero.");

            RuleFor(x => x.Capacity)
                .GreaterThan(0).WithMessage("Table capacity must be greater than zero.");
        }
    }
}
