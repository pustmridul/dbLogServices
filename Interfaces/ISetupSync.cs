﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbLogServices.Interfaces
{
    public interface ISetupSync
    {
        void SyncShopList();
        void SyncProductList();
        void SyncVendorList();
        void SyncCustomerList();
    }
}
