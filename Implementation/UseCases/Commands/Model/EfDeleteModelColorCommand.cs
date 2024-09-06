using Application.UseCases.Commands.Model;
using Application.UseCases.DTO;
using DataAccess;
using System.Linq;

namespace Implementation.UseCases.Commands.ModelColor
{
    public class EfDeleteModelColorCommand : EfUseCase, IDeleteModelColorCommand
    {
        public EfDeleteModelColorCommand(AspProjContext context) : base(context)
        {
        }

        public int Id => 31;

        public string Name => "Delete ModelColor";

        public string Description => "Delete ModelColor Command";

        public void Execute(ModelColorDTO request)
        {
            var modelColor = Context.ModelColors.Where(x => x.Id == request.Id).FirstOrDefault();

            if (modelColor != null)
            {
                Context.ModelColors.Remove(modelColor);
                Context.SaveChanges();
            }
        }
    }
}
