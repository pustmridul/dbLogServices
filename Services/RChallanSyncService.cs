using dbLogServices.ApiModels;
using dbLogServices.Common;
using dbLogServices.Helpers;
using dbLogServices.Interfaces;
using dbLogServices.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbLogServices.Services
{
    public class RChallanSyncService : IRChallanSync
    {
        private readonly IRChallan _rChallan;
        int ProcessCount = 0;
        public RChallanSyncService(IRChallan rChallan)
        {
            _rChallan=rChallan;
        }
        static Helper helper = new Helper();
        public void RchallanSync()
        {
            string ClientName = "TEST";

            try
            {
                if (StaticData.ClientMT == ClientName)
                {
                    List<RCHALLAN> olist = _rChallan.RCHALLAN_GetNewRecord();

                    if (olist == null || olist.Count == 0)
                    {
                        Log.Information("");
                     //   consoleLogs.Add(new ConsoleLog { Pos = 1, Text = "Shop List No record to send", IsAdded = false, _Time = DateTime.Now });
                      //  logManager.AddLog(new VATPRO_API_LOG { LogDate = DateTime.Now, SendData = "Shop List No data to send", ReceiveData = "", Status = true });
                        return;
                    }
                    List<RChallan> ApiModels = _rChallan.RCHALLAN_ConvertObjectToVatProNative(olist);

                    string serializeRecord = Newtonsoft.Json.JsonConvert.SerializeObject(ApiModels);
                    Result r = helper.PostData("api/api/", serializeRecord);

                    if (r.Status)
                    {                
                        Log.Information("");
                        Result serverResult = Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(r.Data.ToString());
                        if (serverResult.Status)
                        {

                            Result ack = _rChallan.RCHALLAN_SaveWriteAcknowledege(olist);
                            if (!ack.Status)
                            {
                               // consoleLogs.Add(new ConsoleLog { Pos = 1, Text = "Shop List Acknowledge Save Fail" + ack.Message, IsAdded = false, _Time = DateTime.Now });
                             //   logManager.AddLog(new VATPRO_API_LOG { LogDate = DateTime.Now, SendData = ack.Message, ReceiveData = "", Status = r.Status });
                            }
                            else
                            {
                               // consoleLogs.Add(new ConsoleLog { Pos = 1, Text = "Shop List Acknowledgement Complete" + ack.Message, IsAdded = false, _Time = DateTime.Now });
                            }
                        }
                        else
                        {
                           // consoleLogs.Add(new ConsoleLog { Pos = 1, Text = "Shop List Sync Fail :" + serverResult.Message, IsAdded = false, _Time = DateTime.Now });
                        }
                    }
                    else
                    {

                     //   consoleLogs.Add(new ConsoleLog { Pos = 1, Text = "Shop List Sync Fail " + r.Message, IsAdded = false, _Time = DateTime.Now });
                    }
                  //  logManager.AddLog(new VATPRO_API_LOG { LogDate = DateTime.Now, SendData = serializeRecord, ReceiveData = r.Data.ToString() + r.Message, Status = r.Status });


                }

            }
            catch (Exception ex)
            {
               // consoleLogs.Add(new ConsoleLog { Pos = 1, Text = "Shop List Sync Fail" + ex.Message, IsAdded = false, _Time = DateTime.Now });
              //  logManager.AddLog(new VATPRO_API_LOG { LogDate = DateTime.Now, SendData = "", ReceiveData = ex.Message + ex.StackTrace, Status = false });
            }
            finally
            {
                ProcessCount = ProcessCount - 1;
               // consoleLogs.Add(new ConsoleLog { Pos = 1, Text = "Shop List End", IsAdded = false, _Time = DateTime.Now });
            }
        }
    }
}
