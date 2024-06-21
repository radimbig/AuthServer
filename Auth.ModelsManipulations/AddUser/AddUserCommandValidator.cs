using FluentValidation;
namespace Auth.ModelsManipulations.AddUser
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator() 
        {
            RuleFor(x => x.Password)
           .NotEmpty().WithMessage("Password is required.")
           .Length(6, 20).WithMessage("Password must be between 6 and 20 characters.")
           .Matches(@"^[a-zA-Z0-9]*$").WithMessage("Password can only contain English letters and numbers.")
           .Matches(@"[A-Za-z]").WithMessage("Password must contain at least one letter.")
           .Matches(@"\d").WithMessage("Password must contain at least one number.");

            RuleFor(x => x.Email)
           .NotEmpty().WithMessage("Email is required.")
           .EmailAddress().WithMessage("Email is not valid.");
        }
    }
}
