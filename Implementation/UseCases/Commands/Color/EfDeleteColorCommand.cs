using Application.UseCases.Commands.Color;
using Application.UseCases.DTO;
using DataAccess;
using System.Linq;

namespace Implementation.UseCases.Commands.Color
{
    public class EfDeleteColorCommand : EfUseCase, IDeleteColorCommand
    {
        public EfDeleteColorCommand(AspProjContext context) : base(context)
        {
        }

        public int Id => 28;

        public string Name => "Delete Color";

        public string Description => "Delete Color Command";

        public void Execute(ColorDTO request)
        {
            var color = Context.Colors.Where(x => x.Id == request.Id).FirstOrDefault();

            if (color != null)
            {
                Context.Colors.Remove(color);
                Context.SaveChanges();
            }
        }
    }
}
