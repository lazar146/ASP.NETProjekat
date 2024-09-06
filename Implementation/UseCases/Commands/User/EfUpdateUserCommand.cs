using Application.UseCases.Commands.User;
using Application.UseCases.DTO;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validation.User;

namespace Implementation.UseCases.Commands.User
{
    public class EfUpdateUserCommand : EfUseCase, IUpdateUserCommand
    {
        private UserCreateValidator _validator;

        public EfUpdateUserCommand(AspProjContext context, UserCreateValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 25;

        public string Name => "Update User";

        public string Description => "Update User Command";

        public void Execute(UserDTO request)
        {
            _validator.ValidateAndThrow(request);

            var existingUser = Context.Users.FirstOrDefault(x => x.Id == request.Id);

            if (existingUser == null)
            {
                throw new Exception("User not found.");
            }

            if (!string.IsNullOrEmpty(request.Email))
            {
                existingUser.Email = request.Email;
            }

            if (!string.IsNullOrEmpty(request.UserName))
            {
                existingUser.Username = request.UserName;
            }

            if (!string.IsNullOrEmpty(request.FirstName))
            {
                existingUser.FirstName = request.FirstName;
            }

            if (!string.IsNullOrEmpty(request.LastName))
            {
                existingUser.LastName = request.LastName;
            }

            if (!string.IsNullOrEmpty(request.Password))
            {
                existingUser.Password = request.Password;
            }

            if (request.BirthDate != default)
            {
                existingUser.BirthDate = request.BirthDate;
            }

            Context.SaveChanges();
        }
    }
}
