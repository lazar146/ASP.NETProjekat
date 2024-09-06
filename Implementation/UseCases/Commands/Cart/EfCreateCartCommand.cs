using Application.UseCases.Commands.Cart;
using Application.UseCases.DTO;
using Application.UseCases.Queries;
using DataAccess;
using FluentValidation;
using Implementation.Validation.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Cart
{
    public class EfCreateCartCommand : EfUseCase, ICreateCartCommand
    {
        private CartCreateValidator _validator;

        public EfCreateCartCommand(AspProjContext context, CartCreateValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 12;

        public string Name => "Create Cart";

        public string Description => "Create Cart Command";

        public void Execute(CartDTO request)
        {
            _validator.ValidateAndThrow(request);
            var cart = new Domain.Cart
            {
                UserId = request.UserId,
            };
            Context.Carts.Add(cart);
            Context.SaveChanges();
        }
    }
}
