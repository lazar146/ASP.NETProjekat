using Application.UseCases.Commands.Price;
using Application.UseCases.DTO;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validation.Price;

namespace Implementation.UseCases.Commands.Price
{
    public class EfUpdatePriceCommand : EfUseCase, IUpdatePriceCommand
    {
        private PriceCreateValidator _validator;

        public EfUpdatePriceCommand(AspProjContext context, PriceCreateValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 24;

        public string Name => "Update Price";

        public string Description => "Update Price Command";

        public void Execute(PriceDTO request)
        {
            _validator.ValidateAndThrow(request);

            var existingPrice = Context.Prices.FirstOrDefault(x => x.Id == request.Id);

            if (existingPrice == null)
            {
                throw new Exception("Price not found.");
            }

            if (request.PriceValue > 0)
            {
                existingPrice.PriceValue = request.PriceValue;
            }

            if (request.ModelColorId > 0)
            {
                existingPrice.ModelColorId = request.ModelColorId;
            }

            Context.SaveChanges();
        }
    }
}
