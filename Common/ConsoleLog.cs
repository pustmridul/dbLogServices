using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbLogServices.Common
{
    public class ConsoleLog
    {
        public long Pos { get; set; }
        public string Text { get; set; }
        public object Tag { get; set; }
        public bool IsAdded { get; set; }
        public DateTime _Time { get; set; }
    }
}
