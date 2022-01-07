using Cinematic.Models.Requests;
using FluentValidation;

namespace Cinematic.Validators
{
   public class UserRequestValidator : AbstractValidator<UserRequest>
    {
        public UserRequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Amount).GreaterThan(1);
        }
    }
}
