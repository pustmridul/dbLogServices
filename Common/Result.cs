﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbLogServices.Common
{
    public class Result
    {
        public object Data { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
