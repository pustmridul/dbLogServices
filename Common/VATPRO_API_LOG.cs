using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbLogServices.Common
{
    public class VATPRO_API_LOG
    {
        public decimal LogId { get; set; }
        public DateTime LogDate { get; set; }
        public string SendData { get; set; }
        public string ReceiveData { get; set; }
        public bool Status { get; set; }

    }
}
