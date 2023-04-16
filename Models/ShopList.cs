using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace dbLogServices.Models
{
    [Table("ShopList")]
    public class ShopList
    {
        [Key]
        public string ShopID { get; set; }
        public string? ShopName { get; set; }
        public string? VillAreaRoad { get; set; }
        public string? Post { get; set; }
        public string? Pstation { get; set; }
        public string? District { get; set; }
        public string? Contact { get; set; }
        public string? Phone { get; set; }
        public string? VATDisabled { get; set; }
        public string? VatSync { get; set; }


    }
}
