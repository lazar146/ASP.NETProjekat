using Application.UseCases.Commands.Price;
using Application.UseCases.DTO;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validation.Price;
using System;

namespace Implementation.UseCases.Commands.Price
{
    public class EfCreatePriceCommand : EfUseCase, ICreatePriceCommand
    {
        private PriceCreateValidator _validator;

        public EfCreatePriceCommand(AspProjContext context, PriceCreateValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 16;
        public string Name => "Create Price";
        public string Description => "Create Price command";

        public void Execute(PriceDTO request)
        {
            _validator.ValidateAndThrow(request);
            var price = new Domain.Price
            {
                PriceValue = request.PriceValue,
                ModelColorId = request.ModelColorId
            };

            Context.Prices.Add(price);
            Context.SaveChanges();
        }
    }
}
