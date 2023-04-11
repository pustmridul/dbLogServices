using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbLogServices.Models
{
    [Table("rChallan")]
    public class RCHALLAN
    {
        [Key]
        public string CmpIDX { get; set; }
        public string? Chln { get; set; }
        public string? OrderNo { get; set; }
        public DateTime? BuyDT { get; set; }
        public string? sBarCode { get; set; }
        public string? BarCode { get; set; }
        public string? GroupName { get; set; }
        public string? Prdname { get; set; }
        public string? BTname { get; set; }
        public string? SSName { get; set; }
        public string? fbname { get; set; }
        public string? ftname { get; set; }
        public string? clname { get; set; }
        public string? wsname { get; set; }
        public string? slname { get; set; }
        public string? ShortName { get; set; }
        public decimal? CPU { get; set; }
        public decimal? RPU { get; set; }
        public decimal? VPU { get; set; }
        public decimal? RPP { get; set; }
        public decimal? VPP { get; set; }
        public decimal? DiscPrcnt { get; set; }
        public decimal? VATPrcnt { get; set; }
        public decimal? PrdComm { get; set; }
        public decimal? Qty { get; set; }
        public decimal? bQty { get; set; }
        public decimal? sQty { get; set; }
        public decimal? cSqty { get; set; }
        public decimal? rQty { get; set; }
        public decimal? dmlqty { get; set; }
        public decimal? balQty { get; set; }
        public string? SupID { get; set; }
        public string? SupName { get; set; }
        public DateTime? EXPDT { get; set; }
        public DateTime? LastSDT { get; set; }
        public string? ShopID { get; set; }
        public string? Transfer { get; set; }
        public decimal? TotalPrdComm { get; set; }
        public decimal? AddPrdComm { get; set; }
        public decimal? ChlnTotal { get; set; }
        public string? SupRef { get; set; }
        public string? UserID { get; set; }
        public decimal? Point { get; set; }
        public decimal? Reorder { get; set; }     
        public string? ZoneID { get; set; }
    }
}
