using Application.UseCases.Commands.Model;
using Application.UseCases.DTO;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validation.Model;

namespace Implementation.UseCases.Commands.ModelColor
{
    public class EfUpdateModelColorCommand : EfUseCase, IUpdateModelColorCommand
    {
        private ModelColorCreateValidator _validator;

        public EfUpdateModelColorCommand(AspProjContext context, ModelColorCreateValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 23;

        public string Name => "Update Model Color";

        public string Description => "Update Model Color Command";

        public void Execute(ModelColorDTO request)
        {
            _validator.ValidateAndThrow(request);

            var existingModelColor = Context.ModelColors.FirstOrDefault(x => x.Id == request.Id);

            if (existingModelColor == null)
            {
                throw new Exception("ModelColor not found.");
            }

            if (request.ModelId > 0)
            {
                existingModelColor.ModelId = request.ModelId;
            }

            if (request.ColorId > 0)
            {
                existingModelColor.ColorId = request.ColorId;
            }

            Context.SaveChanges();
        }
    }
}
