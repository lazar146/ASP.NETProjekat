using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Model : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int brandId { get; set; }

        public int RamMemory { get; set; }
        public int StorageMemory { get; set; }

        public int CameraMegapixels { get; set; }

        public ICollection<Image> imagesModel { get; set; }
        public ICollection<ModelColor> colorsModel { get; set; }
       
        public Brand brandModel { get; set; }

    }
}
