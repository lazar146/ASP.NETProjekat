using Application.UseCases.Commands.Price;
using Application.UseCases.DTO;
using DataAccess;
using System.Linq;

namespace Implementation.UseCases.Commands.Price
{
    public class EfDeletePriceCommand : EfUseCase, IDeletePriceCommand
    {
        public EfDeletePriceCommand(AspProjContext context) : base(context)
        {
        }

        public int Id => 32;

        public string Name => "Delete Price";

        public string Description => "Delete Price Command";

        public void Execute(PriceDTO request)
        {
            var price = Context.Prices.Where(x => x.Id == request.Id).FirstOrDefault();

            if (price != null)
            {
                Context.Prices.Remove(price);
                Context.SaveChanges();
            }
        }
    }
}
