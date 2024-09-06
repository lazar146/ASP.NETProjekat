using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DTO
{
    public class ModelDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int brandId { get; set; }
        public int RamMemory { get; set; }
        public int StorageMemory { get; set; }
        public int CameraMegapixels { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
