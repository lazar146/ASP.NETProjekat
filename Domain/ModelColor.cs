using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ModelColor : Entity
    {
        public int ModelId { get; set; }
        public int ColorId { get; set; }

        public Color Colors { get; set; }
        public Model Models { get; set; }

        public ICollection<Price> PriceModelColor { get; set; }
        public ICollection<ProductCart> ProductCartModelColor { get; set; }

    }
}
