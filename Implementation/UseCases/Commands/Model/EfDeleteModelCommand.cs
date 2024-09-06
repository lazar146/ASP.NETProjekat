using Application.UseCases.Commands.Model;
using Application.UseCases.DTO;
using DataAccess;
using System.Linq;

namespace Implementation.UseCases.Commands.Model
{
    public class EfDeleteModelCommand : EfUseCase, IDeleteModelCommand
    {
        public EfDeleteModelCommand(AspProjContext context) : base(context)
        {
        }

        public int Id => 30;

        public string Name => "Delete Model";

        public string Description => "Delete Model Command";

        public void Execute(ModelDTO request)
        {
            var model = Context.Models.Where(x => x.Id == request.Id).FirstOrDefault();

            if (model != null)
            {
                Context.Models.Remove(model);
                Context.SaveChanges();
            }
        }
    }
}
