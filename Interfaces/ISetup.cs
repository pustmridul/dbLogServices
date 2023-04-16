using dbLogServices.ApiModels;
using dbLogServices.Common;
using dbLogServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbLogServices.Interfaces
{
    public interface ISetup
    {
        List<ShopList> Shop_GetRecord();
        List<BranchSetup> Shop_MapToVatProNative(List<ShopList> models);
        Result Shop_SaveWriteAcknowledege(List<ShopList> models);
    }
}
