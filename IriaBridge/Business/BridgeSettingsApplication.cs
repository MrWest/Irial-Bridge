using IriaBridge.DataAccess;
using IriaBridge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriaBridge.Business
{
    public  class BridgeSettingsApplication: ApplicationBase<BridgeSettings, BridgeSettingsRepository>
    {
        public BridgeSettings BridgeSettings { get { return Repository.BridgeSettings;  } }
    }
}
