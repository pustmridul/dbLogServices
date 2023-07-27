using Dapper;
using dbLogServices.Interfaces;
using dbLogServices.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIK.DAL;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using dbLogServices.ApiModels;
using dbLogServices.Common;
using dbLogServices.Helpers;
using System.Collections;
using Newtonsoft.Json;

namespace dbLogServices.Services
{
    public class ProductStockService : IProductStockService
    {
        private FIK.DAL.Core.SQL  _sql;
        private readonly IConfiguration configuration;
        static Helper helper = new Helper();
        public ProductStockService(IConfiguration configuration) 
        {
            this.configuration = configuration;
            _sql =  new FIK.DAL.Core.SQL(configuration.GetConnectionString("DefaultConnection"));
        }
        //public async Task<IReadOnlyList<CposProduct>> GetAllProductStock()
        //{
        //    var sql = "SELECT top 2 * FROM Product_list";
        //    using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        connection.Open();

        //        List<CposProduct> result = await connection.QueryAsync<CposProduct>(sql);

        //        return result.ToList();
        //    }

        //    using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            string sqlQuery = "SELECT top 2 * FROM Product_list";
        //            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
        //            {
        //                using (SqlDataReader reader = command.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        string dataValue = reader["Barcode"].ToString();
        //                        // Access data using reader
        //                        //Console.WriteLine(reader["ColumnName"]);

        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Error: " + ex.Message);
        //        }
        //    }
        //}
        public async Task<IReadOnlyList<CposProduct>> GetAllProductStock()
        {
            List<CposProduct> result = new List<CposProduct>();
            return result.ToList();

        }

        public List<CposProduct> GetAllDataFIKDAL()
        {
            string msg = "";
            string query = @"SELECT BARCODE bar_code 
            FROM PRODUCT_LIST WHERE ( PARENT_PRODUCT = '' AND BARCODE IN  (
            SELECT BARCODE FROM PRODUCT 
            WHERE PARENT_PRODUCT = ''))";
              List<CposProduct> data  =  _sql.Select<CposProduct>(query, ref msg);

            return data;
        }
        public List<CposProduct> GetChildProductByParent(string parentBarcode, int bufferQty, string storecodeWithoutEcomm)
        {
            string msg = "";
            StringBuilder sb = new StringBuilder();
            sb.Append(@"declare @bufferQty int = " + bufferQty + @";

                select BARCODE as bar_code ,case when SUM(SAL_BAL_QTY) < 1 then 0 else SUM(SAL_BAL_QTY) end as  stock	 from (
                select  ps.BARCODE,SUM(SAL_BAL_QTY) - @bufferQty  SAL_BAL_QTY 
                from PRODUCT_STOCK ps 
                inner join (SELECT BARCODE FROM PRODUCT_LIST    
                 WHERE PARENT_PRODUCT = '" + parentBarcode + @"') pl on pl.BARCODE = ps.BARCODE 
                where STORE_CODE in (" + storecodeWithoutEcomm + @")
                group by ps.BARCODE
                union all 
                select  ps.BARCODE,SUM(SAL_BAL_QTY) SAL_BAL_QTY 
                from PRODUCT_STOCK ps 
                inner join (SELECT BARCODE FROM PRODUCT_LIST    
                 WHERE PARENT_PRODUCT = '" + parentBarcode + @"') pl on pl.BARCODE = ps.BARCODE 
                where STORE_CODE in ('100010011')
                group by ps.BARCODE) aa
                group by BARCODE");
            
            string query = sb.ToString();
            List<CposProduct> data = _sql.Select<CposProduct>(query, ref msg);
            return data;
        }



        public void SyncShopList()
        {

            try
            {
                List<CposProduct> parentProducts = GetAllDataFIKDAL();

                if (parentProducts == null || parentProducts.Count == 0)
                {
                    return;
                }

                foreach (CposProduct item in parentProducts)
                {
                    List<CposProduct> childProducts = GetChildProductByParent(item.bar_code, 2, "");
                    List<ProductAttributesBarcodeStock> variableStock = new List<ProductAttributesBarcodeStock>();
                    foreach (CposProduct child in childProducts)
                    {
                        ProductAttributesBarcodeStock o = new ProductAttributesBarcodeStock();
                        int qty = 0;
                        qty = Convert.ToInt32(child.stock) < 0 ? 0 : Convert.ToInt32(child.stock);

                        o.bar_code = child.bar_code;
                        o.stock = qty; 
                        variableStock.Add(o);
                    }

                    if (variableStock.Count > 0)
                    {
                        var serializedData = JsonConvert.SerializeObject(variableStock);
                        //var content = new StringContent(serializedData, Encoding.UTF8, "application/json");
                        Result r = helper.PostData("/product/stock/add", serializedData);
                        if (r.Status)
                        {
                            foreach (ProductAttributesBarcodeStock stockBarcode in variableStock)
                            {
                                updateProdct_StockByBarcode(stockBarcode.bar_code);
                            }
                            
                        }

                    }


                }

               

                
            }
            catch (Exception ex)
            {

            }
            
        }

        public bool updateProdct_StockByBarcode(string Barcode)
        {
            string msg = "";
            string sql = @"UPDATE [dbo].[product_stock] SET [issync] = 1 WHERE barcode ='" + Barcode + "' ";
            List<string> query = new List<string>();
            query.Add(sql);

            _sql.ExecuteQuery(query, ref msg);

            if (msg == "")
            {
                return true;
            }
            return false;
            
        }


    }
}
