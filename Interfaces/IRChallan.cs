using dbLogServices.ApiModels;
using dbLogServices.Common;
using dbLogServices.Models;

namespace dbLogServices.Interfaces
{
    public interface IRChallan
    {
        List<RCHALLAN> RCHALLAN_GetNewRecord();
        List<RCHALLAN> RCHALLAN_GetChallanDetails(string challanNo);
        List<RChallan> RCHALLAN_ConvertObjectToVatProNative(List<RCHALLAN> models);
        Result RCHALLAN_SaveWriteAcknowledege(List<RCHALLAN> models);
    }
}
