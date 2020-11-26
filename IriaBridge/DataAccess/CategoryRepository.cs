using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.DataAccess
{
    public class CategoryRepository: Repository<Category>
    {
        protected override String Path => "categories/get_categories.php";
    }
}
