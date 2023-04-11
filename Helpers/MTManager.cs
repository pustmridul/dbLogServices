using dbLogServices.ApiModels;
using dbLogServices.Common;
using dbLogServices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbLogServices.Helpers
{
    public class MTManager
    {
        private readonly AppDbContext _context;
        public MTManager(AppDbContext context)
        {
            _context = context;
        }
        #region shop list
        public List<ShopList> Shop_GetNewRecord()
        {
            List<ShopList> olist = new List<ShopList>();

            string query = @"SELECT '1' ShopID,'Restora' ShopName,'address' VillAreaRoad,'1229' Post,'Khilkhet' Pstation,'Dhaka' District,'01740966056' Contact,'01740966056' Phone,'N' VATDisabled,50000 MonthlySalesTarget ";
           
            olist =_context.ShopLists.FromSqlRaw(query).ToList();

            return olist;
        }

        public List<BranchSetup> Shop_ConvertObjectToVatProNative(List<ShopList> models)
        {
            List<BranchSetup> targetModel = new List<BranchSetup>();

            foreach (var d in models)
            {
                BranchSetup target = new BranchSetup();
                target.BranchAddress = d.VillAreaRoad;
                target.ExternalID = d.ShopID;
                target.BranchName = d.ShopName;
                target.BranchPhone = d.Phone;
                target.BranchVATREG = "";
                target.COM_NO = ""; //set to api end
                target.IsFactory = false;
                target.IsHeadOffce = d.Post == "HEADOFFICE" ? true : false;
                target.IsWareHouse = d.Post == "WAREHOUSE" ? true : false;

                targetModel.Add(target);
            }

            return targetModel;
        }

        public Result Shop_SaveWriteAcknowledege(List<ShopList> models)
        {   
            foreach (var d in models)
            {
               // d.VatSync = "Y";
            }
            Result r = new Result();
          //  r.Status = _dal.Update<ShopListRestora>(models, "VatSync", "ShopID", "ShopList", ref msg);

            return r;
        }

        public List<ShopList> Shop_GetWahreHouse()
        {
            List<ShopList> olist = new List<ShopList>();
            olist = _context.ShopLists.Where(q => q.Post == "WAREHOUSE").ToList();
            return olist;
        }

        public List<ShopList> Shop_GetShop()
        {
            List<ShopList> olist = new List<ShopList>();
            olist = _context.ShopLists.Where(q => q.Post == "SHOWROOM").ToList();
            return olist;
        }


        #endregion
       

       

        //public Result RCHALLAN_SaveWriteAcknowledege(List<RCHALLAN> models, string shopID)
        //{
        //    string msg = "";
        //    foreach (var d in models)
        //    {
        //        d.VatSync = "Y";

        //    }
        //    string tablename = "RCHALLAN_" + shopID;
        //    Result r = new Result();
        //    r.Status = _dal.Update<RCHALLAN>(models, "VatSync", "CHLN", tablename, ref msg);
        //    r.Message = msg;

        //    return r;
        //}

        #region customer list
        public List<CUSTOMERMST> Customer_GetNewRecord()
        {
            List<CUSTOMERMST> olist = new List<CUSTOMERMST>();
            string msg = "";

            string query = @"SELECT TOP (1000) PRVCUSID
                          ,CATGRY
                          ,TITLE
                          ,FNAME
                          ,MNAME
                          ,LNAME
                          ,CUSNAME
                          ,ADDRESS
                          ,PHONE
                          ,EMAIL
                          ,PROFESSION
                          ,DOE
                          ,CREDITLIMIT
                          ,CREDITBALANCE
                          ,slno
                          ,VatSync
                          ,VRN VatRegNo
                          ,cBIN TIN
                          ,NID
                      FROM CUSTOMER_ALL WHERE ISNULL(VatSync,'N')='N' ";

            olist =_context.CUSTOMERMSTs.FromSqlRaw(query).ToList();
            if (!string.IsNullOrEmpty(msg))
            {
                throw new Exception(msg);
            }
            return olist;
        }

        public List<CustomerList> Customer_ConvertObjectToVatProNative(List<CUSTOMERMST> models)
        {
            List<CustomerList> targetModel = new List<CustomerList>();

            foreach (var d in models)
            {
                CustomerList target = new CustomerList();
                target.ADDRES = d.Address;
                target.CUST_NAME = d.CusName;
                target.EMAIL = d.Email;
                target.NID ="";
                target.TELPHONE = d.Mobile;
                target.TIN = "";
                target.VAT_REG_NO = "";
                target.ExternalID = d.PrvCusID;

                targetModel.Add(target);
            }

            return targetModel;
        }

        public Result Customer_SaveWriteAcknowledege(List<CUSTOMERMST> models)
        {
            string msg = "";
            foreach (var d in models)
            {
               // d.VatSync = "Y";

            }
            Result r = new Result();
          //  r.Status = _dal.Update<CUSTOMERMST>(models, "VatSync", "PRVCUSID", "CUSTOMER_ALL", ref msg);
            r.Message = msg;

            return r;
        }

        #endregion

        #region shop transfer list
        public List<ICHALLAN> ShopTransferMT_GetNewRecord(string shopId)
        {
            List<ICHALLAN> olist = new List<ICHALLAN>();
            string msg = "";

            string top = " TOP 2 ";
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                top = " TOP 20 ";
            }

            string query = @"SELECT  DISTINCT " + top + @" DCNO FROM ICHALLAN_" + shopId + @"
                             WHERE ISNULL(VatSync,'N')='N' ";
           
            olist = _context.ICHALLANs.FromSqlRaw(query).ToList();
            if (!string.IsNullOrEmpty(msg))
            {
                throw new Exception(msg);
            }

            return olist;
        }

        public List<ICHALLAN> ShopTransferMT_GetChallanDetails(string challanNo, string shopId)
        {
            List<ICHALLAN> olist = new List<ICHALLAN>();
            string msg = "";

            string query = @"SELECT DCNO,DCDt,StoreID,ShopID,PrvCusID,Invoice,i.BarCode 
	                            ,i.CPU,i.RPU,DiscPrcnt,sqty,SupID,i.UserID,Remarks,i.VatSync,pl.UNITTYPE,i.SIZE3,i.SIZE4,PlaceOfDelivery,VehicleNo
                            FROM dbo.ICHALLAN_" + shopId + @" i
                            INNER JOIN dbo.PRODUCTLIST pl ON pl.BARCODE = i.BarCode
                            WHERE DCNO='" + challanNo + "' ";

            olist =_context.ICHALLANs.FromSqlRaw(query).ToList();
            if (!string.IsNullOrEmpty(msg))
            {
                throw new Exception(msg);
            }

            return olist;
        }

        public List<StockTransfer> ShopTransferMT_ConvertObjectToVatProNative(List<ICHALLAN> models)
        {
            List<StockTransfer> targetModel = new List<StockTransfer>();

            foreach (var d in models)
            {
                StockTransfer target = new StockTransfer();
                target.ExternalID = d.DCNO;
                target.Comments = "";
                target.CREATE_BY = d.UserID;
                target.CREATE_DATE = DateTime.Now;
                target.FromBranch = "";
                target.ToBranch = d.ShopID;
                target.TransferDate = d.DCDt;
                target.VAT = 0; // set in server
                target.VAT_Per = 0; // set in server
                target.SD = 0;// set in server
                target.SD_per = 0;// set in server
                target.PRD_ID = d.BarCode;
                target.PackingMID = "";
                target.RawMatID = "";
                target.ItemType = "Finished Item";
                target.SalesQty = 0;
                target.ExternalInvoice ="";

                target.DiscPrcnt = d.DiscPrcnt ?? 0;
                target.PrvCusID = "";
                target.PlaceOfDelivery = "";
                target.VehicleNo = "";
                target.Qty = d.sQty ??0;
                target.CPU= d.CPU ??0;
                target.RPU = d.RPU ?? 0;

                targetModel.Add(target);
            }

            return targetModel;
        }


        public static decimal TruncateDecimal(decimal value, int precision)
        {
            decimal step = (decimal)Math.Pow(10, precision);
            decimal tmp = Math.Truncate(step * value);
            return tmp / step;
        }

        public Result ShopTransferMT_SaveWriteAcknowledege(List<ICHALLAN> models, string shopId)
        {
            string msg = "";
            foreach (var d in models)
            {
               // d.VatSync = "Y";

            }
            string tablename = "ICHALLAN_" + shopId;
            Result r = new Result();
        //    r.Status = _dal.Update<ICHALLAN>(models, "VatSync", "DCNO", tablename, ref msg);
            r.Message = msg;

            return r;
        }

        #endregion
    }
}
