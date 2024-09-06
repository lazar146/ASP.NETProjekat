using Application.UseCases.Commands.Color;
using Application.UseCases.DTO;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validation.Color;

namespace Implementation.UseCases.Commands.Color
{
    public class EfUpdateColorCommand : EfUseCase, IUpdateColorCommand
    {
        private ColorCreateValidator _validator;

        public EfUpdateColorCommand(AspProjContext context, ColorCreateValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 20;

        public string Name => "Update Color";

        public string Description => "Update Color Command";

        public void Execute(ColorDTO request)
        {
            _validator.ValidateAndThrow(request);

            var existingColor = Context.Colors.FirstOrDefault(x => x.Id == request.Id);

            if (existingColor == null)
            {
                throw new Exception("Color not found.");
            }

            if (!string.IsNullOrEmpty(request.Name))
            {
                existingColor.Name = request.Name;
            }

            Context.SaveChanges();
        }
    }
}
