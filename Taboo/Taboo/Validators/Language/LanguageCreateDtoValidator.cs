using FluentValidation;
using Taboo.DTOs.Languages;

namespace Taboo.Validators.Language
{
    public class LanguageCreateDtoValidator : AbstractValidator<LanguageCreateDto>
    {
        public LanguageCreateDtoValidator() 
        {
            RuleFor(x => x.Code)
                .NotNull()
                .NotEmpty()
                .WithMessage("Code cannot be empty")
                .MaximumLength(2)
                .WithMessage("The length should not be more than 2");

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name cannot be empty")
                .MaximumLength(64)
                .WithMessage("The length should not be more than 64");

            RuleFor(x => x.IconUrl)
                .NotNull()
                .NotEmpty()
                .WithMessage("IcorUrl cannot be empty")
                .Matches("^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$")
                .WithMessage("Icon must be link")
                .MaximumLength(128)
                .WithMessage("The lenth should not be more than 128");
        }
    }
}
