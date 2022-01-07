using Cinematic.Models.Requests;
using FluentValidation;

namespace Cinematic.Validators
{
    public  class SeriesRequestValidator: AbstractValidator<SeriesRequest>
    {
        public SeriesRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Genre).NotEmpty();
            RuleFor(x => x.Rating).IsInEnum();
            RuleFor(x => x.Duration).NotNull();
            RuleFor(x => x.seasons).GreaterThan(0);
        }
    }
}
