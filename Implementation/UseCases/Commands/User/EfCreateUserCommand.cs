using Application.UseCases.Commands.User;

using Application.UseCases.DTO;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validation.User;
using Org.BouncyCastle.Crypto.Generators;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Implementation.UseCases.Commands.User
{
    public class EfCreateUserCommand : EfUseCase, ICreateUserCommand
    {
        private UserCreateValidator _validator;

        public EfCreateUserCommand(AspProjContext context, UserCreateValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 17;
        public string Name => "Create User";
        public string Description => "Create User command";

        public void Execute(UserDTO request)
        {
            _validator.ValidateAndThrow(request);
            var user = new Domain.User
            {
                Email = request.Email,
                Username = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                BirthDate = request.BirthDate,
                UseCases = Enumerable.Range(12, 24).Select(id => new UserUseCase { UseCaseId = id }).ToList()
            };

                Context.Users.Add(user);
            Context.SaveChanges();
        }
    }
}
