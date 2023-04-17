using dbLogServices.ApiModels;
using dbLogServices.Common;
using dbLogServices.Interfaces;
using dbLogServices.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;


namespace dbLogServices.Services
{
    public class SetupService : ISetup
    {
        private readonly AppDbContext _context;
        public SetupService(AppDbContext context)
        {
            _context = context;
        }
        #region Shop
        public List<ShopList> Shop_GetRecord()
        {
            List<ShopList> olist = new List<ShopList>();          
            
            olist = _context.ShopLists.ToList();
           
            return olist;
          
        }

        public List<BranchSetup> Shop_MapToVatProNative(List<ShopList> models)
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
          
            var shopIds= models.Select(s=>s.ShopID).ToArray();
           
            string myArrayString = string.Join(",", shopIds.Select(s => $"'{s}'") );

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE ShopList SET VatSync ='Y'");
            sb.AppendLine("WHERE ShopID IN (" + myArrayString + ")");


            Result r = new Result();
            if (_context.Database.ExecuteSqlRaw(sb.ToString()) > 0)
            {
                r.Status = true;
            }

            return r;
        }

        #endregion

        #region Product
        public List<ShopList> Product_GetRecord()
        {
            List<ShopList> olist = new List<ShopList>();

            olist = _context.ShopLists.ToList();

            return olist;

        }

        public List<BranchSetup> Product_MapToVatProNative(List<ShopList> models)
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

        public Result Product_SaveWriteAcknowledege(List<ShopList> models)
        {

            var shopIds = models.Select(s => s.ShopID).ToArray();

            string myArrayString = string.Join(",", shopIds.Select(s => $"'{s}'"));

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE ShopList SET VatSync ='Y'");
            sb.AppendLine("WHERE ShopID IN (" + myArrayString + ")");


            Result r = new Result();
            if (_context.Database.ExecuteSqlRaw(sb.ToString()) > 0)
            {
                r.Status = true;
            }

            return r;
        }
        #endregion

        #region Customer
        public List<CUSTOMERMST> Customer_GetRecord()
        {
            List<CUSTOMERMST> olist = new List<CUSTOMERMST>();

            olist = _context.CUSTOMERMSTs.ToList();

            return olist;

        }

        public List<CustomerList> Customer_MapToVatProNative(List<CUSTOMERMST> models)
        {
            List<CustomerList> targetModel = new List<CustomerList>();

            foreach (var d in models)
            {
                CustomerList target = new CustomerList();
                target.CUST_NO = "";
                target.CUST_NAME = d.CusName;
                target.VAT_REG_NO = "";
                target.TIN = "";
                target.NID = "";
                target.ADDRES = d.Address;
                target.TELPHONE = d.Tel_Office ?? d.Tel_Home;
                target.EMAIL = d.Email;
                target.CUST_GROUP = "";
                target.ExternalID = "";
              
                targetModel.Add(target);
            }

            return targetModel;
        }

        public Result Customer_SaveWriteAcknowledege(List<CUSTOMERMST> models)
        {

            var cusIds = models.Select(s => s.PrvCusID).ToArray();

            string myArrayString = string.Join(",", cusIds.Select(s => $"'{s}'"));

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE CustomerMst SET VatSync ='Y'");
            sb.AppendLine("WHERE PrvCusID IN (" + myArrayString + ")");


            Result r = new Result();
            if (_context.Database.ExecuteSqlRaw(sb.ToString()) > 0)
            {
                r.Status = true;
            }

            return r;
        }
        #endregion
        #region Vendor
        public List<ShopList> Vendor_GetRecord()
        {
            List<ShopList> olist = new List<ShopList>();

            olist = _context.ShopLists.ToList();

            return olist;

        }

        public List<BranchSetup> Vendor_MapToVatProNative(List<ShopList> models)
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

        public Result Vendor_SaveWriteAcknowledege(List<ShopList> models)
        {

            var shopIds = models.Select(s => s.ShopID).ToArray();

            string myArrayString = string.Join(",", shopIds.Select(s => $"'{s}'"));

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("UPDATE ShopList SET VatSync ='Y'");
            sb.AppendLine("WHERE ShopID IN (" + myArrayString + ")");

            Result r = new Result();
            if (_context.Database.ExecuteSqlRaw(sb.ToString()) > 0)
            {
                r.Status = true;
            }

            return r;
        }
        #endregion
    }
}
