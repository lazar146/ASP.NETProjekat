using Application.UseCases.Commands.Cart;

using Application.UseCases.DTO;
using DataAccess;
using System.Linq;

namespace Implementation.UseCases.Commands.Cart
{
    public class EfDeleteCartCommand : EfUseCase, IDeleteCartCommand
    {
        public EfDeleteCartCommand(AspProjContext context) : base(context)
        {
        }

        public int Id => 26;

        public string Name => "Delete Cart";

        public string Description => "Delete Cart Command";

        public void Execute(CartDTO request)
        {
            var cart = Context.Carts.Where(x => x.Id == request.Id).FirstOrDefault();

            if (cart != null)
            {
                Context.Carts.Remove(cart);
                Context.SaveChanges();
            }
        }
    }
}
