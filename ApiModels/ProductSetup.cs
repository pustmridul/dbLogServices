using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbLogServices.ApiModels
{
    public class ProductSetup
    {
        public string PRD_ID { get; set; }
        public string CategoryID { get; set; }
        public string TypeOfPrd { get; set; }
        public string ProductSegment { get; set; }
        public string PrdName { get; set; }
        public string Description { get; set; }
        public string HSCODE { get; set; }
        public int MeasureID { get; set; }
        public decimal? CPU { get; set; }
        public decimal? SD { get; set; }
        public decimal? MRP { get; set; }
        public string CREATE_BY { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
        public bool IsRebatable { get; set; }
        public decimal? Vat { get; set; }
        public bool InActive { get; set; }
        public decimal? VatType { get; set; }
        public decimal? Exciseduty { get; set; }
        public decimal? DevSerCharge { get; set; }
        public decimal? ITSerCharge { get; set; }
        public decimal? HealthProtectionSerCharge { get; set; }
        public decimal? EnvSerCharge { get; set; }
        public bool ManageExpiry { get; set; }
        public string ExternalID { get; set; }
        public decimal _Size { get; set; }
        public string _ProducingTypeId { get; set; }
        public string _FilterId { get; set; }
        public string _PackagingTypeId { get; set; }
        public decimal? _ServiceCharge { get; set; }
        public decimal? ProductionMeasureID { get; set; }
        public bool IsPreprationItem { get; set; }
        public bool IsPItemSalable { get; set; }
        public decimal? PriceDeclarationGenerator { get; set; }
        public TarrifInformation tarrifInformation { get; set; }
        public decimal? RecordFilter { get; set; }
        public decimal? RecordCount { get; set; }
        public string ProductSource { get; set; }
        public string CategoryName { get; set; }
        public string MeasureUnitName { get; set; }
        public decimal? ExactStock { get; set; }
        public decimal? includingSD { get; set; }
        public decimal? includingVat { get; set; }
        public string TypeName { get; set; }
        public string BIL_NO { get; set; }
        public decimal? ProposedNet { get; set; }
        public decimal? ProposedTotal { get; set; }
        public decimal? Versions { get; set; }
        public decimal? LOTNO { get; set; }
        public string RawMatID { get; set; }
        public string PackingMID { get; set; }
        public string ProducingName { get; set; }
        public string FilterName { get; set; }
        public string PackagingTypeName { get; set; }
        public string PrdMeasureUnitName { get; set; }
    }
}
