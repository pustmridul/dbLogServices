using dbLogServices.ApiModels;
using dbLogServices.Common;
using dbLogServices.Interfaces;
using dbLogServices.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace dbLogServices.Services
{
    public class RChallanService : IRChallan
    {
        private readonly AppDbContext _context;
        public RChallanService(AppDbContext context)
        {
            _context = context;
        }
        public List<RCHALLAN> RCHALLAN_GetNewRecord()
        {
            List<RCHALLAN> oList = new List<RCHALLAN>();

            int top = 2;
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                top = 2;
            }
            oList = _context.RCHALLANs.Where(r => r.Chln != null && r.Chln.Length > 0 && r.Chln.Substring(0, 1) != "r").Take(top).ToList();
            return oList;
        }
        public List<RCHALLAN> RCHALLAN_GetChallanDetails(string challanNo)
        {
            List<RCHALLAN> olist = new List<RCHALLAN>();

            olist = _context.RCHALLANs.Where(q => q.Chln == challanNo).Select(s => new RCHALLAN
            {
                sBarCode = s.sBarCode,
                Chln = s.Chln,
                BuyDT = s.BuyDT,
                BarCode = s.BarCode,
                CPU = s.CPU,
                Qty = s.Qty,
                SupID = s.SupID,
                ShopID = s.ShopID

            }).ToList();

            return olist;
        }


        public List<RChallan> RCHALLAN_ConvertObjectToVatProNative(List<RCHALLAN> models)
        {
            List<RChallan> targetModel = new List<RChallan>();

            foreach (var d in models)
            {
                RChallan target = new RChallan();
                target.AIT = 0;
                target.AITPer = 0;
                target.AT = 0;
                target.ATPer = 0;
                target.AV = 0; // 
                target.Bill_Of_Entry = "";
                target.BranchID = d.ShopID;
                target.CD = 0;
                target.CDPer = 0;
                target.ChallanID = ""; //
                                       //  target.ChallanNo = d.VatChallanNo;
                target.ClientType = "Local";
                target.EXD = 0;
                target.EXDPer = 0;
                target.ExternalID = d.Chln ?? "";
                target.IsPaymentComplete = false;
                target.ItemType = "Finished Item";
                target.LOTNO = 0; // server done
                target.PackingMID = "";
                target.PDate = d.BuyDT;
                target.PRD_ID = d.BarCode ?? ""; // 
                target.PriceValue = 0; //

                target.CPU = decimal.Round((d.CPU ?? 0) * 100 / 115, 2);
                target.Qty = d.Qty ?? 0;
              
                target.RawMatID = "";
                target.RD = 0;
                target.RDPer = 0;
                target.RQty = 0;
                target.SD = 0;
                target.SDPer = 0;
                target.SourceDeduct = false;
                target.Vat = 0; //
                target.VatPer = 0; //
                target.VatType = 0; //
                target.VEN_NO = d.SupID ?? ""; //

                target.Insurance = 0; //
                target.LandingCharge = 0; //

                targetModel.Add(target);
            }

            return targetModel;
        }

        public Result RCHALLAN_SaveWriteAcknowledege(List<RCHALLAN> models)
        {    
            foreach (var d in models)
            {
               // d.VatSync = "Y";

            }
           
            Result r = new Result();
           var s = _context.Database.ExecuteSqlRaw("UPDATE"); // _dal.Update<RCHALLAN>(models, "VatSync", "CHLN", tablename, ref msg);
          //  r.Status = "";
            return r;
        }
    }
}
