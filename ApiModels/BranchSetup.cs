using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbLogServices.ApiModels
{
    public class BranchSetup
    {
        public string BranchID { get; set; }

        public string COM_NO { get; set; }

        public string BranchName { get; set; }

        public string BranchAddress { get; set; }

        public string BranchPhone { get; set; }

        public string BranchVATREG { get; set; }

        public string CREATE_BY { get; set; }

        public DateTime? CREATE_DATE { get; set; }

        public string UPDATE_BY { get; set; }

        public DateTime? UPDATE_DATE { get; set; }

        public bool? IsFactory { get; set; }

        public bool? IsWareHouse { get; set; }
        public bool? IsHeadOffce { get; set; }
        public string ExternalID { get; set; }
    }
    public class TarrifInformation
    {
        public string HSCODE { get; set; }
        public string DESCRIPTION { get; set; }
        public int CD { get; set; }
        public int SD { get; set; }
        public int VAT { get; set; }
        public int AIT { get; set; }
        public int RD { get; set; }
        public int ATV { get; set; }
        public int TTI { get; set; }
        public int EXD { get; set; }
        public bool IsActive { get; set; }
        public string CREATE_BY { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public int Version { get; set; }
        public string ExcelRef { get; set; }
        public int RecordFilter { get; set; }
        public int RecordCount { get; set; }
    }

}
