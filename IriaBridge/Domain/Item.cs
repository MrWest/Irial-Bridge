using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.Domain
{
    public class Item: Nameable
    {
        public decimal Price { get; set; }
        public String Version { get; set; }

        public int id_category { get; set; }

        public String category_name { get; set; }

        public ICollection<Image> Images { get; set; } 

        
    }
}
