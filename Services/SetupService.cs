using dbLogServices.ApiModels;
using dbLogServices.Common;
using dbLogServices.Interfaces;
using dbLogServices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbLogServices.Services
{
    public class SetupService : ISetup
    {
        private readonly AppDbContext _context;
        public SetupService(AppDbContext context)
        {
            _context = context;
        }
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

    }
}
