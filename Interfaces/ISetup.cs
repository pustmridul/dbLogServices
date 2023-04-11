using dbLogServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbLogServices.Interfaces
{
    public interface ISetup
    {
        List<ShopList> Shop_GetNewRecord();
    }
}
