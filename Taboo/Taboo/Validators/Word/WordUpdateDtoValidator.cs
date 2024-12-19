using FluentValidation;
using Taboo.DTOs.Words;

namespace Taboo.Validators.Word;

public class WordUpdateDtoValidator :AbstractValidator<WordUpdateDto>
{
    public WordUpdateDtoValidator()
    {
        RuleFor(x => x.Text)
            .NotNull()
            .NotEmpty()
            .WithMessage("Text cannot be empty")
            .MaximumLength(32)
            .WithMessage("The length should not be more than 32");

        RuleFor(x => x.BannedWords)
            .NotNull()
            .NotEmpty()
            .WithMessage("BannedWords cannot be empty");

        RuleForEach(x => x.BannedWords)
            .NotNull()
            .NotEmpty()
            .WithMessage("Words in the forbidden words cannot be empty")
            .MaximumLength(32)
            .WithMessage("The length of words in the banned words cannot be greater than 32");

    }

}
