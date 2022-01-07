using Cinematic.Models.Requests;
using FluentValidation;

namespace Cinematic.Validators
{
    public class MovieRequestValidator:AbstractValidator<MovieRequest>
    {
        public MovieRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Genre).NotEmpty();
            RuleFor(x => x.Rating).IsInEnum();
            RuleFor(x => x.Duration).NotNull();
        }
    }
}
