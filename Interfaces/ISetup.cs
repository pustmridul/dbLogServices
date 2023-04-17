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
        #region Shop
        List<ShopList> Shop_GetRecord();
        List<BranchSetup> Shop_MapToVatProNative(List<ShopList> models);
        Result Shop_SaveWriteAcknowledege(List<ShopList> models);
        #endregion
        #region Product
        List<ShopList> Product_GetRecord();
        List<BranchSetup> Product_MapToVatProNative(List<ShopList> models);
        Result Product_SaveWriteAcknowledege(List<ShopList> models);
        #endregion
        #region Customer
        List<CUSTOMERMST> Customer_GetRecord();
        List<CustomerList> Customer_MapToVatProNative(List<CUSTOMERMST> models);
        Result Customer_SaveWriteAcknowledege(List<CUSTOMERMST> models);
        #endregion
        #region Vendor
        List<ShopList> Vendor_GetRecord();
        List<BranchSetup> Vendor_MapToVatProNative(List<ShopList> models);
        Result Vendor_SaveWriteAcknowledege(List<ShopList> models);
        #endregion

    }
}
