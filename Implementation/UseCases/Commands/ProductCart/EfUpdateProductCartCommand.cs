using Application.UseCases.Commands.Cart;

using Application.UseCases.DTO;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validation.ProductCart;

namespace Implementation.UseCases.Commands.ProductCart
{
    public class EfUpdateProductCartCommand : EfUseCase, IUpdateProductCartCommand
    {
        private ProductCartCreateValidator _validator;

        public EfUpdateProductCartCommand(AspProjContext context, ProductCartCreateValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 19;

        public string Name => "Update Product Cart";

        public string Description => "Update Product Cart Command";

        public void Execute(ProductCartDTO request)
        {
            _validator.ValidateAndThrow(request);

            var existingProductCart = Context.ProductCarts.FirstOrDefault(x => x.Id == request.Id);

            if (existingProductCart == null)
            {
                throw new Exception("ProductCart not found.");
            }

            if (request.Quantity > 0)
            {
                existingProductCart.Quanity = request.Quantity;
            }

            if (request.ModelColorId > 0)
            {
                existingProductCart.ModelColorId = request.ModelColorId;
            }

            if (request.CartId > 0)
            {
                existingProductCart.CartId = request.CartId;
            }

            Context.SaveChanges();
        }
    }
}
