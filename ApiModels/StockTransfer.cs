using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbLogServices.ApiModels
{
    public class StockTransfer
    {
        public decimal StockTransferId { get; set; }

        public string ChallanNo { get; set; }

        public DateTime TransferDate { get; set; }

        public string FromBranch { get; set; }

        public string ToBranch { get; set; }

        public string PRD_ID { get; set; }

        public string RawMatID { get; set; }

        public string PackingMID { get; set; }
        public string ItemType { get; set; }

        public decimal Qty { get; set; }
        public decimal CPU { get; set; }
        public decimal RPU { get; set; }

        public string Comments { get; set; }

        public string CREATE_BY { get; set; }

        public DateTime CREATE_DATE { get; set; }

        public string ExcelRef { get; set; }

        public decimal SD_per { get; set; }
        public decimal VAT_Per { get; set; }

        public decimal SalesQty { get; set; }
        public decimal LOTNO { get; set; }

        public decimal SD { get; set; }
        public decimal VAT { get; set; }

        public string ExternalID { get; set; }
        public string ExternalInvoice { get; set; }


        public string PrvCusID { get; set; }
        public decimal DiscPrcnt { get; set; }

        public string PlaceOfDelivery { get; set; }
        public string VehicleNo { get; set; }

    }
}
