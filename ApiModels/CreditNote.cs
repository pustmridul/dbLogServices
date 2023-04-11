using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbLogServices.ApiModels
{
    public class CreditNote
    {
        public string CreditNoteNo { get; set; }

        public string Type { get; set; }

        public string ChallanID { get; set; }

        public string VEN_NO { get; set; }

        public string CUST_NO { get; set; }

        public string ItemType { get; set; }

        public string PRD_ID { get; set; }

        public string RawMatID { get; set; }

        public string PackingMID { get; set; }

        public decimal? ActualQty { get; set; }

        public decimal? Qty { get; set; }

        public decimal? ActualPrice { get; set; }

        public decimal? CostPrice { get; set; }

        public decimal? Price { get; set; }

        public decimal? CD { get; set; }

        public decimal? SD { get; set; }

        public decimal? VAT { get; set; }

        public decimal? AIT { get; set; }

        public decimal? RD { get; set; }

        public decimal? ATV { get; set; }

        public decimal? TTI { get; set; }

        public decimal? DiscountPercent { get; set; }

        public decimal? DiscountPerItem { get; set; }

        public DateTime? Date { get; set; }

        public string TransportNo { get; set; }

        public int? ReprintCount { get; set; }

        public string Reasons { get; set; }

        public string BranchId { get; set; }

        public bool SourceDeduct { get; set; }

        public bool DeemedExport { get; set; }

        public decimal? Exciseduty { get; set; }

        public decimal? DevSerCharge { get; set; }

        public decimal? ITSerCharge { get; set; }

        public decimal? HealthProtectionSerCharge { get; set; }

        public decimal? EnvSerCharge { get; set; }


        public string CREATE_BY { get; set; }

        public DateTime? CREATE_DATE { get; set; }

        public string UPDATE_BY { get; set; }

        public DateTime? UPDATE_DATE { get; set; }

        public decimal? ChangeAmount { get; set; }

        public decimal? TotalAmount { get; set; }

        public decimal? NetAmount { get; set; }

        public int? VAT_TYPE { get; set; }
        public decimal LOTNO { get; set; }

        public decimal ConversionRate { get; set; }

        public decimal? VatPer { get; set; }
        public decimal? SDPer { get; set; }

        public decimal? RSD { get; set; }
        public decimal? RVat { get; set; }
        public string ExternalID { get; set; }

        public string TransferTo { get; set; }

    }
}
