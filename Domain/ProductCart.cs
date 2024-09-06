using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ProductCart : Entity
    {
      public int Quanity {  get; set; }
      public int ModelColorId { get; set; }
      public int CartId { get; set; }

        public ModelColor ModelColorsPC { get; set; }
        public Cart Carts { get; set; }


    }
}
