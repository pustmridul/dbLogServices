using dbLogServices.ApiModels;
using dbLogServices.Common;
using dbLogServices.Helpers;
using dbLogServices.Interfaces;
using dbLogServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbLogServices.Services
{
    public class SetupSyncService : ISetupSync
    {
        private readonly ISetup _setup;
        
        static Helper helper = new Helper();
        int ProcessCount = 0;

        public SetupSyncService(ISetup setup)
        {
            _setup = setup;
        }
        public void SyncShopList()
        {
            try
            {             
                 List<ShopList> olist = _setup.Shop_GetRecord();

                 if (olist == null || olist.Count == 0)
                 {
                     return;
                 }
                 List<BranchSetup> ApiModels = _setup.Shop_MapToVatProNative(olist);

                 string serializeRecord = Newtonsoft.Json.JsonConvert.SerializeObject(ApiModels);
                 Result r = helper.PostData("api/api/setup/BranchSetup_Import_Json", serializeRecord);

                 if (r.Status)
                 {                    
                     Result serverResult = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(r.Data.ToString());
                     if (serverResult.Status)
                     {
                     Result ack = _setup.Shop_SaveWriteAcknowledege(olist);
                         if (!ack.Status)
                         {
                         }
                         else
                         {
                         }
                     }
                     else
                     {
                       
                     }
                 }
                 else
                 {
                 }
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                ProcessCount = ProcessCount - 1;              
            }
        }

        public void SyncProductList()
        {
            throw new NotImplementedException();
        }

        public void SyncVendorList()
        {
            throw new NotImplementedException();
        }

        public void SyncCustomerList()
        {
            try
            {
                List<CUSTOMERMST> olist = _setup.Customer_GetRecord();

                if (olist == null || olist.Count == 0)
                {
                    return;
                }
                List<CustomerList> ApiModels = _setup.Customer_MapToVatProNative(olist);

                string serializeRecord = Newtonsoft.Json.JsonConvert.SerializeObject(ApiModels);
                Result r = helper.PostData("api/api/Setup/Setup_CustomerList_Import_Json", serializeRecord);

                if (r.Status)
                {
                    Result serverResult = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(r.Data.ToString());
                    if (serverResult.Status)
                    {
                        Result ack = _setup.Customer_SaveWriteAcknowledege(olist);
                        if (!ack.Status)
                        {
                        }
                        else
                        {
                        }
                    }
                    else
                    {

                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ProcessCount = ProcessCount - 1;
            }
        }
    }
}
