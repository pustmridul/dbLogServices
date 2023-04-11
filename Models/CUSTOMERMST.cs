using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace dbLogServices.Models
{
    [Table("CustomerMst")]
    public class CUSTOMERMST
    {
        [Key]
        public string PrvCusID { get; set; }
        public string ZoneName { get; set; }
        public string Catgry { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public string CusName { get; set; }
        public string Address { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string MailTo { get; set; }
        public string Tel_Home { get; set; }
        public string Tel_Office { get; set; }
        public string Mobile { get; set; }
        public string FAX { get; set; }
        public string Email { get; set; }
        public string Email1 { get; set; }
        public string Profession { get; set; }
        public string Company { get; set; }
        public string Designation { get; set; }
        public DateTime? BirthDt { get; set; }
        public string MStatus { get; set; }
        public DateTime? ANVDT { get; set; }
        public string SpouseName { get; set; }
        public DateTime? SpouseBirthDT { get; set; }
        public decimal? ChildNo { get; set; }
        public string ChildName1 { get; set; }
        public string ChildName2 { get; set; }
        public string ChildName3 { get; set; }
        public DateTime? Child1BDT { get; set; }
        public DateTime? Child2BDT { get; set; }
        public DateTime? Child3BDT { get; set; }
        public DateTime? DOE { get; set; }
        public decimal? Discprcnt { get; set; }
        public string DiscAllowed { get; set; }
        public decimal? TotalEarn { get; set; }
        public decimal? TotalRedeem { get; set; }
        public decimal? TotalReturn { get; set; }
        public string UserName { get; set; }
        public string ParentID { get; set; }
    }
}
