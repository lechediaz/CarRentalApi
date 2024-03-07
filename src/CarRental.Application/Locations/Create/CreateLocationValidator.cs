using FluentValidation;

namespace CarRental.Application.Locations.Create;

public class CreateLocationValidator : AbstractValidator<CreateLocationCommand>
{
    public CreateLocationValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MaximumLength(60);
    }
}