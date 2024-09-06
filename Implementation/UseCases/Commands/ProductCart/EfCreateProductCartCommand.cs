using Application.UseCases.Commands.Cart;
using Application.UseCases.DTO;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validation.ProductCart;
using System;

namespace Implementation.UseCases.Commands.ProductCart
{
    public class EfCreateProductCartCommand : EfUseCase, ICreateProductCartCommand
    {
        private ProductCartCreateValidator _validator;

        public EfCreateProductCartCommand(AspProjContext context, ProductCartCreateValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 18;
        public string Name => "Create ProductCart";
        public string Description => "Create ProductCart command";

        public void Execute(ProductCartDTO request)
        {
            _validator.ValidateAndThrow(request);
            var productCart = new Domain.ProductCart
            {
                Quanity = request.Quantity,
                ModelColorId = request.ModelColorId,
                CartId = request.CartId
            };

            Context.ProductCarts.Add(productCart);
            Context.SaveChanges();
        }
    }
}
