using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validation.User
{
    public class UserCreateValidator : AbstractValidator<UserDTO>
    {
        private readonly AspProjContext _context;

        public UserCreateValidator(AspProjContext context)
        {
            _context = context;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email must be a valid email address.")
                .Must(x => !_context.Users.Any(u => u.Email == x)).WithMessage("Email is already in use.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .Matches("(?=.{4,15}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$")
                .WithMessage("Invalid username format.")
                .Must(x => !_context.Users.Any(u => u.Username == x)).WithMessage("Username is already in use.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName is required.")
                .MinimumLength(2).WithMessage("FirstName must be at least 2 characters long.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName is required.")
                .MinimumLength(2).WithMessage("LastName must be at least 2 characters long.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$")
                .WithMessage("Password must have a minimum of eight characters, at least one uppercase letter, one lowercase letter, and one number.");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("BirthDate is required.")
                .Must(x => (DateTime.UtcNow - x).TotalDays > (12 * 365))
                .WithMessage("You have to be at least 12 years old.");
        }
    }
}
