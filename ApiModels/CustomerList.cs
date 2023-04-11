using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbLogServices.ApiModels
{
    public class CustomerList
    {
        public string CUST_NO { get; set; }

        public string CUST_NAME { get; set; }

        public string VAT_REG_NO { get; set; }

        public string TIN { get; set; }

        public string NID { get; set; }

        public string ADDRES { get; set; }

        public string TELPHONE { get; set; }

        public string EMAIL { get; set; }

        public string CUST_GROUP { get; set; }

        public string CREATE_BY { get; set; }

        public DateTime? CREATE_DATE { get; set; }

        public string UPDATE_BY { get; set; }

        public DateTime? UPDATE_DATE { get; set; }

        public string ExternalID { get; set; }
    }
}
