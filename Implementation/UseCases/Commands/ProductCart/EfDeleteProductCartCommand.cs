using Application.UseCases.Commands.Cart;
using Application.UseCases.DTO;
using DataAccess;
using System.Linq;

namespace Implementation.UseCases.Commands.ProductCart
{
    public class EfDeleteProductCartCommand : EfUseCase, IDeleteProductCartCommand
    {
        public EfDeleteProductCartCommand(AspProjContext context) : base(context)
        {
        }

        public int Id => 27;

        public string Name => "Delete ProductCart";

        public string Description => "Delete ProductCart Command";

        public void Execute(ProductCartDTO request)
        {
            var productCart = Context.ProductCarts.Where(x => x.Id == request.Id).FirstOrDefault();

            if (productCart != null)
            {
                Context.ProductCarts.Remove(productCart);
                Context.SaveChanges();
            }
        }
    }
}
