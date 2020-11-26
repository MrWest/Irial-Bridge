using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IriaBridge.DataAccess;

namespace IriaBridge.Business
{
    public class ImagesApplication: ApplicationBase<Image, ImageRepository>
    {
        public int Owner { get; set; }
        protected override ImageRepository Repository
        {
            get
            {
                var _repo = base.Repository;
                _repo.Owner = Owner;
                return _repo;
            }
        }
    }
}
