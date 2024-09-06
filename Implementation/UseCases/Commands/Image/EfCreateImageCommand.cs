using Application.UseCases.Commands.Brands;
using Application.UseCases.Commands.Image;
using Application.UseCases.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Image
{
    public class EfCreateImageCommand : EfUseCase, ICreateImageCommand
    {
        public EfCreateImageCommand(AspProjContext context) : base(context)
        {
        }

        public int Id => 34;

        public string Name => "Create Image";

        public string Description => "Create Image Command";

        public void Execute(ImageDTO request)
        {
            if (request.ImageFile != null && request.ImageFile.Length > 0)
            {
                var extension = Path.GetExtension(request.ImageFile.FileName);
                var filename = Guid.NewGuid().ToString() + extension;
                var savepath = Path.Combine("wwwroot", "images", filename);

                Directory.CreateDirectory(Path.GetDirectoryName(savepath));

                using (var fs = new FileStream(savepath, FileMode.Create))
                {
                    request.ImageFile.CopyTo(fs);
                }
                
                var image = new Domain.Image
                {
                    ImageName = request.ImageName,
                    ImageUrl = filename, 
                    ModelId = request.ModelId,
                   
                };

               
                Context.Images.Add(image);
                Context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("No file uploaded.");
            }
        }
        }
}
