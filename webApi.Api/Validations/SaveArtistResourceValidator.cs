using FluentValidation;
using webApi.Api.Resources;

namespace webApi.Api.Validations
{
    public class SaveArtistResourceValidator : AbstractValidator<SaveArtistResource>
    {
        public SaveArtistResourceValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Name must not be empty");
            RuleFor(a => a.Name).NotEmpty().MaximumLength(50).WithMessage("Name must not be empty");
        }
    }
}