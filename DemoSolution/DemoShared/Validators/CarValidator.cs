using DemoShared.Entities;
using FluentValidation;

namespace DemoShared.Validators;

public class CarValidator : AbstractValidator<Car>
{
    public CarValidator()
    {
        RuleFor(x => x.Make).NotEmpty().WithMessage("Vul in aub");
        RuleFor(x => x.Make).MaximumLength(50).WithMessage("Max 50 karaters graag");
        RuleFor(x => x.Model).NotEmpty().WithMessage("Vul in aub");
        RuleFor(x => x.Model).MaximumLength(50).WithMessage("Max 50 karaters graag");

        When(x => x.Year < 2000, () =>
        {
            RuleFor(x => x.PhotoUrl).NotEmpty().WithMessage("Foto is verplicht bij oude wrakken");
        });
    }
}
