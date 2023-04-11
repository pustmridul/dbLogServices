using dbLogServices.ApiModels;
using dbLogServices.Common;
using dbLogServices.Helpers;


namespace dbLogServices
{
    public class ShopSync
    {
        List<ConsoleLog> consoleLogs = new List<ConsoleLog>();
        static Helper helper = new Helper();
        int ProcessCount = 0;
        //public void SyncShopList()
        //{
        //    string ClientName = "Restora";

        //    try
        //    {
        //        if (StaticData.ClientMT == ClientName)
        //        {
        //            List<VatProSync.ModelsRestora.ShopListRestora> olist = new MTManager().Shop_GetNewRecord();

        //            if (olist == null || olist.Count == 0)
        //            {
        //                consoleLogs.Add(new ConsoleLog { Pos = 1, Text = "Shop List No record to send", IsAdded = false, _Time = DateTime.Now });
        //               // logManager.AddLog(new VATPRO_API_LOG { LogDate = DateTime.Now, SendData = "Shop List No data to send", ReceiveData = "", Status = true });
        //                return;
        //            }
        //            List<VatProSync.ModelsAPI.BranchSetup> ApiModels = new MTManager().Shop_ConvertObjectToVatProNative(olist);

        //            string serializeRecord = Newtonsoft.Json.JsonConvert.SerializeObject(ApiModels);
        //            Result r = helper.PostData("api/api/setup/BranchSetup_Import_Json", serializeRecord);

        //            if (r.Status)
        //            {
        //                consoleLogs.Add(new ConsoleLog { Pos = 1, Text = "Shop List Sync Data Send", IsAdded = false, _Time = DateTime.Now });

        //                Result serverResult = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(r.Data.ToString());
        //                if (serverResult.Status)
        //                {
        //                    consoleLogs.Add(new ConsoleLog { Pos = 1, Text = "Shop List Sync Send Successfully", IsAdded = false, _Time = DateTime.Now });
        //                    consoleLogs.Add(new ConsoleLog { Pos = 1, Text = "Shop List Writing Acknowledgement", IsAdded = false, _Time = DateTime.Now });
        //                   // Result ack = new MTManager().Shop_SaveWriteAcknowledege(olist);
        //                    if (!ack.Status)
        //                    {
        //                        consoleLogs.Add(new ConsoleLog { Pos = 1, Text = "Shop List Acknowledge Save Fail" + ack.Message, IsAdded = false, _Time = DateTime.Now });
        //                      //  logManager.AddLog(new VATPRO_API_LOG { LogDate = DateTime.Now, SendData = ack.Message, ReceiveData = "", Status = r.Status });
        //                    }
        //                    else
        //                    {
        //                        consoleLogs.Add(new ConsoleLog { Pos = 1, Text = "Shop List Acknowledgement Complete" + ack.Message, IsAdded = false, _Time = DateTime.Now });
        //                    }
        //                }
        //                else
        //                {
        //                    consoleLogs.Add(new ConsoleLog { Pos = 1, Text = "Shop List Sync Fail :" + serverResult.Message, IsAdded = false, _Time = DateTime.Now });
        //                }
        //            }
        //            else
        //            {

        //                consoleLogs.Add(new ConsoleLog { Pos = 1, Text = "Shop List Sync Fail " + r.Message, IsAdded = false, _Time = DateTime.Now });
        //            }
        //          //  logManager.AddLog(new VATPRO_API_LOG { LogDate = DateTime.Now, SendData = serializeRecord, ReceiveData = r.Data.ToString() + r.Message, Status = r.Status });


        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        consoleLogs.Add(new ConsoleLog { Pos = 1, Text = "Shop List Sync Fail" + ex.Message, IsAdded = false, _Time = DateTime.Now });
        //       // logManager.AddLog(new VATPRO_API_LOG { LogDate = DateTime.Now, SendData = "", ReceiveData = ex.Message + ex.StackTrace, Status = false });
        //    }
        //    finally
        //    {
        //        ProcessCount = ProcessCount - 1;
        //        consoleLogs.Add(new ConsoleLog { Pos = 1, Text = "Shop List End", IsAdded = false, _Time = DateTime.Now });
        //    }
        //}


        public string GetBatchNo()
        {
            string ClientName = "Restora";
            string AppTitle = "EpyToast";
            Result r = new Result();
            try
            {
                if (StaticData.ClientMT == ClientName)
                {

                    r = helper.GetData("api/api/BatchCreation/GetBatchNo");

                    if (r.Status)
                    {
                        return r.Data.ToString();
                    }

                    r.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }


            return r.ToString();
        }

        //public static string PostSaleData(List<VatProSale> Sales)
        //{
        //    string ClientName = "Restora";

        //    string serializeRecord = Newtonsoft.Json.JsonConvert.SerializeObject(Sales);

        //    Result r = new Result();
        //    try
        //    {
        //        if (StaticData.ClientMT == ClientName)
        //        {
        //            r = helper.PostData("api/Sales/Import_Json", serializeRecord);

        //            if (r.Status)
        //            {
        //                return "Successful";
        //            }

        //            r.Message.ToString();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message.ToString();
        //    }

        //    finally
        //    {
        //        VATPRO_API_LOG aLog = new VATPRO_API_LOG()
        //        {
        //            LogDate = DateTime.Now,
        //            Status = r.Status,
        //            SendData = serializeRecord,
        //            ReceiveData = r.Data.ToString()
        //        };
        //       // SaveToLog(aLog);
        //    }
        //    return r.Message.ToString();
        //}

        public string PostSaleReturnData(List<CreditNote> CreditNotes)
        {
            string ClientName = "Restora";

            string serializeRecord = Newtonsoft.Json.JsonConvert.SerializeObject(CreditNotes);

            Result r = new Result();
            try
            {
                if (StaticData.ClientMT == ClientName)
                {
                    r = helper.PostData("api/CreditNote/Import_Json_SalesReturn_CreditNote_MT", serializeRecord);

                    if (r.Status)
                    {
                        return "Successful";
                    }

                    r.Message.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }


            return r.Message.ToString();
        }

        public string PostProductData(List<ProductSetup> Products)
        {
            string ClientName = "Restora";

            string serializeRecord = Newtonsoft.Json.JsonConvert.SerializeObject(Products);




            Result r = new Result();
            try
            {
                if (StaticData.ClientMT == ClientName)
                {
                    r = helper.PostData("api/Setup/ProductSetup_Import_Json", serializeRecord);

                    if (r.Status)
                    {
                        return r.Data.ToString();
                    }

                    r.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }


            return r.ToString();
        }


        public string FetchProductData()
        {
            string ClientName = "Restora";

            Result r = new Result();
            try
            {
                if (StaticData.ClientMT == ClientName)
                {
                    r = helper.GetData("api/Setup/ProductSetup_SelectAll");

                    if (r.Status)
                    {
                        return r.Data.ToString();
                    }

                    r.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }


            return r.ToString();
        }

        //private static bool SaveToLog(VATPRO_API_LOG data)
        //{
        //    bool result = false;

        //    LogManager log = new LogManager();

        //    log.AddLog(data);

        //    return result;

        //}
        public string FetchProductData2()
        {
            string ClientName = "Restora";

            Result r = new Result();
            try
            {
                if (StaticData.ClientMT == ClientName)
                {
                    r = helper.GetData("api/Setup/ProductSetup_SelectAll");

                    if (r.Status)
                    {
                        return r.Data.ToString();
                    }

                    r.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

            return r.ToString();
        }
    }
}
