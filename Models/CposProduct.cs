using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbLogServices.Models
{
    public class CposProduct
    {
        public string products_name_1 { get; set; }
        public string products_description_1 { get; set; }
        public decimal products_price { get; set; }
        public string style_code { get; set; }
        public string bar_code { get; set; }
        public int products_type { get; set; }
        public int products_status { get; set; }
        public int products_min_order { get; set; }
        public int is_current { get; set; }
        public string is_special { get; set; }
        public decimal tax { get; set; }
        public decimal stock { get; set; }
        public string CATEGORY_NAME { get; set; }
        public string SUB_CATEGORY_NAME { get; set; }
        public string store_code { get; set; }
    }
    public class GetProductAttribute
    {
        public string variance_name { get; set; }
        public string attribute_name { get; set; }
        public string bar_code { get; set; }
        public decimal mrp { get; set; }
    }

    public class BarcodeStatus
    {
        public List<string> barcodes { get; set; }
    }
}
