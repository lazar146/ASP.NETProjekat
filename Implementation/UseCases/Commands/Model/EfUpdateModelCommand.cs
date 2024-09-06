using Application.UseCases.Commands.Model;
using Application.UseCases.DTO;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validation.Model;

namespace Implementation.UseCases.Commands.Model
{
    public class EfUpdateModelCommand : EfUseCase, IUpdateModelCommand
    {
        private ModelCreateValidator _validator;

        public EfUpdateModelCommand(AspProjContext context, ModelCreateValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 22;

        public string Name => "Update Model";

        public string Description => "Update Model Command";

        public void Execute(ModelDTO request)
        {
            _validator.ValidateAndThrow(request);

            var existingModel = Context.Models.FirstOrDefault(x => x.Id == request.Id);

            if (existingModel == null)
            {
                throw new Exception("Model not found.");
            }

            if (!string.IsNullOrEmpty(request.Name))
            {
                existingModel.Name = request.Name;
            }

            if (!string.IsNullOrEmpty(request.Description))
            {
                existingModel.Description = request.Description;
            }

            if (request.brandId > 0)
            {
                existingModel.brandId = request.brandId;
            }

            if (request.RamMemory > 0)
            {
                existingModel.RamMemory = request.RamMemory;
            }

            if (request.StorageMemory > 0)
            {
                existingModel.StorageMemory = request.StorageMemory;
            }

            if (request.CameraMegapixels > 0)
            {
                existingModel.CameraMegapixels = request.CameraMegapixels;
            }

            Context.SaveChanges();
        }
    }
}
