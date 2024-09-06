using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Image : Entity
    {
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public int ModelId { get; set; }

        public Model ModelImg { get; set; }

    }
}
