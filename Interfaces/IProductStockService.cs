using dbLogServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbLogServices.Interfaces
{
    public interface IProductStockService
    {
        List<CposProduct> GetAllDataFIKDAL();
        Task<IReadOnlyList<CposProduct>> GetAllProductStock();
        bool updateProdct_StockByBarcode(string Barcode);
    }
}
