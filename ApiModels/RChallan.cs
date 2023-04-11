using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbLogServices.ApiModels
{
    public class RChallan
    {
        public decimal AutoId { get; set; }

        public string ChallanID { get; set; }

        public string ItemType { get; set; }

        public string ClientType { get; set; }

        public string ChallanNo { get; set; }

        public string Bill_Of_Entry { get; set; }

        public string LCNO { get; set; }

        public string VEN_NO { get; set; }

        public DateTime? PDate { get; set; }

        public string PRD_ID { get; set; }

        public string RawMatID { get; set; }

        public string PackingMID { get; set; }

        public decimal? Qty { get; set; }
        public decimal? RQty { get; set; }

        public decimal? CPU { get; set; }
        public decimal? PriceValue { get; set; }

        public decimal? Vat { get; set; }

        public decimal? CD { get; set; }
        public decimal? RD { get; set; }
        public decimal? EXD { get; set; }
        public decimal? AIT { get; set; }

        public decimal? SD { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public string CREATE_BY { get; set; }

        public DateTime? CREATE_DATE { get; set; }

        public string UPDATE_BY { get; set; }

        public DateTime? UPDATE_DATE { get; set; }

        public int? OfficeCodeId { get; set; }

        public string ExcelRef { get; set; }
        public string VatDeductionNo { get; set; }

        public bool? IsPaymentComplete { get; set; }
        public decimal LOTNO { get; set; }


        public bool? SourceDeduct { get; set; }
        public decimal? AT { get; set; }
        public int? VatType { get; set; }
        public string BranchID { get; set; }


        public decimal? CDPer { get; set; }
        public decimal? RDPer { get; set; }
        public decimal? EXDPer { get; set; }
        public decimal? AITPer { get; set; }
        public decimal? ATPer { get; set; }
        public decimal? VatPer { get; set; }
        public decimal? SDPer { get; set; }

        public decimal? AV { get; set; }
        public string ExternalID { get; set; }

        public decimal Insurance { get; set; }
        public decimal LandingCharge { get; set; }

    }
}
