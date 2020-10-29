using FluentValidation;
using webApi.Api.Resources;

namespace webApi.Api.Validations
{
    public class SaveMusicResourceValidator : AbstractValidator<SaveMusicResource>
    {
        public SaveMusicResourceValidator()
        {
            RuleFor(m => m.Name).NotEmpty().MaximumLength(50).WithMessage("Name must not be empty");
            RuleFor(m => m.ArtistId).NotEmpty().WithMessage("'Artist Id' must not be 0.");
        }
    }
}