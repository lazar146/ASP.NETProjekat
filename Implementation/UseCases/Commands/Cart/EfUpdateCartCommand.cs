using Application.UseCases.Commands.Cart;
using Application.UseCases.DTO;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validation.Cart;

namespace Implementation.UseCases.Commands.Cart
{
    public class EfUpdateCartCommand : EfUseCase, IUpdateCartCommand
    {
        private CartCreateValidator _validator;

        public EfUpdateCartCommand(AspProjContext context, CartCreateValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 18;

        public string Name => "Update Cart";

        public string Description => "Update Cart Command";

        public void Execute(CartDTO request)
        {
            _validator.ValidateAndThrow(request);

            var existingCart = Context.Carts.FirstOrDefault(x => x.Id == request.Id);

            if (existingCart == null)
            {
                throw new Exception("Cart not found.");
            }

            if (request.UserId > 0)
            {
                existingCart.UserId = request.UserId;
            }

            Context.SaveChanges();
        }
    }
}
