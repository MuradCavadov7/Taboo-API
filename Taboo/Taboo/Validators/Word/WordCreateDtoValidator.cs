using FluentValidation;
using Taboo.DTOs.Words;
using Taboo.Enums;

namespace Taboo.Validators.Word
{
    public class WordCreateDtoValidator : AbstractValidator<WordCreateDto>
    {
        public WordCreateDtoValidator() 
        {
            RuleFor(x=>x.Text)
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
                .Must(x=>x.Count()==(int)GameLevel.Hard)
                .WithMessage($"Forbidden word must be {(int)GameLevel.Hard} words")
                .MaximumLength(32)
                .WithMessage("The length of words in the banned words cannot be greater than 32");
                
        }
    }
}
